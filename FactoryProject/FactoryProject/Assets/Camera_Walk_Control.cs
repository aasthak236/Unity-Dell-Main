using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Walk_Control : MonoBehaviour
{
    bool isCameraMoving;
    public Camera myCamera;
    // Start is called before the first frame update
    [Header("Section Point Transforms")]
    public Transform[] CameraMovePoints;
    public float moveSpeed = 1000f;
    void Start()
    {
       // StartCoroutine(CameraWalk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator  CameraWalk()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (i < CameraMovePoints.Length && !isCameraMoving)
            {
                for (int j= i; j < CameraMovePoints.Length; j++)
                {
                    //USECASE = usecase[i];
                    if (j == i)
                    {
                        // Set the camera's orthographic property to false to switch to perspective projection
                        myCamera.orthographic = false;


                        //Move Camera Toward Point
                        LeanTween.move(myCamera.gameObject, new Vector3(
                            CameraMovePoints[j].transform.localPosition.x,
                            CameraMovePoints[j].transform.localPosition.y,
                            CameraMovePoints[j].transform.localPosition.z), 3f).setEaseOutQuint().setOnComplete

                            (onComplete =>
                            {
                                isCameraMoving = false;
                            });

                        //Rotate Camera According to Ref Point Rotation
                        LeanTween.rotate(myCamera.gameObject, new Vector3(
                           CameraMovePoints[j].transform.eulerAngles.x,
                           CameraMovePoints[j].transform.eulerAngles.y,
                           CameraMovePoints[j].transform.eulerAngles.z), 3f).setEaseOutQuint();
                        yield return new WaitForSeconds(10f);
                    }
                }
            }
        }
        yield return new WaitForSeconds(10f);
        isCameraMoving = true;


    }
}
