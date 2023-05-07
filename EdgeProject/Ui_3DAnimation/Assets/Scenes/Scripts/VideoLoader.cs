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
        url = Load_Tour_text.ins.VideoLink[0];
        videoPlayer.url = url;
    }
    public void Start()
    {
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

            videoPlayer.prepareCompleted += (source) =>
            {
                videoPlayer.Play();
            };
        }
    }
    public GameObject Nextbtn, Previousbtn;
    int CurrentVideoIndex=0;
    public void NextButton()
    {
        CurrentVideoIndex++;
        url = Load_Tour_text.ins.VideoLink[CurrentVideoIndex];
        StartCoroutine(PlayVideo(url));
        if (CurrentVideoIndex>=5)
        {
            Nextbtn.SetActive(false);
            Previousbtn.SetActive(true);
        }
    }

    public void PreviousButton()
    {
        CurrentVideoIndex--;
        url = Load_Tour_text.ins.VideoLink[CurrentVideoIndex];
        StartCoroutine(PlayVideo(url));
        if (CurrentVideoIndex <= 0)
        {
            Nextbtn.SetActive(true);
            Previousbtn.SetActive(false);
        }
    }
}
