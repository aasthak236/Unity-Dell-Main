using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateLine : MonoBehaviour
{

    public GameObject[] shields;
    public GameObject[] points;
     
    GameObject trail;
    bool stop;
    int currentIndex;
    private void Awake()
    {
        trail = gameObject;
        trail.transform.position = points[0].transform.position;
        StartMoving();
    }
    public void StartMoving()
    {
       if(stop ==false)
        {
            LeanTween.move(trail, points[currentIndex].transform.position, 1f).setOnComplete(onComplete => {

                if(shields.Length !=0 && shields.Length > 1)
                {
                    //Multiple Shields 
                    if(currentIndex == 0 )
                    {
                        shields[0].SetActive(true);
                    }
                    else if (currentIndex == points.Length - 1)
                    {
                        shields[1].SetActive(true);
                    }
                   
                }
                else if(shields.Length == 1)
                {
                    ///Only One Shield Enable At end of the line
                      if(currentIndex == points.Length -1)
                    {
                        shields[0].SetActive(true);
                    }
                }
                
                currentIndex++;

                if (currentIndex > points.Length - 1)
                {
                    stop = true;
                    currentIndex = 0;
                }

               
                StartMoving();
            });
        }
    }


}
