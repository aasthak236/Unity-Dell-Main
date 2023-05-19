using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
public class dellpartervideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string url;
    public static dellpartervideo instance;
    public bool VideoIsRunning;
    public GameObject videoimage;
    public GameObject VideoLodingBar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        videoimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (videoPlayer.isPlaying)
        //{
        //    Guided_Tour.instance.BG_Music.SetActive(false);
        //}
        //else 
        //{
        //    Guided_Tour.instance.BG_Music.SetActive(true);
        //}
    }
    public IEnumerator videoplaydellpartner()
    {
        VideoLodingBar.SetActive(true);
        url = BackCardData.instance.videolink;
        videoPlayer.url = url;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Guided_Tour.instance.bPartnervideoplaying = true;
            videoPlayer.url = url;
            videoPlayer.Prepare();
            
            while (!videoPlayer.isPrepared)
            {
                yield return new WaitForEndOfFrame();
            }
            
            VideoLodingBar.SetActive(false);
            if (BackCardData.instance.PartnerWindow.activeSelf == true && Guided_Tour.instance.bPartnervideoplaying)
            {
                videoPlayer.frame = 0; //just incase it's not at the first frame
                videoPlayer.Play();
                videoimage.SetActive(true);
               
            }
            else
            {
                Guided_Tour.instance.bPartnervideoplaying = false;
            }
          
            
           
           

        }
    }
}
