using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Video;
public class Guided_Tour : MonoBehaviour
{
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
    void Start()
    {
        StartCoroutine(Loadaudio());
        audioSource = GetComponent<AudioSource>();
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

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("https://dell-unity-dev.s3-accelerate.amazonaws.com/Assets/audio/edge/" + Module_Name.instance.ModuleName+"_Tour"+i+".mp3", AudioType.MPEG))
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
            StopCoroutine(myCoroutine);
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
        GUI_Control.instance.RotatingComponent.SetActive(false);
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
       // bInterrupted = false;
        if (bInterrupted)
        {
            yield return null;
        }
        audioSource.clip = audioClips[0];
        audioSource.Play();
        card.SetActive(true);
        Load_Tour_text.ins.Front.text = Load_Tour_text.ins.Intro.ToString();
        yield return new WaitForSeconds(5.5f);
        card.SetActive(false);
        audioSource.clip = audioClips[1];
        audioSource.Play();
        card.SetActive(true);
        Load_Tour_text.ins.Front.text = Load_Tour_text.ins.OutcomeIntro.ToString();
        OutBtmAnim.SetActive(true);
       // TourBtnAnimation();
        card.SetActive(true);
       // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
        yield return new WaitForSeconds(4f);
        
        for (int i = 2; i <= 6; i++)
        {
            if (bInterrupted)
            {
                yield return null;
            }
            card.SetActive(true);
            //StartCoroutine(LoadTourtext.ins.Tour_Text("Outcome"+(i-1)));
            Load_Tour_text.ins.Front.text = Load_Tour_text.ins.OutcomeCardFace[i - 2].ToString();
               //LoadTourtext.ins.Front.text = LoadTourtext.ins.CardFace[1][i-2].ToString();
               audioSource.clip = audioClips[i];
            audioSource.Play();
            //GetOutcome_Text("Outcome1");
           
            yield return new WaitForSeconds(4f);
            OutBtmAnim.SetActive(false);
            // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
            card.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
       // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
        card.SetActive(false);
        audioSource.clip = audioClips[7];
        BBBtnAnim.SetActive(true);
        audioSource.Play();
        card.SetActive(true);
        Load_Tour_text.ins.Front.text = Load_Tour_text.ins.BBIntro.ToString();
        BBBtnAnim.SetActive(true);
       // TourBtnAnimationBB();
        yield return new WaitForSeconds(4f);
        if (bInterrupted)
        {
            yield return null;
        }
        for (int i = 8; i <= 12; i++)
        {
            if (bInterrupted)
            {
                yield return null;
            }
            audioSource.clip = audioClips[i];
            audioSource.Play();
            // StartCoroutine(LoadTourtext.ins.Tour_Text("BB" + (i - 7)));
            Load_Tour_text.ins.Front.text = Load_Tour_text.ins.BBCardFace[i - 8].ToString();
            card.SetActive(true);
            yield return new WaitForSeconds(3f);
           // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
            card.SetActive(false);
            yield return new WaitForSeconds(1f);
            BBBtnAnim.SetActive(false);
        }
        audioSource.clip = audioClips[13];
        DellBtnAnim.SetActive(true);
       // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
        audioSource.Play();
        card.SetActive(true);
        Load_Tour_text.ins.Front.text = Load_Tour_text.ins.DVSIntro.ToString();
        if (bInterrupted)
        {
            yield return null;
        }
        // TourBtnAnimationDVS();
        for (int i = 1; i <= 5; i++)
        {
            if (bInterrupted)
            {
                yield return null;
            }
            //StartCoroutine(LoadTourtext.ins.Tour_Text("DVS" + (i)));
            Load_Tour_text.ins.Front.text = Load_Tour_text.ins.DVSCardFace[i - 1].ToString();

            card.SetActive(true);
            yield return new WaitForSeconds(1.5f);
          
            // StartCoroutine(Load_Tour_text.ins.Tour_Text("BlankText"));
            card.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            DellBtnAnim.SetActive(false);
        }
        audioSource.clip = audioClips[14];
        card.SetActive(true);
        Load_Tour_text.ins.Front.text = Load_Tour_text.ins.Ending.ToString();
        audioSource.Play();
        yield return new WaitForSeconds(8f);
        Videoplayer.SetActive(true);
        card.SetActive(false);
        Hower_Active.Howeractive = true;
        if (bInterrupted)
        {
            yield return null;
        }

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
  
  
 
}