using UnityEngine;
using UnityEngine.UI;

public class ImageToggleOnHover : MonoBehaviour
{
    public Image image;
    public Image image1;
    public static ImageToggleOnHover instance;
    bool isBtnClick;
    public static string UseCase;
    public static bool Tour_Running = false;
    void Start()
    {
        image.gameObject.SetActive(false); // Hide the image initially
        image1.gameObject.SetActive(false);
        instance = this;

    }


    void OnMouseDown()
    {
        if (Tour_Running == false)
        {
            Tour_Running = true;
            UseCase = transform.GetChild(0).gameObject.name;
            StartCoroutine(Guided_Tour.instance.Loadaudio());
            StartCoroutine(Load_Tour_text.ins.GetAllTexts());
            Guided_Tour.instance.UnClickMenu.SetActive(true);
            ClosedAllWindow();
           Invoke("playguid", 0.5f);

        }


        //image.gameObject.SetActive(true);

        //if(image.gameObject.activeInHierarchy)
        //{
        //    isBtnClick = true; 
        //}
        //else
        //{
        //    isBtnClick = false;
        //}
        //image1.gameObject.SetActive(false);
        //   Debug.Log("image name"+image.name);
    }
    public void ClosedAllWindow()
    {
        BackCardData.instance.DellWindow.SetActive(false);
        BackCardData.instance.PartnerWindow.SetActive(false);
        ImageLoader.instance.BackFlipCard.SetActive(false);
        for (int i = 0; i <= 6; i++)
        {
            ImageLoader.instance.Cards[i].SetActive(false);
        }
    }
    public void playguid()
    { 
        Guided_Tour.instance.PlayGuidedTour(UseCase);  
    }
 
    private void OnMouseOver()
    {
        if(!isBtnClick)
        {
            image1.gameObject.SetActive(true);
        } 
    }
    void OnMouseExit()
    {
        image.gameObject.SetActive(false); // Hide the image when the mouse leaves
        image1.gameObject.SetActive(false);
        isBtnClick = false;
    }
}
