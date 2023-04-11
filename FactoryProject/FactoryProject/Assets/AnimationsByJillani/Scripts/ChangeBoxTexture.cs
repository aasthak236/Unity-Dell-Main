using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxTexture : MonoBehaviour
{
    public Material printedTxture;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = printedTxture;
        }
    }
}
