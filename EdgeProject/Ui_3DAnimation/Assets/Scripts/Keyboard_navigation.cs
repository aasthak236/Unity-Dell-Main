using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard_navigation : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public float movementSpeed = 2.0f;
   // public float zoomSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Camera rotation with left and right arrow keys
        float horizontalRotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(Vector3.up, horizontalRotation, Space.World);

        // Camera movement with up and down arrow keys
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed;
        transform.Translate(Vector3.forward * verticalMovement);

        // Camera zoom in/out with page up and page down keys
       // float zoom = Input.GetAxis("Zoom") * zoomSpeed;
       // transform.Translate(Vector3.forward * zoom);

        // Clamp the camera position and zoom to prevent going too far away
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 2.0f, 10.0f), transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.0f, 10.0f), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -10.0f, 10.0f));
    }

}
