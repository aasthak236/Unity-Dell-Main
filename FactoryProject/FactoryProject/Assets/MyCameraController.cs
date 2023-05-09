using UnityEngine;

public class MyCameraController : MonoBehaviour
{
   
    // Camera zoom parameters
    public float minFOV = 10f;
    public float maxFOV = 60f;
    public float zoomSpeed = 2f;
    public static MyCameraController instance;
    // Camera pan parameters
    public float panSpeed = 5f;
    public Transform FactoryObject;

    // Mouse button for panning
    public int panMouseButton = 0;

    public void Start()
    {
        instance = this;
    }
    //// Camera rotation parameters
    //public float rotationSpeed = 5f;
    //public float minRotation = -90f;
    //public float maxRotation = 90f;

    public float rotationSpeed = 2.0f;
    public float moveSpeed = 2.0f;
        public float rotateSpeed = 4f;
    private bool isDragging = false;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;
    public void Resetcamera()
    {
        Camera cam = GetComponent<Camera>();
        cam.fieldOfView = 60f;
    }
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


   
        if (CameraZoomTowardPoint.CameraZoom == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                dragStartPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {

                dragCurrentPosition = Input.mousePosition;


                float deltaY = dragCurrentPosition.y - dragStartPosition.y;
                float deltaX = dragCurrentPosition.x - dragStartPosition.x;


                if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
                {
                    //transform.Rotate(-(Vector3.right * deltaY * rotationSpeed * Time.deltaTime));
                    ////transform.position = new Vector3(63, transform.position.y*Time.deltaTime, 61);
                    //float currentRotation = transform.rotation.eulerAngles.x;
                    ////if (Camera_Walk_Control.instance.ImmersiveTourStart == false)
                    ////{
                    ////    float clampedRotation = Mathf.Clamp(currentRotation, -35, 55);
                    ////    transform.rotation = Quaternion.Euler(clampedRotation, transform.rotation.y, transform.rotation.z);
                    ////}
                    ///
                    float mouseX = Input.GetAxis("Mouse X");
                    float mouseY = Input.GetAxis("Mouse Y");
                    //transform.RotateAround(FactoryObject.position, Vector3.up, mouseY * rotateSpeed);
                    transform.RotateAround(FactoryObject.position, transform.right, -mouseY * rotateSpeed);
                   float offset = transform.position.x - 63.5f;
                    Vector3 lookatpoint = new Vector3(FactoryObject.position.x + offset, FactoryObject.position.y, FactoryObject.position.z);
                    transform.LookAt(lookatpoint);


                }

                //else
                //{
                //    float moveX = deltaX * moveSpeed * Time.deltaTime;
                //    transform.Translate(new Vector3(-moveX, 0, 0));
                //    Vector3 clampedPosition = transform.position;
                //    if (Camera_Walk_Control.instance.ImmersiveTourStart == false)
                //    {
                //        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20, 90);

                //        transform.position = clampedPosition;
                //    }
                //}


                dragStartPosition = dragCurrentPosition;
            }
        }
    }
    public void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
