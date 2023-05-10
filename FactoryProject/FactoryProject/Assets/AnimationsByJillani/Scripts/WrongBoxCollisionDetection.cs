using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongBoxCollisionDetection : MonoBehaviour
{
    public Animator RobotAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WrongBox")
        {
            //  MyBoxMovement.instance.currentObj = other.gameObject;
            other.gameObject.tag = "Box";
            StartCoroutine(WaittoTurnOff(other));
            RobotAnim.SetTrigger("StartAnim");
            // StartCoroutine(MyBoxMovement.instance.DisableTheBox());
        }


    }

    public IEnumerator WaittoTurnOff(Collider other)
    {
        yield return new WaitForSeconds(1.2f);
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }
}
