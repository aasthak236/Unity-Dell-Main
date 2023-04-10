using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_RightClick : MonoBehaviour
{
    public float sensitivity = 2f;
    //public float minimumX = -60f;
    //public float maximumX = 60f;
    public bool bDragLefRight=true;
    public bool bDragUpDown=true;
    private Vector3 lastMousePosition;
    public static Mouse_RightClick instance;
    public void Start()
    {
        bDragUpDown = true;
        bDragLefRight = true;
        lastMousePosition = Input.mousePosition;
        instance = this;
    }
    void Update()
    {
        if (CameraZoomTowardPoint.CameraZoom == true)
        {
            if (Input.GetMouseButton(0))
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;

                //Enable this to clamp the rotation
                //   rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationX, transform.localEulerAngles.z);
            }


            // if (Input.GetMouseButtonDown(0) && bDragUpDown && bDragLefRight) {
            //     float dragDistanceX = Mathf.Abs(Input.mousePosition.x - lastMousePosition.x);
            //    float dragDistanceY = Mathf.Abs(Input.mousePosition.y - lastMousePosition.y);
            //    if (dragDistanceX > dragDistanceY)
            //    {
            //        bDragLefRight = true;
            //        bDragUpDown = false;
            //    }
            //    else
            //    {
            //        bDragLefRight = false;
            //        bDragUpDown = true;
            //    }
            //    lastMousePosition = Input.mousePosition;
            //}

            //if (Input.GetMouseButton(0) && bDragLefRight) {

            //        Vector3 deltaMousePosition = -(Input.mousePosition - lastMousePosition);
            //        transform.Translate(new Vector3(deltaMousePosition.x * 0.1f, 0, 0));
            //        lastMousePosition = Input.mousePosition; 
            //}
            //if (Input.GetMouseButtonUp(0))
            //{
            //    bDragUpDown = true;
            //    bDragLefRight = true;
            //}


        }
    }
}