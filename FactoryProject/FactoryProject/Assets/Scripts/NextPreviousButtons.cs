using UnityEngine;
using UnityEngine.UI;

public class NextPreviousButtons : MonoBehaviour
{
    public Button nextButton;
    public Button previousButton;

    private int currentIndex = 0;
    private int maxIndex = 4;

    private void Start()
    {
        
        nextButton.onClick.AddListener(() =>
        {
            currentIndex++;
            if (currentIndex > maxIndex)
            {
                currentIndex = maxIndex;
            }
            
            DisplayContent(currentIndex);
        });

      
        previousButton.onClick.AddListener(() =>
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }
            
            DisplayContent(currentIndex);
        });

        
        DisplayContent(currentIndex);
    }

    private void DisplayContent(int index)
    {
        // Your code to display content based on the current index goes here
        // For example:
        Debug.Log("Displaying content at index " + index);
    }
}
