using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    // Start is called before the first frame update
    //public float sensitivity = 2f;
    //public float speed = 10f;
    //private Vector3 lastPosition;

    public float sensitivity = 2.0f; // mouse sensitivity
    public float minY = -10.0f; // minimum Y rotation angle
    public float maxY = -20; // maximum Y rotation angle

    private float rotationY = 0.0f; // current Y rotation angl

    void Start()
    {
       // lastPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Vector3 delta = Input.mousePosition - lastPosition;
            //transform.Rotate(Vector3.up * delta.x * sensitivity, Space.World);

            ////   Vector3 rotation = Vector3.left * delta.y * sensitivity;
            ////  Mathf.Clamp(rotation.y, -10, 10);
            ////  transform.Rotate(rotation, Space.Self);


            // get the mouse movement
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;

            // calculate the new Y rotation angle
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            // rotate the camera
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        //lastPosition = Input.mousePosition;
    }
}
