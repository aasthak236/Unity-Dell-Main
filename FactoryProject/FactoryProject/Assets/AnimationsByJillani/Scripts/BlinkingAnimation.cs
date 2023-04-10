using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingAnimation : MonoBehaviour
{
    public GameObject[] lights;
    public float waitOfBlink;


    private void Start()
    {
        StartCoroutine(Blink());

    }
    IEnumerator Blink()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);
        }
        yield return new WaitForSeconds(waitOfBlink);
        //Turn Off Lights
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        yield return new WaitForSeconds(waitOfBlink);
        StartCoroutine(Blink());

    }
}
