using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Xml;
using UnityEngine.EventSystems;
public class Guided_Tour : MonoBehaviour
{
    public GameObject dellvideopanel;
    string url;
    public AudioSource EndVO;
    public AudioSource BgMusic;
    public AudioSource TourMusic;
    public static Guided_Tour instance;
    public TMP_Text HexagonCardtext;
    public SaveDataFromXML saveDataFile;
    public AudioClip[] audioClips;
   // public AudioClip[] HotSpotAudio;
    public AudioClip[] HotSpotAudioIntro;
    public string[] HotSpotTextIntro;
    public AudioClip[] OutcomeAudioIntro;
    public float TotalPlayTime = 4f;

    public GameObject ValuePillarsWindow;
    public TMP_Text[] ValuePillarsText;

    public GameObject card;
    public GameObject Hexagon;
    public TMP_Text[] hexaTxt;
    public TMP_Text[] Sub_Text;
    public TMP_Text[] CTAText;
    public GameObject[] TextBox;
    //public int nTourImages=0;
    //public Image[] TourImages;
    public  AudioSource audioSource, audioSource1;
    private bool buttonClicked = false;
    private bool PreviousButtonClicked = false;
    public Image HeadinLine;
    public Button NextBtn;
    public Button PreviousBtn;
    public Image[] PartnerImg;
    public Image[] DellSolutionImg;
    public GameObject CTAHexa;
    public TMP_Text Partner1;
    public TMP_Text Partner2;
    public TMP_Text Partner3;
    public GameObject FadeIn;
    public GameObject FadeOut;
    // public GameObject outcomebtn;
    //public GameObject BB;
    //public GameObject DVSBtn;
    public bool StopTour = false;
    int indexForlists;
    public string Assets_Folder;
    //    public GameObject Videoplayer;
    public int screenWidth;
    public int screenHeight;
    public GameObject Factory;
    public GameObject playbtn, pausebtn;
    public GameObject BG_Music, Tour_Music;
    public GameObject Mute, Unmute;
    public GameObject NextPreviousBtn;

    private void Awake()
    {
        Assets_Folder = "https://dell-unity-dev.s3-accelerate.amazonaws.com/FactoryAssetsDev/";
        StartCoroutine(LoadXML());
        instance = this;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        

    }
    

     void Start()
    {
        NextBtn.onClick.AddListener(OnButtonClick);
        //StartCoroutine(OutcomeAudioLoader());
        //StartCoroutine(LoadaudioHotspotIntros());
        //StartCoroutine(LoadUseCaseIntros());
        //StartCoroutine(LoadMusicBg());

        audioSource = GetComponent<AudioSource>();
        Debug.Log("Screen width"+screenWidth+"X"+screenHeight);
        //if (screenWidth <= 480)
        //{
        //    Factory.transform.rotation = Quaternion.Euler(0f, -110f, 0f);
        //}

    }
    IEnumerator LoadXML()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "AssetsLocation.xml");

        UnityWebRequest www = UnityWebRequest.Get(filePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError("Error loading XML: " + www.error);
        }
        else
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.downloadHandler.text);
            XmlNode node = xmlDoc.SelectSingleNode("fp");
            Assets_Folder = node.InnerText.ToString();
        }
       // yield return new WaitForSeconds();
            StartCoroutine(OutcomeAudioLoader());
        StartCoroutine(LoadaudioHotspotIntros());
        StartCoroutine(LoadUseCaseIntros());
        StartCoroutine(LoadMusicBg());
    }
    public void OnButtonClick()
    {
        buttonClicked = true;
    }

    public void PreviousButton()
    {
        PreviousButtonClicked = true;
    }
    public void soundon()
    {
        Mute.SetActive(true);
        Unmute.SetActive(false);
        PlayerPrefs.SetInt("MusicOn", 1);
        AudioListener.volume = 1f;

        //if (VideoLoader.instance.VideoIsRunning)
        //{
        //    VideoLoader.instance.videoPlayer.SetDirectAudioMute(0, false);
        //}
    }
    public void soundoff()
    {
        Mute.SetActive(false);
        Unmute.SetActive(true);
        PlayerPrefs.SetInt("MusicOn", 0);
        AudioListener.volume = 0f;
        //if (VideoLoader.instance.VideoIsRunning)
        //{
        //    VideoLoader.instance.videoPlayer.SetDirectAudioMute(0, true);
        //}
       

    }
    public void Update()
    {
        if (ImageToggleOnHover.Tour_Running == false)
        {
            BG_Music.SetActive(true);
            Tour_Music.SetActive(false);
        }
        else
        {
            BG_Music.SetActive(false);
            Tour_Music.SetActive(true);
        }


    }
    public bool checkpressed;
    public void playbtnfunction()
    {
        if (ImageToggleOnHover.Tour_Running == true||BackCardData.instance.HotSpotsRuninng==true)
        {
            if (checkpressed == false)
            {

                pausebtn.SetActive(false);
                playbtn.SetActive(true);
                Time.timeScale = 0f;
                checkpressed = true;
                audioSource.Pause();
                audioSource1.Pause();
            }
            else
            {
                pausebtn.SetActive(true);
                playbtn.SetActive(false);
                Time.timeScale = 1f;
                checkpressed = false;
                audioSource.Play();
                audioSource1.Play();
            }
        }
    }
    //public IEnumerator LoadaudioHotspots()
    //{

    //    for (int i = 1; i <= 14; i++)
    //    {
    //        //am get from hotspot 
    //        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/uc" + i + "/1.mp3", AudioType.MPEG))
    //        {
    //            yield return www.SendWebRequest();

    //            if (www.result == UnityWebRequest.Result.Success)
    //            {
    //                HotSpotAudio[i - 1] = DownloadHandlerAudioClip.GetContent(www);
    //                // audioSources.Play();
    //            }
    //            else
    //            {
    //                // Debug.LogError("Failed to download audio: " + www.error);
    //            }
    //        }
    //    }

    //}
    public IEnumerator LoadaudioHotspotIntros()
    {

        for (int i = 1; i <= 14; i++)
        {
            //am get from hotspot 
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/uc" + i + "/2.mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    HotSpotAudioIntro[i - 1] = DownloadHandlerAudioClip.GetContent(www);
                   // HotSpotTextIntro[i - 1].text = "Use Case Details " + i.ToString();
                }
                else
                {
                    // Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }

    }
    public IEnumerator LoadUseCaseIntros()
    {
        url = Assets_Folder + "cards/usecases.xml";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string fileContent = www.downloadHandler.text;
            ProcessFileContent(fileContent);
        }

    }
    public void ProcessFileContent(string content)
    {

        using (TextReader textReader = new StringReader(content))
        {
            using (XmlReader reader = XmlReader.Create(textReader))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "uc1":
                                HotSpotTextIntro[0] = reader.ReadString();
                                break;

                            case "uc2":
                                HotSpotTextIntro[1] = reader.ReadString();
                                break;

                            case "uc3":
                                HotSpotTextIntro[2] = reader.ReadString();
                                break;
                            case "uc4":
                                HotSpotTextIntro[3] = reader.ReadString();
                                break;
                            case "uc5":
                                HotSpotTextIntro[4] = reader.ReadString();
                                break;
                            case "uc6":
                                HotSpotTextIntro[5] = reader.ReadString();
                                break;
                            case "uc7":
                                HotSpotTextIntro[6] = reader.ReadString();
                                break;
                            case "uc8":
                                HotSpotTextIntro[7] = reader.ReadString();
                                break;
                            case "uc9":
                                HotSpotTextIntro[8] = reader.ReadString();
                                break;
                            case "uc10":
                                HotSpotTextIntro[9] = reader.ReadString();
                                break;
                            case "uc11":
                                HotSpotTextIntro[10] = reader.ReadString();
                                break;
                            case "uc12":
                                HotSpotTextIntro[11] = reader.ReadString();
                                break;
                            case "uc13":
                                HotSpotTextIntro[12] = reader.ReadString();
                                break;
                        }

                    }
                }
            }

        }
        //StartCoroutine(LoadTourImages());
    }
    public IEnumerator OutcomeAudioLoader()
    {

        for (int i = 1; i <= 7; i++)
        {
            //am get from hotspot 
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/outcomes/" + i + ".mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    OutcomeAudioIntro[i - 1] = DownloadHandlerAudioClip.GetContent(www);
                    // audioSources.Play();
                }
                else
                {
                    // Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }

    }

    public IEnumerator Loadaudio()
    {
        //AudioClipsLoaded = 0;
        for (int i = 0; i <= 36; i++)
        {
            //am get from hotspot 
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/" + ImageToggleOnHover.UseCase + "/" + i + ".mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    audioClips[i - 1] = DownloadHandlerAudioClip.GetContent(www);
                    //AudioClipsLoaded++;
                    // audioSources.Play();
                }
                else
                {
                    // Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }

    }
    public IEnumerator LoadMusicBg()
    {
        //AudioClipsLoaded = 0;
        
            //am get from hotspot 
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/BGM.mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                AudioClip musicClip = DownloadHandlerAudioClip.GetContent(www);
                BgMusic.clip = musicClip;
                BgMusic.Play();
            }
                else
                {
                    // Debug.LogError("Failed to download audio: " + www.error);
                }
           
        }
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/TourMusic.mp3", AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioClip musicClip = DownloadHandlerAudioClip.GetContent(www);
                TourMusic.clip = musicClip;
                TourMusic.Play();
                //AudioClipsLoaded++;
                // audioSources.Play();
            }
            else
            {
                // Debug.LogError("Failed to download audio: " + www.error);
            }

        }

    }
    public float audiolength;
    public bool TourStart;
    public void PlayGuidedTour(string UseCase)
    {
        
        myCoroutine = PlayAudioClips();
        StartCoroutine(myCoroutine);
        TourStart = true;

    }
   public  void StopCoroutine()
    {
       
            for (int i = 0; i < 5; i++)
            {
                PartnerImg[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 3; i++)
            {
                DellSolutionImg[i].gameObject.SetActive(false);
            }
           if (TourStart)
            {
            StopCoroutine(myCoroutine);
            TourStart = false;
            }
            FadeIn.SetActive(false);
            FadeOut.SetActive(false);
            UnClickMenu.SetActive(false);
            card.SetActive(false);
            ImageToggleOnHover.Tour_Running = false;
            bInterrupted = true;
            pausebtn.SetActive(true);
            playbtn.SetActive(false);
            dellvideopanel.SetActive(false);
            Time.timeScale = 1f;
            checkpressed = false;
            audioSource.Stop();
     



    }
    public bool bInterrupted=false;
    public int AudioClipsLoaded;
    public GameObject UnClickMenu;
    public GameObject videoplayer;
    IEnumerator myCoroutine;
    public IEnumerator PlayAudioClips()
    {

    Intro_Start:
     
       // BackCardData.instance.BusinessOutcomeWindow.SetActive(false);
        HexagonBlank();
        for (int i = 0; i <= 2; i++)
        {
            CTAText[i].text = null;
        }
        videoplayer.SetActive(true);
        FadeIn.SetActive(true);
        bInterrupted = false;
        ResetTourTextBox();
        //ResetTourImages();
        float StandardDelay = 0f;
        //StartCoroutine(LoadImgWithUrl(Assets_Folder + "image/xmpro-logo.png"));
        // Turn on Introduction audio
        //Intro audio Play
        yield return new WaitForSeconds(0.5f);
        audioSource.clip = audioClips[0];
        audiolength = audioClips[0].length;
        audioSource.Play();
        yield return new WaitForSeconds(audiolength);
        audioSource.clip = audioClips[0];
        audiolength = audioClips[0].length;
        audioSource.Play();
        yield return new WaitForSeconds(audiolength);
        //ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.VPInnerColor;
        //ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.VPMiddleColor;
        //ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.VPOuterColor;

        //  hexaTxt.SetActive(true);



        string usecasenum = ImageToggleOnHover.UseCase;
        string EndNumber = usecasenum.Substring(2, usecasenum.Length - 2);
        audioClips[1] = HotSpotAudioIntro[int.Parse(EndNumber) - 1];
        
       
        card.SetActive(true);
        
        if (SaveDataFromXML.ins.IntroVideo != "")
        {
            string url = SaveDataFromXML.ins.IntroVideo;
            VideoLoader.instance.videoplay(url);
        }
        hexaTxt[0].text = saveDataFile.INTRO[0];
        Hexagon.SetActive(true);
        
        //hexaTxt[0].color = ImageLoader.instance.HeadingColor2;
        //Hexagon.GetComponent<Image>().color = ImageLoader.instance.BackColor2;
        //HeadinLine.color = ImageLoader.instance.HeadingColor2;
        for (int i = 1; i <= saveDataFile.IntroEndIndx; i++)
        {
           // ResetTourImages();

            hexaTxt[i].text = saveDataFile.INTRO[i];
            Sub_Text[i].text = saveDataFile.Sub_INTRO[i - 1];
            TextBox[i].SetActive(true);

        }
        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            for (int i = 1; i <= saveDataFile.IntroEndIndx; i++)
            {
                audioSource.clip = audioClips[i];
                audiolength = audioClips[i].length;
                audioSource.Play();

                yield return new WaitForSeconds(audiolength + StandardDelay);

                //card.SetActive(false);


            }
        }
        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked||PreviousButtonClicked))
        {
            yield return null;
        }
        
        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto Intro_Start;
        }
        buttonClicked = false;
    EC_Start:
        if (SaveDataFromXML.ins.IntroVideo != SaveDataFromXML.ins.ECVideo)
        {
            videoplayer.SetActive(false);
            if (SaveDataFromXML.ins.ECVideo != "")
            {
                string url = SaveDataFromXML.ins.ECVideo;
                VideoLoader.instance.videoplay(url);
            }
        }
      
        //Hexagon.SetActive(false); 
        //card.SetActive(false);
        ResetTourTextBox();
        //ResetTourImages();
        yield return new WaitForSeconds(StandardDelay);
        // for(int i=0;i<)
        //// Turn on Partner Solution audio & image


        //yield return new WaitForSeconds(4f);
        //Image.gameObject.SetActive(false);

        //EC Audio with nothing on screen

        //audioSource.clip = audioClips[9];
        //audiolength = audioClips[9].length;
        //audioSource.Play();
        //yield return new WaitForSeconds(audiolength + StandardDelay);
        // StartCoroutine(LoadImgWithUrl(Assets_Folder + "image/xmpro-dashboard.png"));
        //Show Edge Chanllenges Text with audio
        //for (int i = 1; i <= saveDataFile.ECEndIndx; i++)
        //{

        //    ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.ECInnerColor;
        //    ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.ECMiddleColor;
        //    ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.ECOuterColor; 
        //    card.SetActive(true);
        //    hexaTxt.SetActive(true);
        //    Hexagon.SetActive(true);
        //    HexagonCardtext.text = saveDataFile.EC[i - 1];
        //    //Audio will be played
        //    // audioSource.Play();

        //    //EC Audio with 3 & 4
        //    audioSource.clip = audioClips[i + 8];
        //    audiolength = audioClips[i + 8].length;
        //    audioSource.Play();

        //    yield return new WaitForSeconds(audiolength + StandardDelay);
        //    card.SetActive(false);

        //}
        HexagonBlank();
        //ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.ECInnerColor;
        //ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.ECMiddleColor;
        //ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.ECOuterColor;

       // hexaTxt.SetActive(true);
        Hexagon.SetActive(true);
        //hexaTxt[0].color = ImageLoader.instance.HeadingColor1;
        //Hexagon.GetComponent<Image>().color = ImageLoader.instance.BackColor1;
        //HeadinLine.color = ImageLoader.instance.HeadingColor1;
        videoplayer.SetActive(true);
        for (int i = 1; i <= saveDataFile.ECEndIndx; i++)
        {
          //  ResetTourImages();
            card.SetActive(true);
            hexaTxt[i - 1].text = saveDataFile.EC[i - 1];
            Sub_Text[i - 1].text = saveDataFile.Sub_EC[i - 1];
            TextBox[i - 1].SetActive(true);
           
        

        }
        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            for (int i = 1; i <= saveDataFile.ECEndIndx; i++)
            {


                //EC Audio with 3 & 4
                audioSource.clip = audioClips[i + 8];
                audiolength = audioClips[i + 8].length;
                audioSource.Play();

                if (i == 1)
                {
                    yield return new WaitForSeconds(audiolength);
                }
                else
                {
                    yield return new WaitForSeconds(audiolength + StandardDelay);
                }

            }
        }
        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked || PreviousButtonClicked))
        {
            yield return null;
        }
        videoplayer.SetActive(false);
        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto Intro_Start;
        }
        buttonClicked = false;

        DS_Start:
        
        ResetTourTextBox();
       // ResetTourImages();
        yield return new WaitForSeconds(StandardDelay);
        hexaTxt[0].text = "Dell Solutions";
        ////Show Dell Edge Solution Audio And Text
        ///

        for (int i = 1; i <= saveDataFile.HARDWAREEndIndx; i++)
        {
            card.SetActive(true);
            Hexagon.SetActive(true);
            //hexaTxt[i].color = ImageLoader.instance.TextColor1;
            hexaTxt[i].text = ImageLoader.instance.DS[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1];
            // hexaTxt[i].text = Load_Tour_text.ins.DellDescription[i - 1];
            Sub_Text[i].text = saveDataFile.Sub_HARDWARE[i - 1];
            TextBox[i].SetActive(true);
          

        }
        ValuePillarsWindow.SetActive(true);
        for (int i = 1; i <=3; i++)
        {
            //hexaTxt[i].color = ImageLoader.instance.TextColor2;
            ValuePillarsText[i-1].text = saveDataFile.TT[i - 1];

        }

     
        for (int i =1; i <= saveDataFile.HARDWAREEndIndx; i++)
        {
            DellSolutionImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(true);
            //HexagonCardtext.text = saveDataFile.DES[i - 1];
            //hexaTxt.SetActive(false);
            //Hexagon.SetActive(false);
            //  Image.gameObject.SetActive(true);
            
            //Audio will be played
            //  audioSource.Play();

            audioSource.clip = audioClips[i + 13];
            audiolength = audioClips[i + 13].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength + StandardDelay);
            //card.SetActive(false);
            //  Image.gameObject.SetActive(false);
            if (i == saveDataFile.HARDWAREEndIndx)
            {


            }
            else
            {
                DellSolutionImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(false);
            }
            

        }
        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            for (int i = 1; i <= saveDataFile.TTEndIndx; i++)
            {
                audioSource.clip = audioClips[i + 18];
                audiolength = audioClips[i + 18].length;
                audioSource.Play();
                if (i == 1)
                {
                    yield return new WaitForSeconds(audiolength);
                }
                else
                {
                    yield return new WaitForSeconds(audiolength + StandardDelay);
                }
            }
        }
        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked || PreviousButtonClicked))
        {
            yield return null;
        }

        DellSolutionImg[int.Parse(SaveDataFromXML.ins.HARDWARE[(saveDataFile.HARDWAREEndIndx) - 1]) - 1].gameObject.SetActive(false);
        ValuePillarsWindow.SetActive(false);
        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto EC_Start;
        }
        buttonClicked = false;
        
    //// card.SetActive(false);
    // card.SetActive(true);
    // //HexagonCardtext.text = saveDataFile.DES[i - 1];
    // hexaTxt.SetActive(false);
    // Hexagon.SetActive(false);
    // Image.gameObject.SetActive(true);
    // //TT Audio with nothing on screen
    // audioSource.clip = audioClips[6];
    // audioSource.Play();
    // yield return new WaitForSeconds(4f);
    // card.SetActive(false);
    // yield return new WaitForSeconds(1f);
    //Show Trasformation Themes Audio And Text

    //TT_Start:
    //yield return new WaitForSeconds(StandardDelay);
    //HexagonBlank();
    ////ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.VPInnerColor;
    ////ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.VPMiddleColor;
    ////ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.VPOuterColor;
    //card.SetActive(true);
    //ResetTourTextBox();
    //ResetTourImages();
    //hexaTxt[0].text = "Value to Manufacturers";
    //hexaTxt[0].color = ImageLoader.instance.HeadingColor2;
    //Hexagon.GetComponent<Image>().color = ImageLoader.instance.BackColor2;
    //HeadinLine.color = ImageLoader.instance.HeadingColor2;
    // hexaTxt.SetActive(true);
    //ValuePillarsWindow.SetActive(true);

    //for (int i = 1; i <= saveDataFile.TTEndIndx; i++)
    //{
    //    //hexaTxt[i].color = ImageLoader.instance.TextColor2;
    //    ValuePillarsText[i].text = saveDataFile.TT[i - 1];

    //}

    //for (int i = 1; i <= saveDataFile.TTEndIndx; i++)
    //{
    //    audioSource.clip = audioClips[i + 18];
    //    audiolength = audioClips[i + 18].length;
    //    audioSource.Play();
    //    if (i == 1)
    //    {
    //        yield return new WaitForSeconds(audiolength);
    //    }
    //    else
    //    {
    //        yield return new WaitForSeconds(audiolength + StandardDelay);
    //    }
    //}

    //NextPreviousBtn.SetActive(true);
    //while (!(buttonClicked || PreviousButtonClicked))
    //{
    //    yield return null;
    //}
    //if (PreviousButtonClicked)
    //{
    //    PreviousButtonClicked = false;
    //    goto DS_Start;
    //}
    //buttonClicked = false;

    PS_Start:
       
        ResetTourTextBox();
        //ResetTourImages();
        // card.SetActive(false);

        ////Show Hardware Audio And IMage
        //for (int i = saveDataFile.HARDWAREStartIndx; i < saveDataFile.HARDWAREEndIndx; i++)
        //{
        //    //StartCoroutine(LoadImgWithUrl(saveDataFile.HARDWARE[i]));
        //    Image.gameObject.SetActive(true);
        //    hexaTxt.SetActive(false);
        //    Hexagon.SetActive(false);
        //    //  audioSource.Play();
        //    audioSource.clip = audioClips[i + 7];
        //    audioSource.Play();
        //    //audioSource.clip = audioClips[1];
        //    //audioSource.Play();

        //    yield return new WaitForSeconds(4f);
        //    Image.gameObject.SetActive(false);
        //    yield return new WaitForSeconds(1f);
        //}
        //hexaTxt.SetActive(true);
        //Hexagon.SetActive(true);
        yield return new WaitForSeconds(StandardDelay);
        ResetTourTextBox();
       // ResetTourImages();
        hexaTxt[0].text = "Validated Partners";
        if (saveDataFile.PSEndIndx > 0)
        {

            for (int i = 1; i <= saveDataFile.PSEndIndx + 1; i++)
            {
                card.SetActive(true);
                Hexagon.SetActive(true);
                //hexaTxt[i].color = ImageLoader.instance.TextColor1;

                TextBox[i].SetActive(true);


                if (i == 1)
                {
                 
                    hexaTxt[i].text = ImageLoader.instance.DS[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1];
                    Sub_Text[i].text = saveDataFile.Sub_PS[i - 1];
                }
                else
                {
                    
                    hexaTxt[i].text = ImageLoader.instance.PS[int.Parse(SaveDataFromXML.ins.PS[i - 2]) - 1];
                    Sub_Text[i].text = saveDataFile.Sub_PS[i - 1];
                }

                //hexaTxt.SetActive(false);
                //Hexagon.SetActive(false);
                // Image.gameObject.SetActive(true);
                // audioSource.Play();
                //audioSource.clip = audioClips[1];
                //audioSource.Play();

            

                //card.SetActive(false);

            }


            for (int i = 1; i <= saveDataFile.PSEndIndx + 1; i++)
            {
           


                if (i == 1)
                {
                    DellSolutionImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(true);
                
                }
                else
                {
                    PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 2]) - 1].gameObject.SetActive(true);
                   
                }

                card.SetActive(true);
                //Partner Solution audio Play
                audioSource.clip = audioClips[i + 3];
                audiolength = audioClips[i + 3].length;
                audioSource.Play();

                //hexaTxt.SetActive(false);
                //Hexagon.SetActive(false);
                // Image.gameObject.SetActive(true);
                // audioSource.Play();
                //audioSource.clip = audioClips[1];
                //audioSource.Play();

                yield return new WaitForSeconds(audiolength + StandardDelay);
                // Image.gameObject.SetActive(false);

                if (i == 1)
                {
                    DellSolutionImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(false);
                }
                else if(i== saveDataFile.PSEndIndx + 1)
                {
                    
                }

                 else
                {
                    PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 2]) - 1].gameObject.SetActive(false);
                }

                //card.SetActive(false);

            }
            NextPreviousBtn.SetActive(true);
            while (!(buttonClicked || PreviousButtonClicked))
            {
                yield return null;
            }
            PartnerImg[int.Parse(SaveDataFromXML.ins.PS[saveDataFile.PSEndIndx + 1 - 2]) - 1].gameObject.SetActive(false);
            if (PreviousButtonClicked)
            {
                PreviousButtonClicked = false;
                goto DS_Start;
            }
            buttonClicked = false;
        }


       
        //FO Audio with 9 with nothing
        //if (bInterrupted)
        //{
        //    bInterrupted = true;
        //    ImageToggleOnHover.Tour_Running = false;

        //    yield return null;
        //}
        //audioSource.clip = audioClips[24];
        //audiolength = audioClips[24].length;
        //audioSource.Play();

        //yield return new WaitForSeconds(audiolength + StandardDelay);
        //Show Factory Outcomes Audio And Text
        yield return new WaitForSeconds(StandardDelay);
        FO_Start:
        HexagonBlank();
        ResetTourTextBox();
       // ResetTourImages();
        //ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.BOInnerColor;
        //ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.BOMiddleColor;
        //ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.BOOuterColor;
        card.SetActive(true);
        // hexaTxt.SetActive(true);
        Hexagon.SetActive(true);
        //hexaTxt[0].color = ImageLoader.instance.HeadingColor1;
        //Hexagon.GetComponent<Image>().color = ImageLoader.instance.BackColor1;
        //HeadinLine.color = ImageLoader.instance.HeadingColor1;

        for (int i = 1; i <= saveDataFile.FOEndIndx; i++)
        {
            //hexaTxt[i].color = ImageLoader.instance.TextColor1;
            hexaTxt[i - 1].text = saveDataFile.FO[i - 1];
            Sub_Text[i - 1].text = saveDataFile.Sub_FO[i - 1];
            TextBox[i - 1].SetActive(true);

        }

        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            for (int i = 1; i <= saveDataFile.FOEndIndx; i++)
            {
                audioSource.clip = audioClips[i + 23];
                audiolength = audioClips[i + 23].length;
                //if (audiolength < 1f)
                //{
                //    audiolength = 1f;
                //}
                audioSource.Play();
                if (i == 1)
                {
                    yield return new WaitForSeconds(audiolength);
                }
                else
                {
                    yield return new WaitForSeconds(audiolength + StandardDelay);
                }

                // card.SetActive(false);

            }
        }
        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked || PreviousButtonClicked))
        {
            yield return null;
        }
        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto PS_Start;
        }
        buttonClicked = false;

        BI_Start:
        //card.SetActive(false);
        ResetTourTextBox();
       // ResetTourImages();
        // hexaTxt.SetActive(true);
        //Hexagon.SetActive(false);
        //if (bInterrupted)
        //{
        //    bInterrupted = true;
        //    ImageToggleOnHover.Tour_Running = false;

        //    yield return null;
        //}
        //yield return new WaitForSeconds(0.5f);
        //////FO Audio with 10 with nothing
        //audioSource.clip = audioClips[29];
        //audiolength = audioClips[29].length;
        //audioSource.Play();
        //yield return new WaitForSeconds(audiolength + StandardDelay);

        //Show Business Impact Audio And Text
        yield return new WaitForSeconds(StandardDelay);
        HexagonBlank();
        //ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.BOInnerColor;
        //ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.BOMiddleColor;
        //ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.BOOuterColor;
        card.SetActive(true);
        //hexaTxt[0].color = ImageLoader.instance.HeadingColor2;
        //Hexagon.GetComponent<Image>().color = ImageLoader.instance.BackColor2;
        //HeadinLine.color = ImageLoader.instance.HeadingColor2;
        //hexaTxt.SetActive(true);
        Hexagon.SetActive(true);

        for (int i = 1; i <= saveDataFile.BIEndIndx; i++)
        {

            //hexaTxt[i].color = ImageLoader.instance.TextColor2;
            hexaTxt[i - 1].text = saveDataFile.BI[i - 1];
            Sub_Text[i - 1].text = saveDataFile.Sub_BI[i - 1];
            TextBox[i - 1].SetActive(true);

        }
        if (PlayerPrefs.GetInt("MusicOn")!=0)
        {
            for (int i = 1; i <= saveDataFile.BIEndIndx; i++)
            {

                audioSource.clip = audioClips[i + 28];
                audiolength = audioClips[i + 28].length;
                audioSource.Play();

                if (i == 1)
                {
                    yield return new WaitForSeconds(audiolength);
                }
                else
                {
                    yield return new WaitForSeconds(audiolength + StandardDelay);
                }

            }
        }
        

        EndVO.Play();
        card.SetActive(false);

        if (saveDataFile.PSEndIndx == 0)
        {
           
        }
        else
        {
            //ImageLoader.instance.HexagonInnerColor.color = ImageLoader.instance.VPInnerColor;
            //ImageLoader.instance.HexagonMiddleColor.color = ImageLoader.instance.VPMiddleColor;
            //ImageLoader.instance.HexagonOuterColor.color = ImageLoader.instance.VPOuterColor;
            CTAHexa.SetActive(true);
            Partner1.text = ImageLoader.instance.PS[int.Parse(SaveDataFromXML.ins.PS[0]) - 1];
            
            // PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 1]) - 1].gameObject.SetActive(false);
            if (saveDataFile.PSEndIndx > 1)
            {
                Partner2.text = ImageLoader.instance.PS[int.Parse(SaveDataFromXML.ins.PS[1]) - 1];
            }
            if (saveDataFile.PSEndIndx > 2)
            {
                Partner3.text = ImageLoader.instance.PS[int.Parse(SaveDataFromXML.ins.PS[2]) - 1];
            }
        }
        //audioSource.clip = audioClips[34];
        //audiolength = audioClips[34].length;
        ResetTourTextBox();
       // ResetTourImages();
        card.SetActive(false);
        FadeIn.SetActive(false);
        FadeOut.SetActive(true);
        
        yield return new WaitForSeconds(1f); 
        FadeIn.SetActive(false);
     
        FadeOut.SetActive(false);
        TourStart = false;
        yield return new WaitForSeconds(1f);
        ImageToggleOnHover.Tour_Running = false;
        UnClickMenu.SetActive(false);
        HexagonBlank();
        audioSource.clip = audioClips[0];
        audiolength = audioClips[0].length;
        audioSource.Play();
        yield return new WaitForSeconds(audiolength);
     

    }
    public void ResetTourTextBox()
    {
        NextPreviousBtn.SetActive(false);
        for (int i = 0; i <=4; i++)
        {
            TextBox[i].SetActive(false);
        }
    }
    //public void ResetTourImages()
    //{
    //    for (int i = 0; i <nTourImages; i++)
    //    {
    //        TourImages[i].gameObject.SetActive(false);
    //    }
    //}
    public void CloseCTA()
    {
        ImageToggleOnHover.Tour_Running = false;
    }
    public void ClosedAllWindow()
    {
       
        Time.timeScale = 1;
        BackCardData.instance.DellWindow.SetActive(false);
        BackCardData.instance.PartnerWindow.SetActive(false);
        ImageLoader.instance.BackFlipCard.SetActive(false);
        BackCardData.instance.DellFrontWindow.SetActive(false);
        BackCardData.instance.PartnerFrontWindow.SetActive(false);
        BackCardData.instance.PartnerWindow.SetActive(false);
        BackCardData.instance.DellWindow.SetActive(false);
        ValuePillarsWindow.SetActive(false);
        CTAHexa.SetActive(false);
        BackCardData.instance.OutcomeTextPanel.SetActive(false);
        videoplayer.SetActive(false);
        dellvideopanel.SetActive(false);
        audioSource.clip = null;
     


        for (int i = 0; i <= 6; i++)
        {
            ImageLoader.instance.Cards[i].SetActive(false);
        }
    }
    public void HexagonBlank()
    { 
    for(int i=0;i<=4;i++)
        {
            hexaTxt[i].text = null;
        }
    }
    public void Partner1Function()
    {
        Application.OpenURL(Load_Tour_text.ins.PartnersLink[int.Parse(SaveDataFromXML.ins.PS[0]) - 1]);
    }
    public void Partner2Function()
    {
        Application.OpenURL(Load_Tour_text.ins.PartnersLink[int.Parse(SaveDataFromXML.ins.PS[1]) - 1]);
    }
    public void Partner3Function()
    {
        Application.OpenURL(Load_Tour_text.ins.PartnersLink[int.Parse(SaveDataFromXML.ins.PS[2]) - 1]);
    }
    //public void CloseCTAWindow()
    //{
    //    UnClickMenu.SetActive(false);
    //}
    public void TourBtnAnimation()
    {
        //   LeanTween.scale(outcomebtn, new Vector3(2f, 2f, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine);

        Invoke("TourBtnAnimation1", 2f);
    }
    public void TourBtnAnimation1()
    {
        ///LeanTween.scale(outcomebtn, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    }
    public void TourBtnAnimationBB()
    {
        //LeanTween.scale(BB, new Vector3(2f, 2f, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine);

        Invoke("TourBtnAnimation1BB", 2f);
    }
    public void TourBtnAnimation1BB()
    {
        //LeanTween.scale(BB, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    }
    public void TourBtnAnimationDVS()
    {
        // LeanTween.scale(DVSBtn, new Vector3(2f, 2f, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine);

        Invoke("TourBtnAnimation1DVS", 2f);
    }
    public void TourBtnAnimation1DVS()
    {
        // LeanTween.scale(DVSBtn, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    }


    //public string url;
    //public Image image;

    public IEnumerator LoadImgWithUrlPartners()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 1; i <= 6; i++)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(Load_Tour_text.ins.partners[i - 1]))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(request);

                    // Create a sprite from the texture and assign it to the Image component
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    PartnerImg[i-1].sprite = sprite;
                }
                else
                {
                    Debug.LogError("Image download failed: " + request.error);
                }
            }
        }



    }
    public IEnumerator LoadImgWithUrlDell()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 1; i <= 6; i++)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(Load_Tour_text.ins.Dell[i - 1]))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(request);

                    // Create a sprite from the texture and assign it to the Image component
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    DellSolutionImg[i - 1].sprite = sprite;
                }
                else
                {
                    Debug.LogError("Image download failed: " + request.error);
                }
            }
        }



    }
}