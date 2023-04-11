using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
   
    public Animator startPointRobotAnim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Box")
        {
            MyBoxMovement.instance.currentObj = other.gameObject;
            startPointRobotAnim.SetTrigger("StartAnim");
            StartCoroutine(MyBoxMovement.instance.DisableTheBox());
    
        }
       
       
    }


    
}
