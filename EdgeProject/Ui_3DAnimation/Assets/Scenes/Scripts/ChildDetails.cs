using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDetails : MonoBehaviour
{
    public static bool OnHovered;
    public int currentIndex;
    public static ChildDetails instance;
    public void Start()
    {
        
        instance = this;
    }
    public void NextIndex()
    {
        if (DetectCard.isRotated == false)
        {
            ClickController controller = this.GetComponentInParent<ClickController>();
            currentIndex++;
            if (currentIndex >= controller.PlanePoints.Count) currentIndex = 0;

            this.transform.LeanMoveLocal(controller.spwanPoints[currentIndex].localPosition, 0.5f);
        }
           
    }

    public void Update()
    {
      
    }
   
    public void BackIndex()
    {
        if (DetectCard.isRotated == false)
        {
            ClickController controller = this.GetComponentInParent<ClickController>();
            currentIndex--;
            if (currentIndex < 0) currentIndex = controller.spwanPoints.Count - 1;

            this.transform.LeanMoveLocal(controller.spwanPoints[currentIndex].localPosition, 0.5f);
        }
            
    }

    private void OnMouseEnter()
    {
       
    }
    private void OnMouseExit()
    {
        OnHovered = false;
    }

    private void OnMouseOver()
    {
        OnHovered = true;
    }
}
