using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectmove : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float moveSpeed = 10.0f;

    private bool isDragging = false;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    void Update()
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
            // Get the current position of the mouse
            dragCurrentPosition = Input.mousePosition;

            // Calculate the distance that the mouse has been dragged
            float deltaY = dragCurrentPosition.y - dragStartPosition.y;
            float deltaX = dragCurrentPosition.x - dragStartPosition.x;

            // If the mouse was dragged up/down, rotate the object
            if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
            {
                transform.Rotate(Vector3.right * deltaY * rotationSpeed * Time.deltaTime);
            }
            // If the mouse was dragged left/right, move the object
            else
            {
                float moveX = deltaX * moveSpeed * Time.deltaTime;
                transform.Translate(new Vector3(moveX, 0, 0));
            }

            // Update the drag start position
            dragStartPosition = dragCurrentPosition;
        }
    }
}
