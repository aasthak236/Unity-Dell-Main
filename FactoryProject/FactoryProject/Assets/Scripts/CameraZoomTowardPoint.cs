using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoomTowardPoint : MonoBehaviour
{
    public GameObject Trail1, Trail2;
    // Private Variables
    bool isCameraMoving;
    Camera myCamera;
    [Header("Section Point Transforms")]
    public Transform[] sectionPointTransform;
    public Transform backcamera;
    public Transform CameraAnim;
    public static bool CameraZoom;
    public GameObject FactoryMdel;
    public static CameraZoomTowardPoint instance;
    public GameObject TopBar;
    private void Awake()
    {
        myCamera = Camera.main;
        CameraZoom = false;
      //  ZoomBack();
    
    }
    public void Start()
    {
       
        instance = this;
      //  ZoomInToSection(0);
    }
    //This Function Call on the Button Event in Editor
    public void ZoomInToSection(int sectionIndex)
    {
        try
        {
            Guided_Tour.instance.StopCoroutine();//stop for usecase
            BackCardData.instance.StopCoroutineTour();//stop for outcome
            Guided_Tour.instance.ClosedAllWindow();
          
        }
        catch
        { 
        
        }
        TopBar.SetActive(true);
        BackCardData.instance.HotSpotSizeDecrease();
        FactoryMdel.transform.position = new Vector3(34.1f, 6.47658f, 5.2f);
        Vector3 newrotation = new Vector3(0, 0, 0);
        FactoryMdel.transform.eulerAngles = newrotation;
        BackCardData.instance.BusinessOutcomeWindow.SetActive(false);
        CameraZoom = true;
        if(sectionIndex< sectionPointTransform.Length && !isCameraMoving)
        {
            for (int i = 0; i < sectionPointTransform.Length; i++)
            {
                //USECASE = usecase[i];
                if(i==sectionIndex)
                {
                    // Set the camera's orthographic property to false to switch to perspective projection
                    myCamera.orthographic = false;


                    //Move Camera Toward Point
                    LeanTween.move(myCamera.gameObject, new Vector3(
                        sectionPointTransform[i].transform.localPosition.x,
                        sectionPointTransform[i].transform.localPosition.y,
                        sectionPointTransform[i].transform.localPosition.z), 3f).setEaseOutQuint().setOnComplete
                        
                        (onComplete => 
                        {
                            isCameraMoving = false;
                        });

                    //Rotate Camera According to Ref Point Rotation
                    LeanTween.rotate(myCamera.gameObject, new Vector3(
                       sectionPointTransform[i].transform.eulerAngles.x,
                       sectionPointTransform[i].transform.eulerAngles.y,
                       sectionPointTransform[i].transform.eulerAngles.z), 3f).setEaseOutQuint();

                }
            }
        }
    }
    public void CameraAnimFunction()
    {
      //  myCamera.orthographic = false;


        //Move Camera Toward Point
        LeanTween.move(myCamera.gameObject, new Vector3(
           backcamera.transform.localPosition.x,
            backcamera.transform.localPosition.y,
            backcamera.transform.localPosition.z), 3f).setEaseOutQuint().setOnComplete

            (onComplete =>
            {
                isCameraMoving = false;
            });

        //Rotate Camera According to Ref Point Rotation
        LeanTween.rotate(myCamera.gameObject, new Vector3(
           backcamera.transform.eulerAngles.x,
           backcamera.transform.eulerAngles.y,
           backcamera.transform.eulerAngles.z), 3f).setEaseOutQuint();
    }
    public void ZoomBack()
    {
        FactoryMdel.transform.position = new Vector3(34.1f, 6.47658f, 5.2f);
        Vector3 newrotation = new Vector3(0, 0, 0);
        FactoryMdel.transform.eulerAngles = newrotation;
        Guided_Tour.instance.StopCoroutine();//stop for usecase
        BackCardData.instance.StopCoroutineTour();//stop for outcome
        Guided_Tour.instance.ClosedAllWindow();
        TopBar.SetActive(false);
        BackCardData.instance.BusinessOutcomeWindow.SetActive(false);
        //BackCardData.instance.HotSpotsRuninng = false;
        CameraZoom = false;
        FactoryMdel.transform.position = new Vector3(34.1f, 6.47658f, 5.2f);
        BackCardData.instance.HotSpotSizeIncrease();
        
        for (int i = 0; i <= 13; i++)
        {
            BackCardData.instance.HotSpot[i].SetActive(true);
        }
        //USECASE = usecase[i];
        for (int i = 0; i <= 5; i++)
        {
            BackCardData.instance.OutcomeBtn[i].GetComponent<Image>().color = BackCardData.instance.NormalColor;
        }
        // Set the camera's orthographic property to false to switch to perspective projection
        myCamera.orthographic = false;


                    //Move Camera Toward Point
                    LeanTween.move(myCamera.gameObject, new Vector3(
                       backcamera.transform.localPosition.x,
                        backcamera.transform.localPosition.y,
                        backcamera.transform.localPosition.z), 3f).setEaseOutQuint().setOnComplete

                        (onComplete =>
                        {
                            isCameraMoving = false;
                        });

                    //Rotate Camera According to Ref Point Rotation
                    LeanTween.rotate(myCamera.gameObject, new Vector3(
                       backcamera.transform.eulerAngles.x,
                       backcamera.transform.eulerAngles.y,
                       backcamera.transform.eulerAngles.z), 3f).setEaseOutQuint();
                     // Invoke("CameraAnimFunction",3f);
                }
           
       
    
}
