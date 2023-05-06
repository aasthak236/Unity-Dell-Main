using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // Reference to the main camera
    private Camera mainCamera;

    private void Start()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Calculate the direction to the main camera
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;

        // Flatten the direction so that it only points in the x-z plane
        directionToCamera.y = 0f;

        // If the direction is not zero (to avoid errors), rotate the object to face the camera
        if (directionToCamera != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionToCamera);
        }
    }
}
