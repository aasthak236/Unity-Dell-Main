using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factory_move : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float moveSpeed = 10.0f;

    private bool isDragging = false;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    void Update()
    {
        if (CameraZoomTowardPoint.CameraZoom==false)
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
                    transform.Rotate(-(Vector3.right * deltaY * rotationSpeed * Time.deltaTime));
                    //float currentRotation = transform.rotation.eulerAngles.x;
                    //float clampedRotation = Mathf.Clamp(currentRotation, -35, 55);
                    //transform.rotation = Quaternion.Euler(clampedRotation, transform.rotation.y, transform.rotation.z);

                }

                else
                {
                    float moveX = deltaX * moveSpeed * Time.deltaTime;
                    transform.Translate(new Vector3(-moveX, 0, 0));
                    Vector3 clampedPosition = transform.position;
                   // clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20, 90);
                    
                    transform.position = clampedPosition;
                }


                dragStartPosition = dragCurrentPosition;
            }
        }
    }
}
