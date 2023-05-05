using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeAnimation : MonoBehaviour
{
    public GameObject[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActiveButton",10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDigitalCities()
    {
        SceneManager.LoadScene(1);
    }
    public void ActiveButton()
    { 
    for(int i=0;i<=2;i++)
        {
            Buttons[i].SetActive(true);

        }
    }
}
