using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickController : MonoBehaviour
{
   public  bool bAutoRotate=true;
   public int DefaultCard = 0;
    public int index;
    public List<Transform> spwanPoints;
    public List<Transform> PlanePoints;
    public static ClickController instance;
    public GameObject[] flipcard;
    

    private void Start()
    {
       
      SetPos();
        //if (bAutoRotate==true)
        //{
        //    Invoke("MoveForward", 5f);
        //}

        instance = this;
    }
   
    public void BAutorotate()
    {
        if (bAutoRotate)
        {
            Invoke("MoveForward", 5f);
        }
   
    }
    public void SetDefault_Card_Value(int DefaultCard)
    {
        for (int i = 0; i <= DefaultCard; i++)
        {
            MoveForward();
        }
    }
    
    public void MoveForward()
    {
       
            foreach (var item in PlanePoints)
            {
                item.GetComponent<ChildDetails>().NextIndex();
            }
        if (bAutoRotate)
        {
            Invoke("animationcard", 3f);
        }
    }


    
    public void MoveBackward()
    {
        foreach (var item in PlanePoints)
        {
            item.GetComponent<ChildDetails>().BackIndex();
            
        }
        Invoke("animationcard", 3f);
        // Invoke("animationcard", 4f);
    }
    public void animationcard()
    {
        if(DetectCard.isRotated==false)
        {
            Invoke("MoveForward", 2f);
        }
        //else
        //{
        //    CancelInvoke("MoveForward");
        //}
        
    }
    public void CancelAllTimer()
    {
        CancelInvoke("animationcard");
        CancelInvoke("MoveForward");
    }
    public GameObject flipbtn;
    public GameObject flipbtn1;
    public GameObject crossbtn;
    public bool backtext;
    public GameObject Plus, Negative;
    public void flipFunction()
    {
        
        for (int i = 0; i <= 4; i++)
        {

            if (ChildDetails.instance.currentIndex == i)
            {
                if (backtext == false)
                {
                    flipcard[i].GetComponent<DetectCard>().RotateMyObjectFrontBtnClick();
                    ImageLoader.instance.Back[i].gameObject.SetActive(true);
                    ImageLoader.instance.Front[i].gameObject.SetActive(false);
                    backtext = true;
                }
                else
                {
                    flipcard[i].GetComponent<DetectCard>().RotateMyObjectFrontBtnClick();
                    ImageLoader.instance.Back[i].gameObject.SetActive(false);
                    ImageLoader.instance.Front[i].gameObject.SetActive(true);
                    backtext = false;
                }
               
            }
            else
            {
                ImageLoader.instance.Back[i].gameObject.SetActive(false);
                ImageLoader.instance.Front[i].gameObject.SetActive(true);
            }
        }
        
    }

    public void SetPos()
    {
        foreach (var item in PlanePoints)
        {
            Transform point = spwanPoints[index];
            item.LeanMoveLocal(point.localPosition, 0.2f);
            item.GetComponent<ChildDetails>().currentIndex = index;
            index++;
            if (index >= PlanePoints.Count)
            {
                index = 0;
            }
        }
    }


    private void Update()
    {
        if (DetectCard.isRotated == true)
        {
            CancelInvoke();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (ChildDetails.OnHovered == false)
            {
              //  Debug.LogError("Mouse is Not Over On Elements");
                return;
            }
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x > Screen.width / 2)
            {
                // right screen
                MoveForward();
                CancelInvoke();
                Invoke("animationcard", 3f);
            }
            else
            {
                // left screen
                MoveBackward();
                CancelInvoke();
                Invoke("animationcard", 3f);

            }
        }

    }
}
