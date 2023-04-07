using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxSlotMovement : MonoBehaviour
{

    float boxSlot_1_Pos;
    [HideInInspector] public bool stopBox_1;

   
    private void Start()
    {
        StartCoroutine(MoveBoxSlot1());
    }
    public IEnumerator  MoveBoxSlot1()
    {
        if (stopBox_1 == false)
        {
            boxSlot_1_Pos = transform.position.x;
            boxSlot_1_Pos += 1;
            LeanTween.moveX(this.gameObject, boxSlot_1_Pos, 1.5f);
            yield return new WaitForSeconds(2f);
            StartCoroutine(MoveBoxSlot1());

        }

    }

    
}
