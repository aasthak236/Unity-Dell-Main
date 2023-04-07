using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public static RotateObject instance;
    int rotationAmount = 56;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // StartCoroutine(DelayToRotate());
         // this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Invoke("DelayToRotate", 1f);
    }
    void ScaleButton()
    {
      //  LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.3f).setEase(LeanTweenType.easeInOutSine).setOnComplete(ScaleButtonBack);
    }

    public void DelayToRotate()
    {
         //yield return new WaitForSeconds(5f);
        LeanTween.rotateLocal(gameObject, new Vector3(0, 0, 0), 0.3f);
        //StartCoroutine(DelayToRotate());
        Invoke("loadback",2f);


    }

    public void loadback()
    {
        LeanTween.rotateLocal(gameObject, new Vector3(0, 180, 0), 0.3f);
        Invoke("DelayToRotate", 3f);
    }
}
