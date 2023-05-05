using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System.IO;
using System.Xml;
using UnityEngine.SceneManagement;

public class Guided_Tour : MonoBehaviour
{
    public TextMeshProUGUI[] TourText;
    public TextMeshProUGUI[] Sub_Text;
    public AudioClip[] audioClips;
    public float TotalPlayTime = 4f;
    public GameObject card;
    private AudioSource audioSource;
    private int currentClipIndex = 0;
    public GameObject outcomebtn;
    public GameObject BB;
    public GameObject DVSBtn;
    public bool StopTour=false;
    public GameObject Videoplayer;
    public VideoPlayer Video;
    public PlayableDirector timeline;
    public string Assets_Folder;
    public static Guided_Tour instance;
    private bool PreviousButtonClicked = false;
    private bool buttonClicked = false;
    public GameObject NextPreviousBtn;
    public GameObject[] TextBox;

    public void Awake()
    {
        instance = this;
       // Assets_Folder = "https://dell-unity-dev.s3-accelerate.amazonaws.com/Assets/";
       // StartCoroutine(LoadXML());
    }
    void Start()
    {
        StartCoroutine(Loadaudio());
        audioSource = GetComponent<AudioSource>();
    }
    //IEnumerator LoadXML()
    //{
    //    string filePath = Path.Combine(Application.streamingAssetsPath, "AssetsLocation.xml");

    //    UnityWebRequest www = UnityWebRequest.Get(filePath);
    //    yield return www.SendWebRequest();

    //    if (www.result == UnityWebRequest.Result.ConnectionError)
    //    {
    //        Debug.LogError("Error loading XML: " + www.error);
    //    }
    //    else
    //    {
    //        XmlDocument xmlDoc = new XmlDocument();
    //        xmlDoc.LoadXml(www.downloadHandler.text);
    //        XmlNode node = xmlDoc.SelectSingleNode("fp");
    //        Assets_Folder = node.InnerText.ToString();
    //    }
  
    //}
    public void ResetTourTextBox()
    {
        NextPreviousBtn.SetActive(false);
        for (int i = 0; i <= 5; i++)
        {
            TextBox[i].SetActive(false);
        }
    }
    public void OnButtonClick()
    {
        buttonClicked = true;
    }

    public void PreviousButton()
    {
        PreviousButtonClicked = true;
    }
    public bool checkpressed;
    public GameObject playbtn, pausebtn, stopbtn;
    public void playbtnfunction()
    {
        if (Hower_Active.Howeractive == false)
        {
            GUI_Control.instance.isOpenvideo = false;
            if (checkpressed == false)
            {

                timeline.playableGraph.GetRootPlayable(0).SetSpeed(0);
                pausebtn.SetActive(false);
                playbtn.SetActive(true);
                Time.timeScale = 0f;
                checkpressed = true;
                audioSource.Pause();
                
            }
            else 
            {
                timeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
                pausebtn.SetActive(true);
                playbtn.SetActive(false);
                Time.timeScale = 1f;
                checkpressed = false;
                audioSource.Play();
                
            }
        }
        if (GuidedTourRunning == true)
             {
            GUI_Control.instance.isOpenvideo = false;
            if (checkpressed == false)
            {
                   
                pausebtn.SetActive(false);
                playbtn.SetActive(true);
                Time.timeScale = 0f;
                checkpressed = true;
                audioSource.Pause();
                Video.Pause();
                //audioSource1.Pause();
            }
            else
            {
               
                pausebtn.SetActive(true);
                playbtn.SetActive(false);
                Time.timeScale = 1f;
                checkpressed = false;
                audioSource.Play();
                Video.Play();
                // audioSource1.Play();
            }

        }
        if (GUI_Control.instance.isOpenvideo)
        {
            if (checkpressed == false)
            {
                pausebtn.SetActive(false);
                playbtn.SetActive(true);
                Time.timeScale = 0f;
                checkpressed = true;
                audioSource.Pause();
                Video.Pause();
            }
            else
            {
                pausebtn.SetActive(true);
                playbtn.SetActive(false);
                Time.timeScale = 1f;
                checkpressed = false;
                audioSource.Play();
                Video.Play();
            }
        }
        }
    IEnumerator Loadaudio()
    {

        for (int i = 1; i <= 15; i++)
        {

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("https://dell-unity-dev.s3-accelerate.amazonaws.com/Assets/audio/edge/" + Module_Name.ModuleName+"_Tour"+i+".mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    audioClips[i - 1] = DownloadHandlerAudioClip.GetContent(www);
                   // audioSources.Play();
                }
                else
                {
                    Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }

    }
    public GameObject DellBtnAnim, OutBtmAnim, BBBtnAnim,TakeTourBtn;
    
    public bool GuidedTourRunning = false;
    public void PlayGuidedTour()
    {
        GuidedTourRunning = true;
        // StartCoroutine(PlayAudioClips());
        myCoroutine = PlayAudioClips();
        StartCoroutine(myCoroutine);

    }
    public GameObject TimelineEnd;
    public GameObject guidetourpannel;
    public void StopCoroutine()
    {
        if (Hower_Active.Howeractive == true)
        {
            try
            {
                StopCoroutine(myCoroutine);
            }
            catch
            { 
            
            }


           
        }
        if (Hower_Active.Howeractive == false)
        {
           
            TakeTourBtn.SetActive(false);
            Hower_Active.ins.waitoff();
            TimelineEnd.SetActive(false);
            guidetourpannel.GetComponent<Image>().enabled=false;

        }
        bInterrupted = true;
        DellBtnAnim.SetActive(false);
        OutBtmAnim.SetActive(false);
        BBBtnAnim.SetActive(false);
        audioSource.Stop();
        card.SetActive(false);
        Videoplayer.SetActive(false);
        GuidedTourRunning = false;


    }
    public void stoptour()
    {

    }
    public bool bInterrupted = false;
    IEnumerator myCoroutine;
    public  IEnumerator PlayAudioClips()
    {
        float audiolength;
        CloseAllWindow();
        ResetTourText();
        yield return new WaitForSeconds(1f);
        float standarddelay = 0.25f;
        Intro_Start:
        ResetTourTextBox();
        audioSource.clip = audioClips[0];
        audiolength = audioClips[0].length;
        audioSource.Play();
        card.SetActive(true);
        TourText[0].text = Load_Tour_text.ins.Intro[0].ToString();
        for (int i = 2; i <= 6; i++)
        {

            TourText[i - 1].text = Load_Tour_text.ins.Intro[i - 1].ToString();
            Sub_Text[i - 2].text = Load_Tour_text.ins.sub_Intro[i - 1].ToString();
            if (TourText[i - 1].text != "")
            {
                TextBox[i - 1].SetActive(true);
            }
            

        }
        
       
    
        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            audioSource.clip = audioClips[1];
            audiolength = audioClips[1].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength);
        }
         
        card.SetActive(true);

        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked || PreviousButtonClicked))
        {
            yield return null;
        }

        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto Intro_Start;
        }
        buttonClicked = false;


    Outcome_Start:
        ResetTourText();
        ResetTourTextBox();
        TourText[0].text = Load_Tour_text.ins.OutcomeIntro.ToString();
        OutBtmAnim.SetActive(true);
       // TourBtnAnimation();
        card.SetActive(true);
       // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
       // yield return new WaitForSeconds(4f);
        for (int i = 2; i <= 6; i++)
        {
           
            TourText[i - 1].text = Load_Tour_text.ins.OutcomeCardFace[i - 2].ToString();
            Sub_Text[i - 2].text = Load_Tour_text.ins.Sub_Outcome[i - 2].ToString();
            if (TourText[i - 1].text != "")
            {
                TextBox[i - 1].SetActive(true);
            }
            OutBtmAnim.SetActive(false);
            // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));

        }

        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            for (int i = 2; i <= 6; i++)
            {
                if (bInterrupted)
                {
                    yield return null;
                }
                card.SetActive(true);
                //StartCoroutine(LoadTourtext.ins.Tour_Text("Outcome"+(i-1)));
                //  TourText[i-1].text = Load_Tour_text.ins.OutcomeCardFace[i - 2].ToString();
                //LoadTourtext.ins.Front.text = LoadTourtext.ins.CardFace[1][i-2].ToString();
                audioSource.clip = audioClips[i];
                audiolength = audioClips[i].length;
                audioSource.Play();
                //GetOutcome_Text("Outcome1");

                yield return new WaitForSeconds(audiolength+ standarddelay);
                OutBtmAnim.SetActive(false);
            }
        }
       // card.SetActive(false);
        // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));

        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked || PreviousButtonClicked))
        {
            yield return null;
        }

        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto Intro_Start;
        }
        buttonClicked = false;

    BB_Start:
        ResetTourText();
        ResetTourTextBox();
        //card.SetActive(false);
       
        BBBtnAnim.SetActive(true);
      
        card.SetActive(true);
        TourText[0].text = Load_Tour_text.ins.BBIntro.ToString();
        BBBtnAnim.SetActive(true);
       // TourBtnAnimationBB();
        
        if (bInterrupted)
        {
            yield return null;
        }
        card.SetActive(true);
        for (int i = 8; i <= 12; i++)
        {

            // StartCoroutine(LoadTourtext.ins.Tour_Text("BB" + (i - 7)));
            TourText[i - 7].text = Load_Tour_text.ins.BBCardFace[i - 8].ToString();
            Sub_Text[i - 8].text = Load_Tour_text.ins.sub_BB[i - 8].ToString();
            if (TourText[i - 7].text != "")
            {
                TextBox[i - 7].SetActive(true);
            }
            BBBtnAnim.SetActive(false);
        }

        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            audioSource.clip = audioClips[7];
            audiolength = audioClips[7].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength + 0.5f);
            for (int i = 8; i <= 12; i++)
            {
                if (bInterrupted)
                {
                    yield return null;
                }
                audioSource.clip = audioClips[i];
                audiolength = audioClips[i].length;
                audioSource.Play();
                // StartCoroutine(LoadTourtext.ins.Tour_Text("BB" + (i - 7)));
                // TourText[i-7].text = Load_Tour_text.ins.BBCardFace[i - 8].ToString();
                //  card.SetActive(true);
                yield return new WaitForSeconds(audiolength+ standarddelay);
                // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));

                BBBtnAnim.SetActive(false);
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
            goto Outcome_Start;
        }
        buttonClicked = false;

    DVS_Start:
        ResetTourText();
        //card.SetActive(false);
       
        DellBtnAnim.SetActive(true);
       // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
        
        card.SetActive(true);
        TourText[0].text = Load_Tour_text.ins.DVSIntro.ToString();
        if (bInterrupted)
        {
            yield return null;
        }
        card.SetActive(true);
        // TourBtnAnimationDVS();
        for (int i = 1; i <= 5; i++)
        {
            if (bInterrupted)
            {
                yield return null;
            }
            //StartCoroutine(LoadTourtext.ins.Tour_Text("DVS" + (i)));
            TourText[i].text = Load_Tour_text.ins.DVSCardFace[i - 1].ToString();
            Sub_Text[i-1].text = Load_Tour_text.ins.sub_DVS[i - 1].ToString();
            if (TourText[i].text != "")
            {
                TextBox[i - 1].SetActive(true);
            }

            // yield return new WaitForSeconds(1.5f);

            // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));

            // yield return new WaitForSeconds(1.5f);
            DellBtnAnim.SetActive(false);
        }

        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            audioSource.clip = audioClips[13];
            audiolength = audioClips[13].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength);
        }

        NextPreviousBtn.SetActive(true);
        while (!(buttonClicked || PreviousButtonClicked))
        {
            yield return null;
        }

        if (PreviousButtonClicked)
        {
            PreviousButtonClicked = false;
            goto BB_Start;
        }
        buttonClicked = false;

        ResetTourText();
        ResetTourTextBox();
        //card.SetActive(false);
        if (PlayerPrefs.GetInt("MusicOn") != 0)
        {
            audioSource.clip = audioClips[14];
            audiolength = audioClips[14].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength);
        }
        card.SetActive(true);
        TourText[0].text = Load_Tour_text.ins.Ending[0].ToString();
        for (int i = 2; i <= 6; i++)
        {

            TourText[i - 1].text = Load_Tour_text.ins.Intro[i - 1].ToString();
            Sub_Text[i - 2].text = Load_Tour_text.ins.sub_Intro[i - 1].ToString();
            if (TourText[i - 1].text != "")
            {
                TextBox[i - 1].SetActive(true);
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
            goto DVS_Start;
        }
        buttonClicked = false;
        Videoplayer.SetActive(true);
        //card.SetActive(false);
        Hower_Active.Howeractive = true;
        CloseAllWindow();
     

       

    }
    public void CloseAllWindow()
    {
        card.SetActive(false);
        GUI_Control.instance.DellSolutionPanel.SetActive(false);
        GUI_Control.instance.DellDetailWindow.SetActive(false);
        GUI_Control.instance.RotatingComponent.SetActive(false);
        GUI_Control.instance.FlipBtn.SetActive(false);
        ImageLoader.instance.BackFlipCard.SetActive(false);
        GUI_Control.instance.video.SetActive(false);
        try
        {
            DetectCard.instance.ResetFlip();
        }
        catch
        { 
        }
        for (int i = 1; i <= 5; i++)
        {
            ImageLoader.instance.NewCard[i - 1].SetActive(false);
         
        }
    }
    public void ResetTourText()
    { 
    //for(int i=0;i<=5;i++)
    //    {
    //        TourText[i].text = null;

    //    }
    }

    //public void TourBtnAnimation()
    //{
    //    LeanTween.scale(outcomebtn, new Vector3(2f, 2f, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    //    Invoke("TourBtnAnimation1",2f);
    //}
    //public void TourBtnAnimation1()
    //{
    //  LeanTween.scale(outcomebtn, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    //}
    //public void TourBtnAnimationBB()
    //{
    //    LeanTween.scale(BB, new Vector3(2f, 2f, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    //    Invoke("TourBtnAnimation1BB", 2f);
    //}
    //public void TourBtnAnimation1BB()
    //{
    //    LeanTween.scale(BB, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    //}
    //public void TourBtnAnimationDVS()
    //{
    //    LeanTween.scale(DVSBtn, new Vector3(2f, 2f, 2f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    //    Invoke("TourBtnAnimation1DVS", 2f);
    //}
    //public void TourBtnAnimation1DVS()
    //{
    //    LeanTween.scale(DVSBtn, new Vector3(1f, 1f, 1f), 0.5f).setEase(LeanTweenType.easeInOutSine);

    //}

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }



}