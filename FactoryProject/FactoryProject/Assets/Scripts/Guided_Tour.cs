using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
public class Guided_Tour : MonoBehaviour
{
    public static Guided_Tour instance;
    public TMP_Text HexagonCardtext;
    public SaveDataFromXML saveDataFile;
    public AudioClip[] audioClips;
    public float TotalPlayTime = 4f;
    public GameObject card;
    public GameObject Hexagon;
    public GameObject hexaTxt;
    public  AudioSource audioSource, audioSource1;
    private int currentClipIndex = 0;
    public Image[] PartnerImg;
    public Image[] DellSolutionImg;
    public GameObject CTAHexa;
    public TMP_Text Partner1;
    public TMP_Text Partner2;
    public TMP_Text Partner3;
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
    public GameObject playbtn, pausebtn, stopbtn;
    public GameObject BG_Music, Tour_Music;
    private void Awake()
    {
        Assets_Folder = "https://dell-unity-dev.s3-accelerate.amazonaws.com/Factory+Assets/";
        instance = this;
       screenWidth = Screen.width;
        screenHeight = Screen.height;


    }
    void Start()
    {
        //  StartCoroutine(Loadaudio());
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Screen width"+screenWidth+"X"+screenHeight);
        if (screenWidth <= 480)
        {
            Factory.transform.rotation = Quaternion.Euler(0f, -110f, 0f);
        }

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
        if (ImageToggleOnHover.Tour_Running == true)
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
    public IEnumerator Loadaudio()
    {

        for (int i = 1; i <= 36; i++)
        {
            //am get from hotspot 
            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Assets_Folder + "audio/" + ImageToggleOnHover.UseCase + "/" + i + ".mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    audioClips[i - 1] = DownloadHandlerAudioClip.GetContent(www);
                    // audioSources.Play();
                }
                else
                {
                    // Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }

    }
    public float audiolength;

    public void PlayGuidedTour(string UseCase)
    {
       // StartCoroutine(PlayAudioClips());
        myCoroutine = PlayAudioClips();
        StartCoroutine(myCoroutine);

    }
   public  void StopCoroutine()
    {
        for (int i = 0; i <5; i++)
        {
            PartnerImg[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 3; i++)
        {
            PartnerImg[i].gameObject.SetActive(false);
        }
        ImageToggleOnHover.Tour_Running = false;
        bInterrupted = true;
        audioSource.Stop();
        StopCoroutine(myCoroutine);
    }
    public void stoptour()
    {
       
    }
    public bool bInterrupted=false;
    IEnumerator myCoroutine;
    public IEnumerator PlayAudioClips()
    {
        bInterrupted = false;

        float StandardDelay = 0.25f;
        //StartCoroutine(LoadImgWithUrl(Assets_Folder + "image/xmpro-logo.png"));
        // Turn on Introduction audio
        //Intro audio Play
        audioSource.clip = audioClips[0];
        audiolength = audioClips[0].length;
        audioSource.Play();
        yield return new WaitForSeconds(audiolength + 0.5f);
        for (int i = saveDataFile.IntroStartIndx; i <= saveDataFile.IntroEndIndx; i++)
        {
            if (bInterrupted)
            {
                bInterrupted = true;
                ImageToggleOnHover.Tour_Running = false;

                yield return null;
            }
            card.SetActive(true);
            hexaTxt.SetActive(true);
            Hexagon.SetActive(true);
            HexagonCardtext.text = saveDataFile.INTRO[i - 1];
            //Audio will be played
            // audioSource.Play();

            //EC Audio with 3 & 4
            audioSource.clip = audioClips[i];
            audiolength = audioClips[i].length;
            audioSource.Play();

            yield return new WaitForSeconds(audiolength + StandardDelay);
            card.SetActive(false);

        }
            // for(int i=0;i<)
            //// Turn on Partner Solution audio & image
         

        //yield return new WaitForSeconds(4f);
        //Image.gameObject.SetActive(false);

        //EC Audio with nothing on screen
        if (bInterrupted)
        {
            bInterrupted = true;
            ImageToggleOnHover.Tour_Running = false;
            yield return null;
        }
        audioSource.clip = audioClips[9];
        audiolength = audioClips[9].length;
        audioSource.Play();
        yield return new WaitForSeconds(audiolength + StandardDelay);
        // StartCoroutine(LoadImgWithUrl(Assets_Folder + "image/xmpro-dashboard.png"));
        //Show Edge Chanllenges Text with audio
        for (int i = saveDataFile.ECStartIndx; i <= saveDataFile.ECEndIndx; i++)
        {
            if (bInterrupted)
            {
                bInterrupted = true;
                ImageToggleOnHover.Tour_Running = false;

                yield return null;
            }
            card.SetActive(true);
            hexaTxt.SetActive(true);
            Hexagon.SetActive(true);
            HexagonCardtext.text = saveDataFile.EC[i - 1];
            //Audio will be played
            // audioSource.Play();

            //EC Audio with 3 & 4
            audioSource.clip = audioClips[i + 9];
            audiolength = audioClips[i + 9].length;
            audioSource.Play();

            yield return new WaitForSeconds(audiolength + StandardDelay);
            card.SetActive(false);

        }

        card.SetActive(false);
        yield return new WaitForSeconds(1f);
        ////Show Dell Edge Solution Audio And Text
        for (int i = saveDataFile.HARDWAREStartIndx; i <= saveDataFile.HARDWAREEndIndx; i++)
        {
            if (bInterrupted)
            {
                PartnerImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(false);
                bInterrupted = true;
                ImageToggleOnHover.Tour_Running = false;

                yield return null;
            }
            card.SetActive(true);
            PartnerImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(true);
            //HexagonCardtext.text = saveDataFile.DES[i - 1];
            hexaTxt.SetActive(false);
            Hexagon.SetActive(false);
            //  Image.gameObject.SetActive(true);
            
            //Audio will be played
            //  audioSource.Play();

            audioSource.clip = audioClips[i + 13];
            audiolength = audioClips[i + 13].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength + StandardDelay);
            card.SetActive(false);
            //  Image.gameObject.SetActive(false);
            PartnerImg[int.Parse(SaveDataFromXML.ins.HARDWARE[i - 1]) - 1].gameObject.SetActive(false);

        }

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
        for (int i = saveDataFile.TTStartIndx; i <= saveDataFile.TTEndIndx; i++)
        {
            if (bInterrupted)
            {
                bInterrupted = true;
                ImageToggleOnHover.Tour_Running = false;

                yield return null;
            }
            card.SetActive(true);
            hexaTxt.SetActive(true);
            Hexagon.SetActive(true);
            HexagonCardtext.text = saveDataFile.TT[i - 1];
            //Audio will be played
            // audioSource.Play();
            audioSource.clip = audioClips[i + 18];
            audiolength = audioClips[i + 18].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength + StandardDelay);
            card.SetActive(false);

        }

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
        for (int i = saveDataFile.PSStartIndx; i <= saveDataFile.PSEndIndx; i++)
        {
            if (bInterrupted)
            {
                PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 1]) - 1].gameObject.SetActive(false);
                yield return null;
            }

            //StartCoroutine(LoadImgWithUrl(saveDataFile.PS[i - 1]));
            PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 1]) - 1].gameObject.SetActive(true);
            card.SetActive(true);
            //Partner Solution audio Play
            audioSource.clip = audioClips[i + 3];
            audiolength = audioClips[i + 3].length;
            audioSource.Play();

            hexaTxt.SetActive(false);
            Hexagon.SetActive(false);
            // Image.gameObject.SetActive(true);
            // audioSource.Play();
            //audioSource.clip = audioClips[1];
            //audioSource.Play();

            yield return new WaitForSeconds(audiolength + StandardDelay);
            // Image.gameObject.SetActive(false);
            PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 1]) - 1].gameObject.SetActive(false);
            card.SetActive(false);

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
        for (int i = saveDataFile.FOStartIndx; i <= saveDataFile.FOEndIndx; i++)
        {
            if (bInterrupted)
            {
                bInterrupted = true;
                ImageToggleOnHover.Tour_Running = false;

                yield return null;
            }
            card.SetActive(true);
            hexaTxt.SetActive(true);
            Hexagon.SetActive(true);
            HexagonCardtext.text = saveDataFile.FO[i - 1];
            //Audio will be played
            // audioSource.Play();
            audioSource.clip = audioClips[i + 23];
            audiolength = audioClips[i + 23].length;
            audioSource.Play();
            yield return new WaitForSeconds(audiolength);
            card.SetActive(false);

        }
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
        for (int i = saveDataFile.BIStartIndx; i <= saveDataFile.BIEndIndx; i++)
        {
            if (bInterrupted)
            {
                bInterrupted = true;
                ImageToggleOnHover.Tour_Running = false;

                yield return null;
            }
            card.SetActive(true);
            hexaTxt.SetActive(true);
            Hexagon.SetActive(true);
            HexagonCardtext.text = saveDataFile.BI[i - 1];

            //Audio will be played
            // audioSource.Play();

            audioSource.clip = audioClips[i + 28];
            audiolength = audioClips[i + 28].length;
            audioSource.Play();

            yield return new WaitForSeconds(audiolength);
            card.SetActive(false);

        }
        if (bInterrupted)
        {
            bInterrupted = true;
            ImageToggleOnHover.Tour_Running = false;

            yield return null;
        }
        if (saveDataFile.PSEndIndx == 0)
        {

        }
        else
        {
            CTAHexa.SetActive(true);
            Partner1.text = Load_Tour_text.ins.PartnersName[int.Parse(SaveDataFromXML.ins.PS[0]) - 1];
            // PartnerImg[int.Parse(SaveDataFromXML.ins.PS[i - 1]) - 1].gameObject.SetActive(false);
            if (saveDataFile.PSEndIndx > 1)
            {
                Partner2.text = Load_Tour_text.ins.PartnersName[int.Parse(SaveDataFromXML.ins.PS[1]) - 1];
            }
            if (saveDataFile.PSEndIndx > 2)
            {
                Partner3.text = Load_Tour_text.ins.PartnersName[int.Parse(SaveDataFromXML.ins.PS[2]) - 1];
            }
        }
        audioSource.clip = audioClips[34];
        audiolength = audioClips[34].length;
        audioSource.Play();
        yield return new WaitForSeconds(audiolength + 0.5f);
        ImageToggleOnHover.Tour_Running = false;


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