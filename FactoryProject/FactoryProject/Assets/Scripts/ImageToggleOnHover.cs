
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
 
    public static string HotSpotName;
    void OnMouseDown()
    {
       // int loopcounter;
        if (Tour_Running == false)
        {
            SaveDataFromXML.ins.ResetSaveData();
            Guided_Tour.instance.ClosedAllWindow();
            UseCase = transform.GetChild(0).gameObject.name;
            HotSpotName = transform.GetChild(0).transform.GetChild(0).gameObject.name;
            StartCoroutine(Guided_Tour.instance.Loadaudio());
            StartCoroutine(Load_Tour_text.ins.GetAllTexts());
           // Load_Tour_text.ins.GetAllTexts();
            Guided_Tour.instance.UnClickMenu.SetActive(true);
            
            CameraZoomTowardPoint.instance.ZoomInToSection(int.Parse(HotSpotName));
            Tour_Running = true;
            Invoke("playguid", 1f);
            Guided_Tour.instance.TourStart = true;


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
  
    
    public void playguid()
    { 
        Guided_Tour.instance.PlayGuidedTour(UseCase);  
    }
 
    private void OnMouseOver()
    {
        if(!isBtnClick)
        {
            if (Guided_Tour.instance.TourStart == false)
            {
                image1.gameObject.SetActive(true);
            }
            
        } 
    }
    void OnMouseExit()
    {
        image.gameObject.SetActive(false); // Hide the image when the mouse leaves
        image1.gameObject.SetActive(false);
        isBtnClick = false;
    }
}
