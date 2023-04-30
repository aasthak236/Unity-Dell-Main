using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    
    public static VideoPlayerController instance;
    void Start()
    {
        instance = this;
       
    }

    public void playvideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.url = BackCardData.instance.videolink;
        videoPlayer.Play();
    }
}



