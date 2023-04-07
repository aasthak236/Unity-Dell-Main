using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Wecome_Screen : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioclip;
    public GameObject hotspot1;
    public GameObject guided;
    public GameObject unclickscreen;
    // Start is called before the first frame update
    public void Start()
    {
      
       
     
   
    }
    public void offloading()
    {
        GUI_Control.instance.loadingfalse();
    }
    IEnumerator Loadaudio()
    {

        for (int i = 1; i <= 3; i++)
        {

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("https://dell-unity-dev.s3.amazonaws.com/audio/edge/um_Welcome"+i+".mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    audioclip[i-1]= DownloadHandlerAudioClip.GetContent(www);
                    audioSource.Play();
                }
                else
                {
                    Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }
        
    }
    public int currentClipIndex = 0;

    // Update is called once per frame
    void Update()
    {
       
    }
    //public bool Stop_Audio_loop;
    private void ScaleDown()
    {
       
    }
    public void WelcomeTime()
    { 
    
    }
}
