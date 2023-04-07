using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target; // The object to rotate around
    public float rotateSpeed = 5.0f; // The speed of rotation
    public float zoomSpeed = 2.0f; // The speed of zooming
    public float minZoomDistance = 1.0f; // The minimum distance the camera can be from the target
    public float maxZoomDistance = 10.0f; // The maximum distance the camera can be from the target

    private float distance ; // The distance between the camera and the target
    private Vector3 offset; // The initial offset from the target

    private float xRotation; // The current rotation around the x axis
    private float yRotation; // The current rotation around the y axis

    private void Start()
    {
        distance = Vector3.Distance(transform.position, target.position); // Calculate the initial distance
        offset = transform.position - target.position; // Calculate the initial offset
        //xRotation = 45f;
        yRotation = 34f;
    }

    private void LateUpdate()
    {
        // Rotate the camera around the target
        if (Input.GetMouseButton(0))
        {
            xRotation += Input.GetAxis("Mouse X") * rotateSpeed;
            yRotation -= Input.GetAxis("Mouse Y") * rotateSpeed;
        }

        // Zoom in and out
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        distance -= zoom * zoomSpeed;
        distance = Mathf.Clamp(distance, minZoomDistance, maxZoomDistance);

        // Calculate the camera position and rotation
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

        // Update the camera position and rotation
        transform.rotation = rotation;
        transform.position = position;
    }
}
