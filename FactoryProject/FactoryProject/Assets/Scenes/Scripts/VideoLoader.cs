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
    //public void VideoPlay()
    //{
    //    VideoIsRunning = true;
    //}
 

    void OnVideoPrepared(VideoPlayer source)
    {
       // source.Play();
    }
   public  void videoplayTour(string url)
    {
        StartCoroutine(TourVideo(url));
    }
    public IEnumerator TourVideo(string urlvideo)
    {
        url = urlvideo;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            //videoPlayer.source = VideoSource.Url;
            //videoPlayer.url = url;
            //videoPlayer.Play();
            // videoPlayer.Prepare();
            //videoPlayer.prepareCompleted += OnVideoPrepared;

            //videoPlayer = gameObject.AddComponent<VideoPlayer>();

            //videoPlayer.source = VideoSource.Url;
            //videoPlayer.url = url;
            //videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
            //videoPlayer.targetMaterialRenderer = gameObject.AddComponent<Renderer>();
            //videoRenderer= gameObject.AddComponent<Renderer>();
            //videoPlayer.targetMaterialProperty = "_MainTex";
            //try
            //{
            //    videoRenderer.material = videoMaterial;
            //}
            //catch
            //{ 
          
            videoPlayer.SetDirectAudioVolume(0, 0f);
            videoPlayer.url = url;
           
            videoPlayer.Prepare();
            while (!videoPlayer.isPrepared)
            { 
                yield return new WaitForEndOfFrame();
            }
            videoPlayer.frame = 0; //just incase it's not at the first frame
            videoPlayer.Play();
            Guided_Tour.instance.videoplayer.SetActive(true);
            Guided_Tour.instance.videoRawimage.gameObject.SetActive(true);

        }
    }


}
