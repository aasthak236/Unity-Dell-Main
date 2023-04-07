 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainButtonScript : MonoBehaviour
{
    [SerializeField] Vector2 spacing;

    Button mainButton;
    MenuItem[] menuItems;


    bool isExpanded = false;

    Vector2 mainButtonPosition; 
    int itemsCount;
    void Start()
    {
        itemsCount = transform.childCount -1;
        menuItems = new MenuItem[itemsCount];

        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i+1).GetComponent<MenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        ResetPosition();
    }

    void ResetPosition()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].itemTransform.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].itemTransform.position = mainButtonPosition + spacing * (i + 1);
            }
        }

        else
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].itemTransform.position = mainButtonPosition;
            }
        }
    }

    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
