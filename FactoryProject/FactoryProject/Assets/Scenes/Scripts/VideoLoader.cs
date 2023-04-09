using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
   
    public VideoPlayer videoPlayer;
    public string url;
    private Renderer videoRenderer;
    public Material videoMaterial;
    public static VideoLoader instance;
    public void Awake()
    {
      
    }
    public void Start()
    {
        instance = this;
    }
  public  IEnumerator VideoPlay(string url)
    {
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

            videoPlayer = gameObject.AddComponent<VideoPlayer>();
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = url;
            videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
            videoPlayer.targetMaterialRenderer = videoRenderer = gameObject.AddComponent<Renderer>();
            videoPlayer.targetMaterialProperty = "_MainTex";
            videoRenderer.material = videoMaterial;
            //videoPlayer.Play();
        }
    }

    void OnVideoPrepared(VideoPlayer source)
    {
       // source.Play();
    }
    public void StopVideo()
    {
       
    }
}
