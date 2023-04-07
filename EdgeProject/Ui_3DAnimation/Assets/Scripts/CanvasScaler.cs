using UnityEngine;
using UnityEngine.UI;

public class CanvasScaler : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
       // canvas = GetComponent<Canvas>();
        AdjustCanvasSize();
    }

    void AdjustCanvasSize()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float canvasWidth = canvas.GetComponent<RectTransform>().sizeDelta.x;
        float canvasHeight = canvas.GetComponent<RectTransform>().sizeDelta.y;

        float scaleFactor = Mathf.Min(screenWidth / canvasWidth, screenHeight / canvasHeight);
        canvas.scaleFactor = scaleFactor;
    }
}