using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform cameraTarget; // The target the camera will look at (e.g., the center of the factory)
    public float panSpeed = 5.0f; // The speed at which the camera pans
    public float rotationSpeed = 2.0f; // The speed at which the camera rotates

    private Vector3 initialOffset; // The initial offset between the camera and target
    private Quaternion initialRotation; // The initial rotation of the camera
    private float angleLimit = 89.0f; // Prevents the camera from going exactly 90 degrees to avoid gimbal lock

    private void Start()
    {
        initialOffset = transform.position - cameraTarget.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Pan the camera left or right
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float deltaY = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            Vector3 newPosition = transform.position;
            newPosition += transform.right * deltaX;
            newPosition += transform.up * deltaY;

            transform.position = newPosition;
            initialOffset = transform.position - cameraTarget.position;
        }

        // Rotate the camera up or down
        if (Input.GetMouseButton(1))
        {
            float deltaAngle = Input.GetAxis("Mouse Y") * rotationSpeed;

            Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x + deltaAngle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
            float targetAngle = targetRotation.eulerAngles.x;

            // Clamp the angle so the camera doesn't rotate too far up or down
           // targetAngle = Mathf.Clamp(targetAngle, 0, angleLimit);

            // Calculate the rotation with the clamped angle
           // Quaternion clampedRotation = Quaternion.Euler(targetAngle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
           // Vector3 newOffset = Quaternion.Euler(0, clampedRotation.eulerAngles.y - initialRotation.eulerAngles.y, 0) * initialOffset;

            // Update the camera's position and rotation
           // transform.position = cameraTarget.position + newOffset;
            //transform.rotation = clampedRotation;

            // Make the camera look at the target
            transform.LookAt(cameraTarget);
        }
    }
}