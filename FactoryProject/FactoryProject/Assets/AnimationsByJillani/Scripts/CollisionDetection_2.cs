using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection_2 : MonoBehaviour
{
    public Animator startPointRobotAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            MyBoxMovement_2.instance.currentObj = other.gameObject;
            startPointRobotAnim.SetTrigger("StartAnim");
            StartCoroutine(MyBoxMovement_2.instance.DisableTheBox());

        }


    }
}
