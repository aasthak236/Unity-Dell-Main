using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
public class DellVideo : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoPlayer videoPlayer;
    public string url;

    public static DellVideo instance;
    public bool VideoIsRunning;
    public GameObject videoimage;
    public void Awake()
    {

    }
    public void Start()
    {

        instance = this;
        videoimage.SetActive(false);

    }
    public IEnumerator VideoPlay()
    {
        videoimage.SetActive(true);
        url = GUI_Control.instance.videolink;
        videoPlayer.url = url;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            //videoPlayer.source = VideoSource.Url;
            //videoPlayer.url = videoUrl;
            //videoPlayer.Prepare();
            //videoPlayer.prepareCompleted += OnVideoPrepared;

            //videoPlayer.SetDirectAudioVolume(0, 0f);
            videoPlayer.url = url;
            videoPlayer.Prepare();

            videoPlayer.prepareCompleted += (source) =>
            {
                videoPlayer.Play();
            };
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
