using UnityEngine;
using UnityEngine.UI;

public class ImageToggleOnHover : MonoBehaviour
{
    public Image image;
    public static ImageToggleOnHover instance;
   
    void Start()
    {
        image.gameObject.SetActive(false); // Hide the image initially
        instance = this;
       
    }

    void OnMouseEnter()
    {
        if (Hower_Active.Howeractive == true)
        {
            image.gameObject.SetActive(true);
        }
        
       
     //   Debug.Log("image name"+image.name);
    }

    void OnMouseExit()
    {
        image.gameObject.SetActive(false); // Hide the image when the mouse leaves
    }
}
