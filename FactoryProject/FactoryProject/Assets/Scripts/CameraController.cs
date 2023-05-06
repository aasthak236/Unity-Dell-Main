using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 2f;
    public float zoomSpeed = 0.8f;
    public float verticalInput;
    private bool guibuttonpressed = false;
    public void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "click me"))
        {
            guibuttonpressed = true;
        }
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
            if (Camera_Walk_Control.instance.ImmersiveTourStart==false)
            {
                newZoomPosition.z = Mathf.Clamp(newZoomPosition.z, 28f, 62f);
                newZoomPosition.y = Mathf.Clamp(newZoomPosition.y, 28f, 50.6f);
            }
                cameraTransform.position = newZoomPosition;
        }
        if (CameraZoomTowardPoint.CameraZoom == false)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            // Calculate new zoom distance
            float newZoomDistance = transform.position.z - (scrollInput * zoomSpeed);
            float newZoomDistanceY = transform.position.y- (scrollInput * zoomSpeed);

            // Clamp zoom distance within min/max range
            if (Camera_Walk_Control.instance.ImmersiveTourStart==false)
            {
                newZoomDistanceY = Mathf.Clamp(newZoomDistanceY, 23f, 50f);
                newZoomDistance = Mathf.Clamp(newZoomDistance, 43.5f, 70.5f);
                transform.position = new Vector3(transform.position.x, newZoomDistanceY, newZoomDistance);
            }
           

            // Set new camera position
            
        }
    }
}