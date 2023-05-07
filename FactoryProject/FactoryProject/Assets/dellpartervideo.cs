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
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        videoimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator videoplaydellpartner()
    {
        videoimage.SetActive(true);
        url = BackCardData.instance.videolink;
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
}
