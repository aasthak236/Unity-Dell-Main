using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    [HideInInspector] public Image img; 
    [HideInInspector] public Transform itemTransform;
    void Awake()
    { 
      img = GetComponent<Image>();

      itemTransform = transform;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
