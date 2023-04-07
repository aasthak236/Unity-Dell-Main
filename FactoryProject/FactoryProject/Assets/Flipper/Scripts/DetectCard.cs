using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCard : MonoBehaviour
{
    public static DetectCard instance;
    public static  bool isRotated;
    public GameObject Front;
    public GameObject Back;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        //for (int i = 0; i <=3; i++)
        //{
        //    ClickController.instance.MoveForward();
        //}
    }
    //void OnMouseEnter()
    //{
    //    Debug.Log("Mouse over object: " + gameObject.name);
    //    //if (RotateObject.instance != null)
    //    //{
    //    //   // StopCoroutine(RotateObject.instance.DelayToRotate());
    //    //  //  Debug.Log("Stop!");
    //    //}
    //       // LeanTween.scale(gameObject, new Vector3(1.05f, 1.05f, 1.05f), 0.2f);
    //}

 
    public void RotateMyObjectFrontBtnClick()
    {
        //to fix isrotated
        if (isRotated == false)
        {
            isRotated = true;
            LeanTween.rotateLocal(gameObject, new Vector3(0, -180, 0), 0.5f);
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.5f);
            transform.GetComponent<SpriteRenderer>().sortingOrder = 3;
            Front.SetActive(false);
            Back.SetActive(true);
            Invoke("FBBtn", 0.1f);
        }
        else
        {
            isRotated = false;
            LeanTween.rotateLocal(gameObject, new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.5f);
            transform.GetComponent<SpriteRenderer>().sortingOrder = 0;
            Front.SetActive(true);
            Back.SetActive(false);
            Invoke("FBBtn", 0.1f);
           

        }

    }
    public int pressed;
    public void FBBtn()
    {
        if (pressed == 0)
        {
            Front.SetActive(false);
            Back.SetActive(true);
            pressed = 1;
        }
        else
        {
            Front.SetActive(true);
            Back.SetActive(false);
            pressed = 0;
        }
    }
    public void ResetFlip()
    {
        for (int i = 0; i <= 4; i++)
        {
            LeanTween.rotateLocal(ClickController.instance.flipcard[i], new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(ClickController.instance.flipcard[i], new Vector3(0.8238152f, 0.8238152f, 0.8238152f), 0.5f);
        }
        isRotated = false;
        LeanTween.moveLocalY(ClickController.instance.flipbtn, -105.05f, 0.3f);
        LeanTween.moveLocalY(ClickController.instance.flipbtn1, -105.05f, 0.3f);
    }
    public void RotateMyObjectBackBtnClick()
    {
      


        //if (RotateObject.instance != null)
        //{
        //   // StartCoroutine(RotateObject.instance.DelayToRotate());
        //}
    }
    public void movefarword()
    {
        ClickController.instance.MoveForward();
    }
}
