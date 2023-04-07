using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineActivator : MonoBehaviour
{
    public PlayableDirector femalePickingTimeline;
    public BoxSlotMovement boxSlotScript;
    [HideInInspector]
    public bool isPlaying = false;

    public void StartTimeline()
    {
        femalePickingTimeline.Play();
        if (femalePickingTimeline.state == PlayState.Playing && !isPlaying)
        {
            // Timeline started playing
            isPlaying = true;
            Debug.Log("Timeline started playing.");
        }

    }
    private void LateUpdate()
    {
        if (femalePickingTimeline.state != PlayState.Playing && isPlaying)
        {
            // Timeline stopped playing
            isPlaying = false;
            
            boxSlotScript.stopBox_1 = false;
            StartCoroutine(boxSlotScript.MoveBoxSlot1());
            Debug.Log("Timeline stopped playing.");
        }
    }

    //public void StopTimeline()
    //{
    //    femalePickingTimeline.Stop();
       
    //}
}
