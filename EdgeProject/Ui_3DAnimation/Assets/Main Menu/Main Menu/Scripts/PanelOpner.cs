using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PanelOpner : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject thinPanel;
    
    public void OpenPanel()
    {
        if(mainPanel != null)
        {
            bool isActive = mainPanel.activeSelf;

            mainPanel.SetActive(!isActive);
        }

        if (thinPanel != null)
        {
            bool isActive = thinPanel.activeSelf;

            thinPanel.SetActive(!isActive);
        }
    }
}
