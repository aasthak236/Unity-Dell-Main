using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoomTowardPoint : MonoBehaviour
{
    // Private Variables
    bool isCameraMoving;
    Camera myCamera;
    [Header("Section Point Transforms")]
    public Transform[] sectionPointTransform;
    public Transform backcamera;
    public static bool CameraZoom;
    public GameObject FactoryMdel;
    public static CameraZoomTowardPoint instance;
    private void Awake()
    {
        myCamera = Camera.main;
        CameraZoom = false;
      //  ZoomBack();
    
    }
    public void Start()
    {
        instance = this;
    }
    //This Function Call on the Button Event in Editor
    public void ZoomInToSection(int sectionIndex)
    {
        BackCardData.instance.HotSpotSizeDecrease();
        FactoryMdel.transform.position = new Vector3(34.1f, 6.47658f, 5.2f);
        Vector3 newrotation = new Vector3(0, 0, 0);
        FactoryMdel.transform.eulerAngles = newrotation;
        BackCardData.instance.HotSpotsRuninng = true;
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
    public void ZoomBack()
    {
        BackCardData.instance.HotSpotsRuninng = false;
        CameraZoom = false;
        FactoryMdel.transform.position = new Vector3(34.1f, 6.47658f, 5.2f);
        BackCardData.instance.HotSpotSizeIncrease();
        ImageToggleOnHover.instance.ClosedAllWindow();
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

                }
           
       
    
}
