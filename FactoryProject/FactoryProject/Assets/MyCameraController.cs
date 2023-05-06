using UnityEngine;

public class MyCameraController : MonoBehaviour
{
   
    // Camera zoom parameters
    public float minFOV = 10f;
    public float maxFOV = 60f;
    public float zoomSpeed = 2f;

    // Camera pan parameters
    public float panSpeed = 5f;

    // Mouse button for panning
    public int panMouseButton = 0;


    //// Camera rotation parameters
    //public float rotationSpeed = 5f;
    //public float minRotation = -90f;
    //public float maxRotation = 90f;

    // Update is called once per frame
    void Update()
    {
        //// Zoom with mouse scroll wheel
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //transform.Translate(Vector3.forward * scroll * zoomSpeed);

        //// Clamp the zoom
        //transform.position = new Vector3(
        //    transform.position.x,
        //    Mathf.Clamp(transform.position.y, minZoom, maxZoom),
        //    transform.position.z
        //);


        // Zoom with mouse scroll wheel
        if (CameraZoomTowardPoint.CameraZoom == false)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Camera cam = GetComponent<Camera>();
           float newFOV = cam.fieldOfView - scroll * zoomSpeed;
            //if (Camera_Walk_Control.instance.ImmersiveTourStart == false)
            //{
                cam.fieldOfView = Mathf.Clamp(newFOV, minFOV, maxFOV);
           // }

        // Pan with left mouse button
       
            if (Input.GetMouseButton(panMouseButton))
            {
                float horizontalMovement = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;

                transform.Translate(-Vector3.right * horizontalMovement);
                float clampX = Mathf.Clamp(transform.position.x, -20, 90);
                transform.position = new Vector3(clampX, transform.position.y, transform.position.z);

            }
        }


        //// Rotate with up and down mouse movement
        //float rotation = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        //float newRotation = transform.eulerAngles.x - rotation;
        //transform.eulerAngles = new Vector3(
        //    Mathf.Clamp(newRotation, minRotation, maxRotation),
        //    transform.eulerAngles.y,
        //    transform.eulerAngles.z
        //);

    }
}
