using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class BackCardData : MonoBehaviour
{
    public Button[] OutcomeBtn;
    //Partner Component
    public GameObject VideoButton;
    public TextMeshProUGUI[] BusinessOutcomeText;
    public TextMeshProUGUI BackCardText;
    public TextMeshProUGUI PartnerName;
    public Image PartnerImage;
    public TextMeshProUGUI PartnerDescription;
    public string buttonName;
    public GameObject PartnerWindow;

    //Dell Component
    public TextMeshProUGUI DellName;
    public Image DellImage;
    public TextMeshProUGUI DellDescription;
    public GameObject DellWindow;
    public GameObject BusinessOutcomeWindow;
    public GameObject[] HotSpot;
    public static BackCardData instance;
    public string videolink;
    // Start is called before the first frame update
    void Start()
    {
       
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowBackFlipper()
    {
        
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
         buttonName = clickedButton.name;
        // BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
        //  BackCardLowerText.text = Load_Tour_text.ins.DVSCardFace[int.Parse(buttonName)].ToString();
        if (ImageLoader.ComponentName == "VP")
        {
            for (int i = 0; i <= 6; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            //old flipper
            ImageLoader.instance.BackFlipCard.SetActive(true);
            BackCardText.text = ImageLoader.instance.VPr[int.Parse(buttonName)].ToString();

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
        }
        else if (ImageLoader.ComponentName == "BO")
        {
            Color NormalColor = ColorUtility.TryParseHtmlString("#036495", out Color color) ? color : Color.white;
            Color PressedColor = ColorUtility.TryParseHtmlString("#0F84BB", out Color color1) ? color1 : Color.white;
            for (int i = 0; i <= 13; i++)
            {
                HotSpot[i].SetActive(false);
            }
            for (int i = 0; i <= 5; i++)
            {
                BusinessOutcomeText[i].text = ImageLoader.instance.BO[i].ToString();
                ImageLoader.instance.Cards[i].SetActive(false);
                if (OutcomeBtn[int.Parse(buttonName)] == OutcomeBtn[i])
                {
                    OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = PressedColor;
                }
                else
                {
                    // OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = NormalColor;
                }
            }

            BusinessOutcomeWindow.SetActive(true);

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
        }
        else if (ImageLoader.ComponentName == "PS")
        {
            for (int i = 0; i <= 6; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            PartnerWindow.SetActive(true);
            // BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
            // name, 
            PartnerName.text = ImageLoader.instance.PS[int.Parse(buttonName)];
            // image,
            StartCoroutine(LoadImageWithUrlPartners(Load_Tour_text.ins.partners[int.Parse(buttonName)]));
            // Guided_Tour.instance.PartnerImg[int.Parse(buttonName)].gameObject.SetActive(true);
            // desc,
            PartnerDescription.text = Load_Tour_text.ins.PartnerDescription[int.Parse(buttonName)];
            // link, More Details
            // video 
            if (Load_Tour_text.ins.PSVideoLink[int.Parse(buttonName)] == "null")
            {
                VideoButton.SetActive(false);
            }
            else
            {
                VideoButton.SetActive(true);
                //Debug.Log("Link Exisit"+ Load_Tour_text.ins.PSVideoLink[int.Parse(buttonName)]);
                videolink = Load_Tour_text.ins.PSVideoLink[int.Parse(buttonName)];


            }
        }

    }
    public void Playvideo()
    {

        StartCoroutine(VideoLoader.instance.VideoPlay(videolink));
    }
    public void parntnerclose()
    {
        for (int i = 0; i <= 5; i++)
        {
            ImageLoader.instance.Cards[i].SetActive(true);
        }
    }
    public void Dellclose()
    {
        for (int i = 0; i <= 5; i++)
        {
            ImageLoader.instance.Cards[i].SetActive(true);
        }
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
            for (int i = 0; i <= 5; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(true);
            }
        }
    }
   
    public  int[] hotspotlist;
    public int numberofhotspots;
    public bool HotSpotsRuninng;

    public void FlashHotspot(int i)
    {
        myCoroutine = OutcomeBtnF(i);
        StartCoroutine(myCoroutine);
        
    }
    public void StopCoroutineTour()
    {
        if (HotSpotsRuninng)
        {
            StopCoroutine(myCoroutine);
            for (int j = 0; j < 14; j++)
            {
                for (int i = 0; i < HotSpot[j].transform.childCount; i++)
                {
                    HotSpot[j].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
           
        }

    }
    IEnumerator myCoroutine;
    public IEnumerator OutcomeBtnF(int ButtonNaame)
    {
        HotSpotsRuninng = true;
        if (HotSpotsRuninng)
        {
            HotSpotsRuninng = true;
           // ImageToggleOnHover.Tour_Running = false;

            yield return null;
        }
        HotSpotsRuninng = true;
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].SetActive(false);
        }
        if (ButtonNaame == 0)
        {
            numberofhotspots = 6;
            hotspotlist[0] =3;
            hotspotlist[1] = 5;
            hotspotlist[2] = 0;
            hotspotlist[3] = 7;
            hotspotlist[4] = 1;
            hotspotlist[5] = 13;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];
                
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);
             
                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudio[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudio[k].length;
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

                    yield return null;
                }
            }
           
        }
        else if (ButtonNaame == 1)
        {
            numberofhotspots = 4;
            hotspotlist[0] = 3;
            hotspotlist[1] = 5;
            hotspotlist[2] = 7;
            hotspotlist[3] = 2;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];

                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudio[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudio[k].length;
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

        }
        else if (ButtonNaame == 2)
        {
            numberofhotspots = 4;
            hotspotlist[0] = 0;
            hotspotlist[1] = 5;
            hotspotlist[2] = 7;
            hotspotlist[3] = 13;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];

                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudio[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudio[k].length;
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

        }
        else if (ButtonNaame == 3)
        {
            numberofhotspots = 3;
            hotspotlist[0] = 4;
            hotspotlist[1] = 11;
            hotspotlist[2] = 1;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];

                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudio[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudio[k].length;
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

        }
        else if (ButtonNaame == 4)
        {
            numberofhotspots = 4;
            hotspotlist[0] = 10;
            hotspotlist[1] = 11;
            hotspotlist[2] = 6;
            hotspotlist[3] = 13;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];

                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudio[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudio[k].length;
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

        }
        else
        {
            numberofhotspots = 1;
            hotspotlist[0] = 12;
            for (int j = 0; j < numberofhotspots; j++)
            {
                int k = hotspotlist[j];

                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(true);

                }
                HotSpot[k].SetActive(true);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudio[k];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudio[k].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                for (int i = 0; i < HotSpot[k].transform.childCount; i++)
                {
                    HotSpot[k].transform.GetChild(i).GetChild(2).GetChild(1).gameObject.SetActive(false);
                }
            }
          //  HotSpot[12].SetActive(true);
        }
    }
    public void OutcomeCrossBtn()
    {
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].SetActive(true);
        }
        BusinessOutcomeWindow.SetActive(false);
        //  OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = ColorUtility.TryParseHtmlString("FFFFFF",out Color32(255,255,255,157));
    }
    public void PartnerLink()
    {
        Application.OpenURL(Load_Tour_text.ins.PartnersLink[int.Parse(buttonName)]);
    }
    public IEnumerator LoadImageWithUrlPartners(string ImageLink)
    {
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
