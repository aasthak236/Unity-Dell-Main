using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome_Screen : MonoBehaviour
{
    public int musicOn;
    public static Welcome_Screen instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerPrefs.SetInt("MusicOn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Welcome_Btn()
    {
        SceneManager.LoadScene(2);
    }
    public void soundon()
    {
        
        PlayerPrefs.SetInt("MusicOn", 1);
        AudioListener.volume = 1;

    }
    public void soundoff()
    {
        PlayerPrefs.SetInt("MusicOn", 0);
        AudioListener.volume = 0f;
    }


}
