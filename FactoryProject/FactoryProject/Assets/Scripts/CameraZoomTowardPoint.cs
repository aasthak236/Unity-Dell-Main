using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomTowardPoint : MonoBehaviour
{
    // Private Variables
    bool isCameraMoving;
    Camera myCamera;
    [Header("Section Point Transforms")]
    public Transform[] sectionPointTransform;
    public Transform backcamera;
    public static bool CameraZoom;

    private void Awake()
    {
        myCamera = Camera.main;
        CameraZoom = false;
    }

    //This Function Call on the Button Event in Editor
    public void ZoomInToSection(int sectionIndex)
    {
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
        CameraZoom = false;
        
                //USECASE = usecase[i];
             
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
