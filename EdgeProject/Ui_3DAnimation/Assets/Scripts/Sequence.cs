using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    public GameObject[] gameObjectsToTrigger;

    IEnumerator TriggerScriptsInOrder()
    {
        while (true)
        {
            for (int i = 0; i < gameObjectsToTrigger.Length; i++)
            {
                ExpandAndShowTooltip script = gameObjectsToTrigger[i].GetComponent<ExpandAndShowTooltip>();
                
                if (script != null && script.enabled) // Check if script is not null and enabled
                {
                    // Enable the script to trigger it
                    script.enabled = true;
                    
                    // Wait until the script has finished executing
                    yield return new WaitUntil(() => !script.enabled);
                }
            }
        }
    }

    void Start()
    {
        StartCoroutine(TriggerScriptsInOrder());
    }
}

