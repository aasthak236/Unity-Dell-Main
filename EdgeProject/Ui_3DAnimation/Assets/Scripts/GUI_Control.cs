using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class GUI_Control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RotatingComponent;
    public bool isopen;
    public static GUI_Control instance;
    public GameObject FlipBtn;
    public GameObject LoadingScreen;
    public GameObject Mute, Unmute;
    public GameObject Tour_Card;
    public GameObject video;
    public VideoPlayer videoplayer;
    public GameObject DellBackPanel;
    public GameObject DellSolutionPanel;
    public GameObject DellDetailWindow;
    public TextMeshProUGUI[] DellText;
    public string videolink;
    void Start()
    {
        PlayerPrefs.SetInt("MusicOn", 1);
        if (PlayerPrefs.GetInt("MusicOn") == 1)
        {
            Mute.SetActive(true);
            Unmute.SetActive(false);
            AudioListener.volume = 1f;
            videoplayer.SetDirectAudioMute(0, false);

        }
        else
        {
            Mute.SetActive(false);
            Unmute.SetActive(true);
            AudioListener.volume = 0f;
            videoplayer.SetDirectAudioMute(0, true);
        }
        instance = this;
    }
    public void soundon()
    {
        PlayerPrefs.SetInt("MusicOn", 1);
        AudioListener.volume = 1f;
        
        videoplayer.SetDirectAudioMute(0, false);
    }
    public void soundoff()
    {
        PlayerPrefs.SetInt("MusicOn", 0);
        AudioListener.volume = 0f;
       
        videoplayer.SetDirectAudioMute(0, true);

    }
    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("check isopen" + isopen);
    }
    //refrence go to open main BB 
    public void Disable_Hotspot()
    {
        ClickController.instance.bAutoRotate = true;
        OnClick.Hotspot = false;
    }
    public string CardType;
    public bool bAutorotate;
    public int DefaultCard;
    bool outCome = true;
    bool BB = true;
    bool DVS = true;
    public bool any_window_open;
    public int currentgraphic;
    public int EndingGraphic;
    public int StartingGraphic;
    public void OpenComponent(string ComponentName)
    {
     
        switch (ComponentName)
        {
            //case "Outcome":
            //    outCome = !outCome;
            //    ClickController.instance.CancelAllTimer();
            //    Activator(ComponentName, outCome);
            //    BB = true;
            //    DVS = true;
            //    break;

            case "BB":
                BB = !BB;
                ClickController.instance.CancelAllTimer();
                Activator(ComponentName, BB);
                outCome = true;
                DVS = true;
                ImageLoader.instance.ispressed = false;
                for (int i = 0; i < 5; i++)
                {
                    ImageLoader.instance.NewCard[i].SetActive(false);
                }
                break;

            case "DVS":
                DVS = !DVS;
                ClickController.instance.CancelAllTimer();
                Activator(ComponentName, DVS);
                BB = true;
                outCome = true;
                ImageLoader.instance.ispressed = false;
                for (int i = 0; i < 5; i++)
                {
                    ImageLoader.instance.NewCard[i].SetActive(false);
                }
                break;

            default:
                break;
        }

    }
    
   public void Activator(string ComponentName, bool isopen)
    {
        Hower_Active.Howeractive = true;
        Tour_Card.SetActive(false);
        if (isopen == false)
        {
            
            if (ComponentName == "DVS")
            {
                CardType = ComponentName;
                isopen = true;
                DellSolutionPanel.SetActive(true);
                for (int i = 1; i <= 5; i++)
                {
                    DellText[i - 1].text = Load_Tour_text.ins.DVSCardFace[i - 1].ToString();
                    ImageLoader.instance.NewCard[i - 1].SetActive(false);
                }
            }
            else
            {
                if (DetectCard.isRotated == true)
                {
                    DetectCard.instance.ResetFlip();
                }
                CardType = ComponentName;
                // StartCoroutine(ImageLoader.instance.frontBB(ComponentName));
                ImageLoader.instance.LoadFliperText(ComponentName);
                //StartCoroutine(ImageLoader.instance.backBB(ComponentName));
                // LoadingScreen.SetActive(true);
                //Invoke("loadingfalse", 4f);
                RotatingComponent.SetActive(true);
                isopen = true;
                FlipBtn.SetActive(true);
                ClickController.instance.SetPos();
                ClickController.instance.BAutorotate();
                video.SetActive(false);
                DellSolutionPanel.SetActive(false);
                DellDetailWindow.SetActive(false);
                any_window_open = true;
            }
            //ClickController.instance.CancelAllTimer();
        }
        else
        {
            ClickController.instance.CancelAllTimer();
            RotatingComponent.SetActive(false);
            isopen = false;
            any_window_open = false;
            FlipBtn.SetActive(false);
            DellSolutionPanel.SetActive(false);
        }
    }
    public void loadingfalse()
    {
        LoadingScreen.SetActive(false);
        CancelInvoke();
    }
   
    public bool isopen2;
    public bool isOpenvideo;
    public void Openvideo()
    {
        Guided_Tour.instance.CloseAllWindow();
        if (isopen2 == false)
        {
            Hower_Active.Howeractive = true;
            Invoke("loadvideo", 0.5f);
            isopen2 = true;
            RotatingComponent.SetActive(false);
            LoadingScreen.SetActive(true);
            Invoke("loadingfalse", 3f);
            FlipBtn.SetActive(false);
            isOpenvideo = true;


        }
        else
        {
            video.SetActive(false);
            isopen2 = false;
            FlipBtn.SetActive(false);
        }
    }
    public void loadvideo()
    {
        video.SetActive(true);
        
    }
    public TextMeshProUGUI DellName;
    public Image DellImage;
    public TextMeshProUGUI DellDescription;
    public string buttonName;
    public void DellBackData()
    {
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
         buttonName = clickedButton.name;
        DellDetailWindow.SetActive(true);
        currentgraphic = 0;
        EndingGraphic = Load_Tour_text.ins.PartnerGraphicsIndex[int.Parse(buttonName)] - 1;
        StartingGraphic = 0;
        if (int.Parse(buttonName) > 0)
        {
            StartingGraphic = Load_Tour_text.ins.PartnerGraphicsIndex[int.Parse(buttonName) - 1];
        }
        currentgraphic = StartingGraphic;
        //for (int i = 0; i <5; i++)
        //{
        //   // ImageLoader.instance.Cards[i].SetActive(false);
        //}

        // name, 
        DellName.text = Load_Tour_text.ins.DVSCardFace[int.Parse(buttonName)];
        // image,
        StartCoroutine(LoadDellImageWithUrlPartners(Load_Tour_text.ins.DS_Image[int.Parse(buttonName)])); ;
        // Guided_Tour.instance.PartnerImg[int.Parse(buttonName)].gameObject.SetActive(true);
        // desc,
        DellDescription.text = Load_Tour_text.ins.DS_Detail[int.Parse(buttonName)];
        QRCodeGenerator.instance.TexttoqrcodeDell();
        //for (int i = 0; i <= 5; i++)
        //{
        //    OutcomeBtn[i].GetComponent<Image>().color = NormalColor;
        //}
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
           // VideoButton.SetActive(true);
            videolink = Load_Tour_text.ins.PartnerGraphics[currentgraphic];
            StartCoroutine(DellVideo.instance.VideoPlay());
            DellImage.gameObject.SetActive(false);
        }
        else
        {
            DellVideo.instance.videoPlayer.Stop();
            DellVideo.instance.videoimage.SetActive(false);
            DellImage.gameObject.SetActive(true);
            StartCoroutine(LoadDellImageWithUrlPartners(Load_Tour_text.ins.PartnerGraphics[currentgraphic]));
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
            DellImage.gameObject.SetActive(false);
            videolink = Load_Tour_text.ins.PartnerGraphics[currentgraphic];
            StartCoroutine(DellVideo.instance.VideoPlay());
        }
        else
        {
            DellVideo.instance.videoPlayer.Stop();
            DellImage.gameObject.SetActive(true);
            DellVideo.instance.videoimage.SetActive(false);

            StartCoroutine(LoadDellImageWithUrlPartners(Load_Tour_text.ins.PartnerGraphics[currentgraphic]));
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
    public void DellSolutionLink()
    {
        Application.OpenURL(Load_Tour_text.ins.DS_Link[int.Parse(buttonName)]);
    }
}
