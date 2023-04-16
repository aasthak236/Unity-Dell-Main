using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 1f;
    public float zoomSpeed = 0.5f;
    public float verticalInput;
   
    public void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }
    void Update()
    {
        if (CameraZoomTowardPoint.CameraZoom == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 newPosition = cameraTransform.position + new Vector3(horizontalInput, 0f, 0f) * movementSpeed;
           // newPosition.x = Mathf.Clamp(newPosition.x, -100f, 100f);
            // transform.position=new Vector3(Mathf.Clamp(transform))
            cameraTransform.position = newPosition;


            float zoomAmount = verticalInput * zoomSpeed;
            Vector3 newZoomPosition = cameraTransform.position - new Vector3(0f, zoomAmount, zoomAmount);
           //newZoomPosition.z = Mathf.Clamp(newZoomPosition.z, 28f, 62f);
          // newZoomPosition.y = Mathf.Clamp(newZoomPosition.y, 28f, 50.6f);
            cameraTransform.position = newZoomPosition;
        }
        if (CameraZoomTowardPoint.CameraZoom == false)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            // Calculate new zoom distance
            float newZoomDistance = transform.position.z - (scrollInput * zoomSpeed);

            // Clamp zoom distance within min/max range
            // newZoomDistance = Mathf.Clamp(newZoomDistance, minZoomDistance, maxZoomDistance);

            // Set new camera position
            transform.position = new Vector3(transform.position.x, newZoomDistance, newZoomDistance);
        }
    }
}