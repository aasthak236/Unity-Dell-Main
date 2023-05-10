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
      
    }
    public void Start()
    {
        Previousbtn.SetActive(false);
        if (Load_Tour_text.ins.VideoLink[1] != null)
        {

            Nextbtn.SetActive(true);
        }
        else
        {
            Nextbtn.SetActive(false);
        }
        url = Load_Tour_text.ins.VideoLink[0];
        videoPlayer.url = url;
        StartCoroutine(PlayVideo(url));

    }
    IEnumerator PlayVideo(string urlVideo)
    {
        url = urlVideo;
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
    public GameObject Nextbtn, Previousbtn;
    int CurrentVideoIndex=0;
    public void NextButton()
    {
        CurrentVideoIndex++;
        url = Load_Tour_text.ins.VideoLink[CurrentVideoIndex];
        videoPlayer.Stop();
        StartCoroutine(PlayVideo(url));
        if (Load_Tour_text.ins.VideoLink[CurrentVideoIndex+1]=="")
        {
            Nextbtn.SetActive(false);
            
        }
        Previousbtn.SetActive(true);

    }

    public void PreviousButton()
    {
        CurrentVideoIndex--;
        url = Load_Tour_text.ins.VideoLink[CurrentVideoIndex];
        videoPlayer.Stop();
        StartCoroutine(PlayVideo(url));
        if (CurrentVideoIndex <= 0)
        {
            Previousbtn.SetActive(false);
        }
        Nextbtn.SetActive(true);
    }
}
