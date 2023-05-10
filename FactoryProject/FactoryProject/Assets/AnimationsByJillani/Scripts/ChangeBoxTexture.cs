using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxTexture : MonoBehaviour
{
    public Material printedTxture;
    public Material wrongPrintedTxture;
    int boxMovedFromtrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = printedTxture;
            boxMovedFromtrigger++;

            if(boxMovedFromtrigger >= 3)
            {
                boxMovedFromtrigger = 0;
                other.gameObject.GetComponent<MeshRenderer>().material = wrongPrintedTxture;
                other.gameObject.tag = "WrongBox";

            }
        }
    }
}
