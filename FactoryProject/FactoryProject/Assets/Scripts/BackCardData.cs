using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.Video;
using System.Linq;

public class BackCardData : MonoBehaviour
{
    public Button[] OutcomeBtn;
    //Partner Component
    
    public GameObject Manufaturing_Video_Button;
    public GameObject VideoButton;
    public TextMeshProUGUI[] BusinessOutcomeText;
    public TextMeshProUGUI[] PartnerSolutionText;
    public TextMeshProUGUI[] DellSolutionText;
    public TextMeshProUGUI BackCardText;
    public TextMeshProUGUI PartnerName;
    public TextMeshProUGUI BOText;
    public GameObject OutcomeTextPanel;
    public Image PartnerImage;
    public TextMeshProUGUI PartnerDescription;
    public string buttonName;
    public GameObject PartnerWindow;

    //Dell Component
    public TextMeshProUGUI DellName;
    public Image DellImage;
    public TextMeshProUGUI DellDescription;
    public GameObject DellWindow;
    public GameObject PartnerFrontWindow;
    public GameObject DellFrontWindow;
    public GameObject BusinessOutcomeWindow;
    public GameObject[] HotSpot;
    public static BackCardData instance;
    public string videolink;
    
    // Start is called before the first frame update
    void Start()
    {

        
          NormalColor = ColorUtility.TryParseHtmlString("#612CB0", out Color color) ? color : Color.white;
        PressedColor = ColorUtility.TryParseHtmlString("#2A145A", out Color color1) ? color1 : Color.white;
        instance = this;
        HotSpotSizeIncrease();
        Invoke("ActiveEnterButton", 10f);
    }
    public void ActiveEnterButton()
    {
        Manufaturing_Video_Button.SetActive(true);
    }
    public void HotSpotSizeIncrease()
    {
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].transform.GetChild(0).transform.localScale = new Vector3(3,3,3);
        }
    }
    public void HotSpotSizeDecrease()
    {
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void HotSpotSizeDecreaseTouranim()
    {
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].transform.GetChild(0).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
    // Update is called once per frame
    public int currentgraphic;
    public int EndingGraphic;
    public int StartingGraphic;
    public void ShowBackFlipper()
    {
        
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
         buttonName = clickedButton.name;
        // BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
        //  BackCardLowerText.text = Load_Tour_text.ins.DVSCardFace[int.Parse(buttonName)].ToString();
        if (ImageLoader.ComponentName == "VP")
        {
         
            for (int i = 0; i <= 5; i++)
            {
                OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
            }
            for (int i = 0; i <= 6; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            //old flipper
            ImageLoader.instance.BackFlipCard.SetActive(true);
            BackCardText.text = ImageLoader.instance.VPr[int.Parse(buttonName)].ToString();
            HotSpotsRuninng = true;
        }
        else if (ImageLoader.ComponentName == "EC")
        {
           
            for (int i = 0; i <= 5; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            //old flipper
            ImageLoader.instance.BackFlipCard.SetActive(true);
            BackCardText.text = ImageLoader.instance.ECr[int.Parse(buttonName)].ToString();
            for (int i = 0; i <= 5; i++)
            {
                OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
            }
            HotSpotsRuninng = true;
        }
        else if (ImageLoader.ComponentName == "BO")
        {
            
            for (int j = 0; j <= 5; j++)
            {
                OutcomeBtn[j].GetComponent<Image>().color = NormalColor;
            }
            for (int i = 0; i <= 13; i++)
            {
                HotSpot[i].SetActive(false);
            }
            for (int i = 0; i <= 5; i++)
            {
                BusinessOutcomeText[i].text = ImageLoader.instance.BO[i].ToString();
                ImageLoader.instance.Cards[i].SetActive(false);
               
            }

            BusinessOutcomeWindow.SetActive(true);
            HotSpotsRuninng = true;
            if (int.Parse(buttonName) == 0)
            {
                HotSpot[0].SetActive(true);
                HotSpot[3].SetActive(true);
                HotSpot[5].SetActive(true);
                HotSpot[7].SetActive(true);
                HotSpot[1].SetActive(true);
                HotSpot[13].SetActive(true);
            }
            else if (int.Parse(buttonName) == 1)
            {
                HotSpot[3].SetActive(true);
                HotSpot[5].SetActive(true);
                HotSpot[7].SetActive(true);
                HotSpot[2].SetActive(true);

            }
            else if (int.Parse(buttonName) == 2)
            {
                HotSpot[0].SetActive(true);
                HotSpot[5].SetActive(true);
                HotSpot[7].SetActive(true);
                HotSpot[13].SetActive(true);

            }
            else if (int.Parse(buttonName) == 3)
            {
                HotSpot[4].SetActive(true);
                HotSpot[11].SetActive(true);
                HotSpot[1].SetActive(true);

            }
            else if (int.Parse(buttonName) == 4)
            {
                HotSpot[10].SetActive(true);
                HotSpot[11].SetActive(true);
                HotSpot[6].SetActive(true);
                HotSpot[13].SetActive(true);

            }
            else
            {
                HotSpot[12].SetActive(true);
            }

            // BackCardText.text = ImageLoader.instance.BOr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "DS")
        {
          
            for (int i = 0; i <= 5; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            DellWindow.SetActive(true);
            // name, 
            DellName.text = ImageLoader.instance.DS[int.Parse(buttonName)];
            // image,
            StartCoroutine(LoadDellImageWithUrlPartners(Load_Tour_text.ins.Dell[int.Parse(buttonName)])); ;
            // Guided_Tour.instance.PartnerImg[int.Parse(buttonName)].gameObject.SetActive(true);
            // desc,
            DellDescription.text = Load_Tour_text.ins.DellDescription[int.Parse(buttonName)];
            for (int i = 0; i <= 5; i++)
            {
                OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
            }
            HotSpotsRuninng = true;
        }
        else if (ImageLoader.ComponentName == "PS")
        {
            currentgraphic = 0;
            EndingGraphic = Load_Tour_text.ins.PartnerGraphicsIndex[int.Parse(buttonName)]-1;
             StartingGraphic = 0;
            if (int.Parse(buttonName) > 0)
            {
                StartingGraphic =Load_Tour_text.ins.PartnerGraphicsIndex[int.Parse(buttonName)-1];
            }
            currentgraphic = StartingGraphic;
            HotSpotsRuninng = true;
            for (int i = 0; i <= 5; i++)
            {
                OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
            }
            PartnerFrontWindow.SetActive(false);
            PartnerImage.gameObject.SetActive(true);
            PartnerWindow.SetActive(true);
            PartnerName.text = ImageLoader.instance.PS[int.Parse(buttonName)];
            StartCoroutine(LoadImageWithUrlPartners(Load_Tour_text.ins.PartnerGraphics[currentgraphic]));
            PartnerDescription.text = Load_Tour_text.ins.PartnerDescription[int.Parse(buttonName)];
            // link, More Details
            // video 
            //if (Load_Tour_text.ins.PSVideoLink[int.Parse(buttonName)] == "null")
            //{
            //    VideoButton.SetActive(false);
            //}
            //else
            //{
            //   // VideoButton.SetActive(true);
            //    //Debug.Log("Link Exisit"+ Load_Tour_text.ins.PSVideoLink[int.Parse(buttonName)]);
            //    //videolink = Load_Tour_text.ins.PSVideoLink[int.Parse(buttonName)];


            //}
        }

    }
    public GameObject nextbutton;
    public GameObject previousbutton;
    public void NextButton()
    {
        currentgraphic++;
        string graphicslink = Load_Tour_text.ins.PartnerGraphics[currentgraphic];
        string lastThreeChars = graphicslink.Substring(graphicslink.Length - 3);
        if (lastThreeChars == "mp4")
        {
            VideoButton.SetActive(true);
            videolink = Load_Tour_text.ins.PartnerGraphics[currentgraphic];
            StartCoroutine(VideoLoader.instance.VideoPlay());
            PartnerImage.gameObject.SetActive(false);
        }
        else
        {
            VideoLoader.instance.videoPlayer.Stop();
            VideoLoader.instance.videoimage.SetActive(false);
            PartnerImage.gameObject.SetActive(true);
            StartCoroutine(LoadImageWithUrlPartners(Load_Tour_text.ins.PartnerGraphics[currentgraphic]));
        }


        if (currentgraphic > EndingGraphic)
        {
            nextbutton.SetActive(false);
            previousbutton.SetActive(true);
        }
        else
        {
            nextbutton.SetActive(true);
            previousbutton.SetActive(true);
        }

    }
    public void PreviousButton()
    {
        currentgraphic--;
        string graphicslink = Load_Tour_text.ins.PartnerGraphics[currentgraphic];
        string lastThreeChars = graphicslink.Substring(graphicslink.Length - 3);
        if (lastThreeChars == "mp4")
        {
            PartnerImage.gameObject.SetActive(false);
            VideoButton.SetActive(true);
            videolink = Load_Tour_text.ins.PartnerGraphics[currentgraphic];
            StartCoroutine(VideoLoader.instance.VideoPlay());
        }
        else
        {
            VideoLoader.instance.videoPlayer.Stop();
            PartnerImage.gameObject.SetActive(true);
            VideoLoader.instance.videoimage.SetActive(false);

            StartCoroutine(LoadImageWithUrlPartners(Load_Tour_text.ins.PartnerGraphics[currentgraphic]));
        }


        if (currentgraphic < StartingGraphic)
        {
            nextbutton.SetActive(true);
            previousbutton.SetActive(false);
        }
        else
        {
            nextbutton.SetActive(true);
            previousbutton.SetActive(true);
        }
    }
    public void Playvideo()
    {

        StartCoroutine(VideoLoader.instance.VideoPlay());
    }
    public void parntnerclose()
    {
        VideoLoader.instance.videoPlayer.Stop();
        PartnerFrontWindow.SetActive(true);
    }
    public void Dellclose()
    {
        DellFrontWindow.SetActive(true);
    }
    public void ValuePillarsclose()
    {
        if (ImageLoader.ComponentName == "EC")
        {
            for (int i = 0; i <= 4; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i <= 6; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(true);
            }
        }
    }
   
    public  int[] hotspotlist;
    public int numberofhotspots;
    public bool HotSpotsRuninng;
    public Color NormalColor;
    public Color PressedColor;
    public bool BusinessOutcomeStart;
    public AudioSource Silence;
    public void FlashHotspot(int i)
    {
        Guided_Tour.instance.StopCoroutine();//stop for usecase
        StopCoroutineTour();//stop for outcome
        myCoroutine = OutcomeBtnF(i);
        StartCoroutine(myCoroutine);
        BusinessOutcomeStart = true;
        ImageToggleOnHover.Tour_Running = true;
    }
    public void StopCoroutineTour()
    {
       // BusinessOutcomeWindow.SetActive(false);
        
        if (HotSpotsRuninng)
        {
            Guided_Tour.instance.audioSource.Stop();
            if (BusinessOutcomeStart)
            {
                StopCoroutine(myCoroutine);
                ImageLoader.ComponentName = null;

            }
    
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < HotSpot[j].transform.childCount; i++)
                {
                    HotSpot[j].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
            for (int i = 0; i <= 5; i++)
            {
                OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
            }
            for (int i = 0; i <= 13; i++)
            {
                HotSpot[i].SetActive(true);
            }
            BusinessOutcomeStart = false;
            //
            ImageToggleOnHover.Tour_Running = false;

        }
        for (int i = 0; i <= 4; i++)
        {
          ImageLoader.instance.MenuButton[i].GetComponent<Image>().color = ImageLoader.instance.NormalColor;
        }
    }
    IEnumerator myCoroutine;
    public IEnumerator OutcomeBtnF(int ButtonNaame)
    {
        Debug.Log(ButtonNaame);
        Guided_Tour.instance.ClosedAllWindow();
        //BusinessOutcomeWindow.SetActive(true);
        OutcomeBtn[ButtonNaame].GetComponent<Image>().color = PressedColor;
        ImageLoader.instance.MenuButton[0].GetComponent<Image>().color = ImageLoader.instance.PressedColor;

        ImageToggleOnHover.Tour_Running = true;
        HotSpotsRuninng = true;
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].SetActive(false);
        }
        Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[6];
        Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[6].length;
        Guided_Tour.instance.audioSource.Play();
        yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
        Guided_Tour.instance.audioSource.Play();
        yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
        BOText.text = ImageLoader.instance.BOr[ButtonNaame];
        if (ButtonNaame == 0)
        {
            numberofhotspots = 6;
            hotspotlist[0] =3;
            hotspotlist[1] = 5;
            hotspotlist[2] = 0;
            hotspotlist[3] = 7;
            hotspotlist[4] = 1;
            hotspotlist[5] = 13;
            OutcomeTextPanel.SetActive(true);
            
            Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame];
            Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame].length;
            Guided_Tour.instance.audioSource.Play();
            yield return new WaitForSeconds(Guided_Tour.instance.audiolength + 0.5f);
            // OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = PressedColor;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
               BOText.text = Guided_Tour.instance.HotSpotTextIntro[k];
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);
             
                }
                
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
                if (HotSpotsRuninng)
                {
                    HotSpotsRuninng = true;
                    for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                    {
                        HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                    }
                }
            }
            OutcomeTextPanel.SetActive(false);
            ImageToggleOnHover.Tour_Running = false;
        }
        else if (ButtonNaame == 1)
        {
            numberofhotspots = 3;
            hotspotlist[0] = 3;
            hotspotlist[1] = 5;
            hotspotlist[2] = 7;
            OutcomeTextPanel.SetActive(true);
           
            Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame];
            Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame].length;
            Guided_Tour.instance.audioSource.Play();
            yield return new WaitForSeconds(Guided_Tour.instance.audiolength + 0.5f);
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
                BOText.text = Guided_Tour.instance.HotSpotTextIntro[k];
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
            //HotSpot[3].SetActive(true);
            //HotSpot[5].SetActive(true);
            //HotSpot[7].SetActive(true);
            //HotSpot[2].SetActive(true);
            OutcomeTextPanel.SetActive(false);
            ImageToggleOnHover.Tour_Running = false;

        }
        else if (ButtonNaame == 2)
        {
            numberofhotspots = 4;
            hotspotlist[0] = 0;
            hotspotlist[1] = 5;
            hotspotlist[2] = 7;
            hotspotlist[3] = 13;
            OutcomeTextPanel.SetActive(true);
            Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame];
            Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame].length;
            Guided_Tour.instance.audioSource.Play();
            yield return new WaitForSeconds(Guided_Tour.instance.audiolength + 0.5f);
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
                BOText.text = Guided_Tour.instance.HotSpotTextIntro[k];
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
            //HotSpot[0].SetActive(true);
            //HotSpot[5].SetActive(true);
            //HotSpot[7].SetActive(true);
            //HotSpot[13].SetActive(true);
            OutcomeTextPanel.SetActive(false);
            ImageToggleOnHover.Tour_Running = false;
           
        }
        else if (ButtonNaame == 3)
        {
            numberofhotspots = 3;
            hotspotlist[0] = 4;
            hotspotlist[1] = 11;
            hotspotlist[2] = 1;
            OutcomeTextPanel.SetActive(true);
            Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame];
            Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame].length;
            Guided_Tour.instance.audioSource.Play();
            yield return new WaitForSeconds(Guided_Tour.instance.audiolength + 0.5f);
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
                BOText.text = Guided_Tour.instance.HotSpotTextIntro[k];
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
            //HotSpot[4].SetActive(true);
            //HotSpot[11].SetActive(true);
            //HotSpot[1].SetActive(true);
            OutcomeTextPanel.SetActive(false);
            ImageToggleOnHover.Tour_Running = false;
        }
        else if (ButtonNaame == 4)
        {
            numberofhotspots = 4;
            hotspotlist[0] = 10;
            hotspotlist[1] = 11;
            hotspotlist[2] = 6;
            hotspotlist[3] = 13;
            OutcomeTextPanel.SetActive(true);
            Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame];
            Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame].length;
            Guided_Tour.instance.audioSource.Play();
            yield return new WaitForSeconds(Guided_Tour.instance.audiolength + 0.5f);
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
                BOText.text = Guided_Tour.instance.HotSpotTextIntro[k];
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
            //HotSpot[10].SetActive(true);
            //HotSpot[11].SetActive(true);
            //HotSpot[6].SetActive(true);
            //HotSpot[13].SetActive(true);
            OutcomeTextPanel.SetActive(false);
            ImageToggleOnHover.Tour_Running = false;
        }
        else
        {
            numberofhotspots = 1;
            hotspotlist[0] = 12;
            OutcomeTextPanel.SetActive(true);
            Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame];
            Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[ButtonNaame].length;
            Guided_Tour.instance.audioSource.Play();
            yield return new WaitForSeconds(Guided_Tour.instance.audiolength + 0.5f);
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
                BOText.text = Guided_Tour.instance.HotSpotTextIntro[k];
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);
                    

                }
                
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
            ImageToggleOnHover.Tour_Running = false;
        }
        Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.OutcomeAudioIntro[6];
        Guided_Tour.instance.audiolength = Guided_Tour.instance.OutcomeAudioIntro[6].length;
        Guided_Tour.instance.audioSource.Play();
        yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
        OutcomeTextPanel.SetActive(false);
    }
    public void OutcomeCrossBtn()
    {
        for (int i = 0; i <= 5; i++)
        {
            OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
        }
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].SetActive(true);
        }
        BusinessOutcomeWindow.SetActive(false);
   
    }
    public void PartnerLink()
    {
        Application.OpenURL(Load_Tour_text.ins.PartnersLink[int.Parse(buttonName)]);
    }
    public void DellSolutionLink()
    {
        Application.OpenURL(Load_Tour_text.ins.DellLink[int.Parse(buttonName)]);
    }
    public IEnumerator LoadImageWithUrlPartners(string ImageLink)
    {
        PartnerImage.sprite = null;
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageLink))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                 
                 Texture2D texture = DownloadHandlerTexture.GetContent(request);

                    // Create a sprite from the texture and assign it to the Image component
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    PartnerImage.sprite = sprite;
                }
                else
                {
                    Debug.LogError("Image download failed: " + request.error);
                }
            }
        



    }
    public IEnumerator LoadDellImageWithUrlPartners(string ImageLink)
    {
        DellImage.sprite = null;
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageLink))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);

                // Create a sprite from the texture and assign it to the Image component
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                DellImage.sprite = sprite;
            }
            else
            {
                Debug.LogError("Image download failed: " + request.error);
            }
        }




    }

}
