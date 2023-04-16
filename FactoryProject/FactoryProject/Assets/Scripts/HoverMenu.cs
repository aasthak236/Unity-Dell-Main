using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMenu : MonoBehaviour
{
    public GameObject CollapsPanel, ExpandPanel;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        float distance = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);
        float height = 2.0f * distance * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float width = height * mainCamera.aspect;
        Vector3 position = new Vector3(mainCamera.transform.position.x + (width * 0.5f), mainCamera.transform.position.y - (height * 0.5f), transform.position.z);
        transform.position = position;
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
