using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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
    void Start()
    {
       
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
            any_window_open = true;
         
            //ClickController.instance.CancelAllTimer();
        }
        else
        {
            ClickController.instance.CancelAllTimer();
            RotatingComponent.SetActive(false);
            isopen = false;
            any_window_open = false;
            FlipBtn.SetActive(false);
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
        if (isopen2 == false)
        {
            Hower_Active.Howeractive = true;
            Invoke("loadvideo", 0.5f);
            isopen2 = true;
            RotatingComponent.SetActive(false);
            Invoke("loadingfalse", 3f);
            LoadingScreen.SetActive(true);
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
}
