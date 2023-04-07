using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    private string videoUrl;
    public VideoPlayer videoPlayer;
    public string url;
    private Renderer videoRenderer;
    public Material videoMaterial;
    public void Awake()
    {
        url = "https://dell-unity-dev.s3.amazonaws.com/Assets/videos/" + Module_Name.instance.ModuleName + "1.mp4";
        videoPlayer.url = url;
    }
    IEnumerator Start()
    {
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

            videoPlayer = gameObject.AddComponent<VideoPlayer>();
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = url;
            videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
            videoPlayer.targetMaterialRenderer = videoRenderer = gameObject.AddComponent<Renderer>();
            videoPlayer.targetMaterialProperty = "_MainTex";
            videoRenderer.material = videoMaterial;
           // videoPlayer.Play();
        }
    }

    void OnVideoPrepared(VideoPlayer source)
    {
        source.Play();
    }
}
