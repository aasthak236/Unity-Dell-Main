using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class videoStreaming : MonoBehaviour
{
    public RectTransform canvas;
    public RectTransform rawimage;
    public Camera mainCamera;
    public int defaultWidth;
    public int defaultHeight;

    void Start()
    {
        SetCanvasSize(defaultWidth, defaultHeight);
    }

    void Update()
    {
        int currentWidth = Screen.width;
        int currentHeight = Screen.height;

        if (currentWidth != defaultWidth || currentHeight != defaultHeight)
        {
            SetCanvasSize(currentWidth, currentHeight);
        }
    }

    void SetCanvasSize(int width, int height)
    {
        canvas.sizeDelta = new Vector2(width, height);
        rawimage.sizeDelta = new Vector2(width, height);
        //mainCamera.orthographicSize = height / 2;
    }
}