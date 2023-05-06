using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Camera_Walk_Control : MonoBehaviour
{
    public bool ImmersiveTourStart;
    bool isCameraMoving;
    public Camera myCamera;
    // Start is called before the first frame update
    [Header("Section Point Transforms")]
    public Transform[] CameraMovePoints;
    public int[] HotSpotAtMovePoint;
    public TextMeshProUGUI ImmersiveTourText;
    public float rotateTime = 1f;
    public LeanTweenType easeType = LeanTweenType.easeInOutQuad;
    public GameObject ImmersiveTourCaption;

    public static Camera_Walk_Control instance;

    void Start()
    {
        instance = this;
        
    }
    public void TestCameraWalk()
    {
        //StartCoroutine(CameraWalk());
        myCoroutine = CameraWalk();
        StartCoroutine(myCoroutine);
    }
    public void StopCoroutineImmersiveTour()
    {
            StopCoroutine(myCoroutine);
        CameraZoomTowardPoint.instance.ZoomBack();
        for (int i = 0; i <= 13; i++)
        {
            BackCardData.instance.HotSpot[i].transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator myCoroutine;
    IEnumerator  CameraWalk()
    {
       
         //HotSpotAtMovePoint[0] = 1;
        HotSpotAtMovePoint[1] = 1;
        HotSpotAtMovePoint[2] = 11;
        HotSpotAtMovePoint[3] = 13;
        HotSpotAtMovePoint[4] = 2;
        HotSpotAtMovePoint[5] = 8;
        HotSpotAtMovePoint[6] = 0;
        HotSpotAtMovePoint[7] = 0;
        HotSpotAtMovePoint[8] = 5;
        HotSpotAtMovePoint[9] = 7;
        HotSpotAtMovePoint[10] = 12;
        HotSpotAtMovePoint[11] = 0;
        HotSpotAtMovePoint[12] = 6;
        HotSpotAtMovePoint[13] = 4;
        HotSpotAtMovePoint[14] = 14;
        HotSpotAtMovePoint[15] = 0;
        HotSpotAtMovePoint[16] = 0;
        ImmersiveTourStart = true;
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
        for (int i = 1; i <= 15; i++)
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
                ImmersiveTourCaption.SetActive(true);
                ImmersiveTourText.text = Guided_Tour.instance.HotSpotTextIntro[HotSpotAtMovePoint[i] - 1];
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
            if (i == 15)
            {
                yield return new WaitForSeconds(2f);
                CameraZoomTowardPoint.instance.ZoomBack();
            }
            //BackCardData.instance.HotSpot[i - 1].transform.GetChild(i - 1).GetChild(2).GetChild(1).gameObject.SetActive(true);
          

        }
        for (int i = 0; i <= 13; i++)
        {
            BackCardData.instance.HotSpot[i].SetActive(true);
        }

    }

   


}

