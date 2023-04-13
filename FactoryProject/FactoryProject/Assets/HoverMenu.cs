using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMenu : MonoBehaviour
{
    public GameObject CollapsPanel, ExpandPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (gameObject.CompareTag("Menu"))
        {
            ExpandPanel.SetActive(true);
            CollapsPanel.SetActive(false);
        }
      
    }
    void OnMouseExit()
    {
        if (gameObject.CompareTag("Menu"))
        {

            ExpandPanel.SetActive(false);
            CollapsPanel.SetActive(true);
        }
    }
}
