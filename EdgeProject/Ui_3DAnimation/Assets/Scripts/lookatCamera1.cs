using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatCamera1 : MonoBehaviour
{
    public Transform target; // a target position representing the front direction
  //  public float offset;
    void Update()
    {
       // Vector3 screenpos = Camera.main.WorldToScreenPoint(target.position);
        Vector3 screenpos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x,target.position.y+1.8f,target.position.z));
        transform.position = screenpos;
    }
}
