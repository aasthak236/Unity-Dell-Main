using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
using UnityEngine.UI;

public class BackGroundVideo : MonoBehaviour
{
    private string videoUrl;
    public VideoPlayer videoPlayer;
    public string url;
    public RawImage videoImage;
    public int videoWidth = 1920; // set the width of your video here
    public int videoHeight = 1080;
    private RenderTexture videoTexture;
    public void Awake()
    {
        
        url = "https://dell-unity-dev.s3-accelerate.amazonaws.com/Assets/videos/" + Module_Name.ModuleName + "pano.mp4";
        videoPlayer.url = url;
    }
    IEnumerator Start()
    {
        //// Create a new RenderTexture with the same dimensions as the video
        //videoTexture = new RenderTexture(videoWidth, videoHeight, 0);
        //videoTexture.filterMode = FilterMode.Point;

        //// Assign the RenderTexture to the RawImage
        //videoImage.texture = videoTexture;


        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            videoPlayer.url = url;
            videoPlayer.Prepare();
            while (!videoPlayer.isPrepared)
            {
                yield return new WaitForEndOfFrame();
            }
            videoPlayer.frame = 0; //just incase it's not at the first frame
            videoPlayer.Play();

        }
    }

    //void Update()
    //{
    //    // Update the size and position of the RawImage to fill the screen in widescreen format
    //    float screenAspect = (float)Screen.width / Screen.height;
    //    float videoAspect = (float)videoWidth / videoHeight;

    //    if (screenAspect > videoAspect)
    //    {
    //        // Screen is wider than video, so expand the video horizontally to fill the screen
    //        float height = Screen.height;
    //        float width = height * videoAspect;
    //        float xPos = (Screen.width - width) / 2f;
    //        float yPos = 0f;

    //        videoImage.rectTransform.sizeDelta = new Vector2(width, height);
    //        videoImage.rectTransform.anchoredPosition = new Vector2(xPos, yPos);
    //    }
    //    else
    //    {
    //        // Screen is narrower than video, so expand the video vertically to fill the screen
    //        float width = Screen.width;
    //        float height = width / videoAspect;
    //        float xPos = 0f;
    //        float yPos = (Screen.height - height) / 2f;

    //        videoImage.rectTransform.sizeDelta = new Vector2(width, height);
    //        videoImage.rectTransform.anchoredPosition = new Vector2(xPos, yPos);
    //    }

    //    // Set the top padding of the RawImage to trim the top of the video if necessary
    //    float padding = Mathf.Max((Screen.height - videoImage.rectTransform.sizeDelta.y) / 2f, 0f);
    //    videoImage.rectTransform.offsetMax = new Vector2(0f, -padding);
    //}

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Render the source video to the RenderTexture
        Graphics.Blit(source, videoTexture);
    }
}
