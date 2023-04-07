using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPointTrigger : MonoBehaviour
{
    public BoxSlotMovement boxSlotScript;
    public TimelineActivator TimelineActivateScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box1")
        {
            other.gameObject.SetActive(false);
            boxSlotScript.stopBox_1 = true;
          //  Debug.Log("Stop the Movement");
          
                TimelineActivateScript.StartTimeline();
            
        }
    }
}
