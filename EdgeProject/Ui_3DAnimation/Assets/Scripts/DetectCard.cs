using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCard : MonoBehaviour
{
    public static DetectCard instance;
    public static  bool isRotated;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        LeanTween.moveLocalY(ClickController.instance.crossbtn, 142f, 0.3f);
        LeanTween.moveLocalX(ClickController.instance.crossbtn, 96f, 0.3f);
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
           
            LeanTween.rotateLocal(gameObject, new Vector3(0, 0, -180), 0.5f);
            LeanTween.scale(gameObject, new Vector3(1.4f, 1.4f, 1.4f), 0.5f);
           
            ClickController.instance.Negative.GetComponent<Image>().enabled = true;
            ClickController.instance.Plus.GetComponent<Image>().enabled = false;
            LeanTween.moveLocalY(ClickController.instance.flipbtn, -251f, 0.3f);
            LeanTween.moveLocalY(ClickController.instance.flipbtn1, -251f, 0.3f);
            ClickController.instance.crossbtn.SetActive(false);
            //LeanTween.moveLocalY(ClickController.instance.crossbtn, 223f, 0.3f);
            // LeanTween.moveLocalX(ClickController.instance.crossbtn, 156f, 0.3f);
        }
        else
        {
            isRotated = false;
            LeanTween.rotateLocal(gameObject, new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(gameObject, new Vector3(0.8238152f, 0.8238152f, 0.8238152f), 0.5f);
            ClickController.instance.Negative.GetComponent<Image>().enabled = false;
            ClickController.instance.Plus.GetComponent<Image>().enabled = true;
           
            LeanTween.moveLocalY(ClickController.instance.flipbtn, -134f, 0.3f);
            LeanTween.moveLocalY(ClickController.instance.flipbtn1, -134f, 0.3f);
            ClickController.instance.crossbtn.SetActive(true);
            LeanTween.moveLocalY(ClickController.instance.crossbtn, 142f, 0.3f);
            LeanTween.moveLocalX(ClickController.instance.crossbtn, 96f, 0.3f);
            
            if (OnClick.Hotspot==false)
            {
                Invoke("movefarword", 1f);
            }
            
        }

    }
    public void ResetFlip()
    {
        for (int i = 0; i <= 4; i++)
        {
            LeanTween.rotateLocal(ClickController.instance.flipcard[i], new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(ClickController.instance.flipcard[i], new Vector3(0.8238152f, 0.8238152f, 0.8238152f), 0.5f);

            ImageLoader.instance.Back[i].gameObject.SetActive(false);
            ImageLoader.instance.Front[i].gameObject.SetActive(true);
            ClickController.instance.backtext = false;
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
