using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingAnimation : MonoBehaviour
{
  
     Material material;           // Reference to the material to change color
    public float fadeDuration = 1f;     // Duration of the fade effect in seconds
    public Color startColor = Color.white; // Starting color
    public Color endColor = Color.blue;  // Ending color
    public float waitTime = 2f;         // Wait time between color changes in seconds

    private float currentLerpTime;      // Current lerp time for the fade effect
    private Color currentColor;         // Current color of the material
    private float timeSinceLastChange;  // Time elapsed since last color change

    private void Awake()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }
    void Start()
    {
        // Set the initial color of the material
        material.color = startColor;
        currentColor = startColor;
    }

    void Update()
    {
        // Check if it's time to change color
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= waitTime)
        {
            // Reset time elapsed since last color change
            timeSinceLastChange = 0f;

            // Start fading to the next color
            currentLerpTime = 0f;
        }

        // Update the color with the fade effect
        currentLerpTime += Time.deltaTime;
        float t = currentLerpTime / fadeDuration;
        material.color = Color.Lerp(currentColor, endColor, t);

        // Check if the fade effect is complete
        if (t >= 1.0f)
        {
            // Set the next color as the new starting color
            currentColor = endColor;
        }
    }
}
