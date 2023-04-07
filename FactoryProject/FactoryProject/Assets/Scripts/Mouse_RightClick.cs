using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_RightClick : MonoBehaviour
{
    public float sensitivity = 5f;
    public float minimumX = -60f;
    public float maximumX = 60f;

    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;

            //Enable this to clamp the rotation
            //   rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationX, transform.localEulerAngles.z);
        }


         if (Input.GetMouseButtonDown(0)) {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0)) {
            Vector3 deltaMousePosition = -(Input.mousePosition - lastMousePosition);
            transform.Translate(new Vector3(deltaMousePosition.x, 0, 0));
            lastMousePosition = Input.mousePosition;
        }


    }
}