using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCards : MonoBehaviour
{
    public Transform[] points;
    public GameObject[] objects;
   
  
    private int currentIndex = 0;
  

    private void Start()
    {
        StartCoroutine(MoveCard());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            MoveArrayByOne();
        }
    }

    IEnumerator MoveCard()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < points.Length; i++)
        {
            currentIndex += 1;
            LeanTween.move(objects[i], points[currentIndex], 1f);
           
            if (currentIndex == points.Length - 1)
            {
                currentIndex = -1;
            }
          

        }

        MoveArrayByOne();
        MoveArrayByOneOfPoints();
      //  StartCoroutine(MoveCard());
        // StartCoroutine(MoveCard());
        //  LeanTween.move(objects[currentIndex],points[])
        // rotationCounter++;


    }
    // public GameObject[] objects;




    void MoveArrayByOne()
    {
        // Store the last element in a temporary variable
        GameObject temp = objects[objects.Length - 1];

        // Shift all the other elements one index up the array
        for (int i = objects.Length - 2; i >= 0; i--)
        {
            objects[i + 1] = objects[i];
        }

        // Assign the temporary variable to the first index of the array
        objects[0] = temp;
    }

   void MoveArrayByOneOfPoints()
    {
        // Store the last element in a temporary variable
        Transform temp = points[points.Length - 1];

        // Shift all the other elements one index up the array
        for (int i = points.Length - 2; i >= 0; i--)
        {
            points[i + 1] = points[i];
        }

        // Assign the temporary variable to the first index of the array
        points[0] = temp;
    }



    //IEnumerator StartRotatingCard()
    //{
    //    yield return new WaitForSeconds(2f);
    //    MoveCard();

    //    StartCoroutine(StartRotatingCard());
    //    Debug.Log("Rotate Start");
    //}

    //public void MoveCard()
    //{
    //    if(isMoveFirst)
    //    {
    //        //for (int i = cardsSprite.Length - 1; i >= 0; i--)
    //        //{
    //        //    LeanTween.move(cardsSprite[cardIndex], Objposition[i].transform.position, 1f);
    //        //    if(cardIndex == cardsSprite.Length - 1)
    //        //    {
    //        //        cardIndex = 0;
    //        //    }
    //        //    else
    //        //    {
    //        //        cardIndex++;
    //        //    }



    //        //}
    //        //isMoveFirst = false;
    //    }
    //    else
    //    {
    //        for (int i = 0; i < cardsSprite.Length; i++)
    //        {
    //            LeanTween.move(cardsSprite[i+1], Objposition[i].transform.position, 1f);
    //        }
    //       // isMoveFirst = true;
    //    }


    //}
}
