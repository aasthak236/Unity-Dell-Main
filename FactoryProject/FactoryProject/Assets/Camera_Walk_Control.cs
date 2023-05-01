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
    public int[] HotSpotAtMovePoint;

    public float rotateTime = 1f;
    public LeanTweenType easeType = LeanTweenType.easeInOutQuad;

    public static Camera_Walk_Control instance;

    void Start()
    {
        instance = this;
        
    }
    public void TestCameraWalk()
    {
        StartCoroutine(CameraWalk());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator  CameraWalk()
    {
       
        //HotSpotAtMovePoint[0] = 1;
        HotSpotAtMovePoint[1] = 1;
        HotSpotAtMovePoint[2] = 11;
        HotSpotAtMovePoint[3] = 13;
        HotSpotAtMovePoint[4] = 6;
        HotSpotAtMovePoint[5] = 2;
        HotSpotAtMovePoint[6] = 8;
        HotSpotAtMovePoint[7] = 0;
        HotSpotAtMovePoint[8] = 0;
        HotSpotAtMovePoint[9] = 5;
        HotSpotAtMovePoint[10] = 7;
        HotSpotAtMovePoint[11] = 12;
        HotSpotAtMovePoint[12] = 0;
        HotSpotAtMovePoint[13] = 4;
        HotSpotAtMovePoint[14] = 14;
        HotSpotAtMovePoint[15] = 14;
        HotSpotAtMovePoint[16] = 14;
        for (int i = 0; i <= 13; i++)
        {
            BackCardData.instance.HotSpot[i].SetActive(false);
        }
        #region First CameraZoom

        LeanTween.move(myCamera.gameObject, new Vector3(
                         CameraMovePoints[0].transform.localPosition.x,
                         CameraMovePoints[0].transform.localPosition.y,
                         CameraMovePoints[0].transform.localPosition.z), 3f).setEaseOutQuint().setOnComplete

                         (onComplete =>
                         {
                             isCameraMoving = false;
                         });

        //Rotate Camera According to Ref Point Rotation
        LeanTween.rotate(myCamera.gameObject, new Vector3(
           CameraMovePoints[0].transform.eulerAngles.x,
           CameraMovePoints[0].transform.eulerAngles.y,
           CameraMovePoints[0].transform.eulerAngles.z), 3f).setEaseOutQuint();
        
        yield return new WaitForSeconds(5f);
        #endregion
        BackCardData.instance.HotSpotSizeDecrease();
        for (int i = 1; i <= 14; i++)
        {
          
            if (i < CameraMovePoints.Length && !isCameraMoving)
            {
                //for (int j= i; j < CameraMovePoints.Length; j++)
                //{
                //USECASE = usecase[i];
                //if (j == i)
                //{
                // Set the camera's orthographic property to false to switch to perspective projection
                float distance = Vector3.Distance(Camera.main.transform.position, CameraMovePoints[i].transform.position);
                myCamera.orthographic = false;

                        //Move Camera Toward Point
                        LeanTween.move(myCamera.gameObject, new Vector3(
                            CameraMovePoints[i].transform.localPosition.x,
                            CameraMovePoints[i].transform.localPosition.y,
                            CameraMovePoints[i].transform.localPosition.z), distance/5f).setEaseOutQuint().setOnComplete

                            (onComplete =>
                            {
                                isCameraMoving = false;
                            });

                        //Rotate Camera According to Ref Point Rotation
                        LeanTween.rotate(myCamera.gameObject, new Vector3(
                           CameraMovePoints[i].transform.eulerAngles.x,
                           CameraMovePoints[i].transform.eulerAngles.y,
                           CameraMovePoints[i].transform.eulerAngles.z), 3f).setEaseOutQuint();

                // transform.LookAt(BackCardData.instance.HotSpot[j].transform.position);

                //}
                //}
               
            }
            yield return new WaitForSeconds(1f);
            if (HotSpotAtMovePoint[i] != 0)
            {
                BackCardData.instance.HotSpot[HotSpotAtMovePoint[i] - 1].transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(true);
                BackCardData.instance.HotSpot[HotSpotAtMovePoint[i] - 1].SetActive(true);
                yield return new WaitForSeconds(1f);
                Guided_Tour.instance.audioSource.clip = Guided_Tour.instance.HotSpotAudioIntro[HotSpotAtMovePoint[i] - 1];
                Guided_Tour.instance.audiolength = Guided_Tour.instance.HotSpotAudioIntro[HotSpotAtMovePoint[i] - 1].length;
                Guided_Tour.instance.audioSource.Play();
                yield return new WaitForSeconds(Guided_Tour.instance.audiolength);
                BackCardData.instance.HotSpot[HotSpotAtMovePoint[i] - 1].SetActive(false);
                BackCardData.instance.HotSpot[HotSpotAtMovePoint[i] - 1].transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                yield return new WaitForSeconds(2f);
            }

            //BackCardData.instance.HotSpot[i - 1].transform.GetChild(i - 1).GetChild(2).GetChild(1).gameObject.SetActive(true);
          

        }
        for (int i = 0; i <= 13; i++)
        {
            BackCardData.instance.HotSpot[i].SetActive(true);
        }

    }

   


}

