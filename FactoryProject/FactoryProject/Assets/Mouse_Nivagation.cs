using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Nivagation : MonoBehaviour
{
    public float rotationSpeed = 10f; // adjust this to control the camera rotation speed
    private float verticalRotation = 0f;
    public bool isDragging = false;
    private Vector2 lastMousePosition;
    public float zoomspeed = 10f;
    public float zoomMin = 1f;
    public float zoomMax = 1f;
    public static Mouse_Nivagation instance;
    //public float zoomSpeed = 100.0f;
    //public float minZoomDistance = 1.0f;
    //public float maxZoomDistance = 10.0f;
    private Vector3 lastMousePosition1;
    public void Start()
    {
        instance = this;
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) // check if left mouse button is pressed
        //{
        //    isDragging = true;
        //    lastMousePosition = Input.mousePosition;
        //}
        //else if (Input.GetMouseButtonUp(0)) // check if left mouse button is released
        //{
        //    isDragging = false;
        //}

        if (Mouse_RightClick.instance.bDragUpDown && Input.GetMouseButton(0)) // check if mouse is being dragged
        {
            Vector2 currentMousePosition = Input.mousePosition;
            float mouseY = currentMousePosition.y - lastMousePosition.y;
            lastMousePosition = currentMousePosition;
            // rotate the camera vertically based on the mouse movement
            verticalRotation -= mouseY * rotationSpeed * Time.deltaTime;
            verticalRotation = Mathf.Clamp(verticalRotation, -50f, 30f); // limit the vertical rotation angle
            // apply the vertical rotation to the camera transform
            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    lastMousePosition = Input.mousePosition;
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition1;
        //    transform.Translate(new Vector3(deltaMousePosition.x, 0, 0));
        //    lastMousePosition = Input.mousePosition;
        //}


    }
}