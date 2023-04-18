using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactivityAnimation : MonoBehaviour
{
    private float timeInactive = 0.0f;
    private float inactiveThreshold = 10.0f; // The amount of time in seconds before activating the theme

    public Animator anim; // The game object containing the theme to activate
    public bool zoomBack;
    void Update()
    {
        if (Input.anyKeyDown) // If any key is pressed, reset the inactive timer
        {
            timeInactive = 0.0f;
        }
        else // Otherwise, increment the inactive timer
        {
            timeInactive += Time.deltaTime;
            if (timeInactive >= inactiveThreshold) // If the inactive timer exceeds the threshold, activate the theme
            {
                zoomBack = true;
                anim.enabled = true;
                BackCardData.instance.HotSpotSizeDecreaseTouranim();
            }
            else
            {
                if (zoomBack)
                {
                    CameraZoomTowardPoint.instance.CameraAnimFunction();
                    anim.enabled = false;
                    zoomBack = false;
                }
               
            }
        }
    }
}
