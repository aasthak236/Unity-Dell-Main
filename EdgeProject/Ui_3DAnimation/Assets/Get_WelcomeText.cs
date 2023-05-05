using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Get_WelcomeText : MonoBehaviour
{
    public AudioClip[] audioclip;
    public AudioSource[] audioSources;
    public static Get_WelcomeText instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(Loadaudio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Loadaudio()
    {

        for (int i = 1; i <= 3; i++)
        {

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("https://dell-unity-dev.s3-accelerate.amazonaws.com/Assets/audio/edge/" + Module_Name.ModuleName+"_Welcome" + i+".mp3", AudioType.MPEG))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    audioclip[i - 1]= DownloadHandlerAudioClip.GetContent(www);
                    audioSources[i - 1].clip = audioclip[i - 1];
                    // audioSources.Play();
                }
                else
                {
                    Debug.LogError("Failed to download audio: " + www.error);
                }
            }
        }

    }
}
