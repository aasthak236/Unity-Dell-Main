using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome_Tour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayWelcomeAudioClips());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayWelcomeAudioClips()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= 2; i++)
        {
            Get_WelcomeText.instance.audioSources[i].clip = Get_WelcomeText.instance.audioclip[i];
           float audiolength = Get_WelcomeText.instance.audioclip[i].length;
            Get_WelcomeText.instance.audioSources[i].Play();
            yield return new WaitForSeconds(audiolength);
        }

        
    }
    }
