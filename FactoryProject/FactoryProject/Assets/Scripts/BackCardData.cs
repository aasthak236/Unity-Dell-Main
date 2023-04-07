using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class BackCardData : MonoBehaviour
{
    public Button[] OutcomeBtn;
    //Partner Component
    public TextMeshProUGUI[] BusinessOutcomeText;
    public TextMeshProUGUI BackCardText;
    public TextMeshProUGUI PartnerName;
    public Image PartnerImage;
    public TextMeshProUGUI PartnerDescription;
    public string buttonName;
    public GameObject PartnerWindow;

    //Dell Component
    public TextMeshProUGUI DellName;
    public Image DellImage;
    public TextMeshProUGUI DellDescription;
    public GameObject DellWindow;
    public GameObject BusinessOutcomeWindow;
    public GameObject[] HotSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowBackFlipper()
    {
        
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
         buttonName = clickedButton.name;
       // BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
        //  BackCardLowerText.text = Load_Tour_text.ins.DVSCardFace[int.Parse(buttonName)].ToString();
        if (ImageLoader.ComponentName == "VP")
        {
            for (int i = 0; i <= 6; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            //old flipper
            ImageLoader.instance.BackFlipCard.SetActive(true);
            BackCardText.text = ImageLoader.instance.VPr[int.Parse(buttonName)].ToString();
           
        }
        else if (ImageLoader.ComponentName == "EC")
        {
            for (int i = 0; i <= 5; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            //old flipper
            ImageLoader.instance.BackFlipCard.SetActive(true);
            BackCardText.text = ImageLoader.instance.ECr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "BO")
        {
            Color NormalColor = ColorUtility.TryParseHtmlString("#036495", out Color color) ? color : Color.white;
            Color PressedColor = ColorUtility.TryParseHtmlString("#0F84BB", out Color color1) ? color1 : Color.white;
            for (int i = 0; i <= 13; i++)
            {
                HotSpot[i].SetActive(false);
            }
            for (int i = 0; i <=5; i++)
            {
                BusinessOutcomeText[i].text = ImageLoader.instance.BO[i].ToString();
                ImageLoader.instance.Cards[i].SetActive(false);
                if (OutcomeBtn[int.Parse(buttonName)] == OutcomeBtn[i])
                {
                    OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = PressedColor;
                }
                else
                {
                   // OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = NormalColor;
                }
            }
           
            BusinessOutcomeWindow.SetActive(true);

            if (int.Parse(buttonName) == 0)
            {
                HotSpot[0].SetActive(true);
                HotSpot[3].SetActive(true);
                HotSpot[5].SetActive(true);
                HotSpot[7].SetActive(true);
                HotSpot[1].SetActive(true);
                HotSpot[13].SetActive(true);
            }
            else if (int.Parse(buttonName) == 1)
            {
                HotSpot[3].SetActive(true);
                HotSpot[5].SetActive(true);
                HotSpot[7].SetActive(true);
                HotSpot[2].SetActive(true);

            }
            else if (int.Parse(buttonName) == 2)
            {
                HotSpot[0].SetActive(true);
                HotSpot[5].SetActive(true);
                HotSpot[7].SetActive(true);
                HotSpot[13].SetActive(true);

            }
            else if (int.Parse(buttonName) == 3)
            {
                HotSpot[4].SetActive(true);
                HotSpot[11].SetActive(true);
                HotSpot[1].SetActive(true);

            }
            else if (int.Parse(buttonName) == 4)
            {
                HotSpot[10].SetActive(true);
                HotSpot[11].SetActive(true);
                HotSpot[6].SetActive(true);
                HotSpot[13].SetActive(true);

            }
            else
            {
                HotSpot[12].SetActive(true);
            }

            // BackCardText.text = ImageLoader.instance.BOr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "DS")
        {
            for (int i = 0; i <= 5; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(false);
            }
            DellWindow.SetActive(true);
            // name, 
            DellName.text = ImageLoader.instance.DS[int.Parse(buttonName)];
            // image,
            StartCoroutine(LoadDellImageWithUrlPartners(Load_Tour_text.ins.Dell[int.Parse(buttonName)])); ;
           // Guided_Tour.instance.PartnerImg[int.Parse(buttonName)].gameObject.SetActive(true);
            // desc,
            DellDescription.text = Load_Tour_text.ins.DellDescription[int.Parse(buttonName)];
        }
        else if (ImageLoader.ComponentName == "PS")
        {
            for (int i = 0; i <= 6; i++)
            { 
                ImageLoader.instance.Cards[i].SetActive(false);
            }
                PartnerWindow.SetActive(true);
            // BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
            // name, 
            PartnerName.text= ImageLoader.instance.PS[int.Parse(buttonName)];
            // image,
            StartCoroutine(LoadImageWithUrlPartners(Load_Tour_text.ins.partners[int.Parse(buttonName)]));
           // Guided_Tour.instance.PartnerImg[int.Parse(buttonName)].gameObject.SetActive(true);
            // desc,
            PartnerDescription.text = Load_Tour_text.ins.PartnerDescription[int.Parse(buttonName)];
            // link, More Details
           // video 
        }

    }
    public void parntnerclose()
    {
        for (int i = 0; i <= 5; i++)
        {
            ImageLoader.instance.Cards[i].SetActive(true);
        }
    }
    public void Dellclose()
    {
        for (int i = 0; i <= 5; i++)
        {
            ImageLoader.instance.Cards[i].SetActive(true);
        }
    }
    public void ValuePillarsclose()
    {
        if (ImageLoader.ComponentName == "EC")
        {
            for (int i = 0; i <= 4; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i <= 5; i++)
            {
                ImageLoader.instance.Cards[i].SetActive(true);
            }
        }
    }
    //public void OutcomeBtnF(int ButtonNaame)
    //{
    //    OutcomeBtn[ButtonNaame].GetComponent<Image>().color = Color.blue;
    //    BusinessOutcomeWindow.SetActive(true);

    //    if (ButtonNaame == 0)
    //    {
    //        HotSpot[0].SetActive(true);
    //        HotSpot[3].SetActive(true);
    //        HotSpot[5].SetActive(true);
    //        HotSpot[7].SetActive(true);
    //        HotSpot[1].SetActive(true);
    //        HotSpot[13].SetActive(true);
    //    }
    //    else if (ButtonNaame == 1)
    //    {
    //        HotSpot[3].SetActive(true);
    //        HotSpot[5].SetActive(true);
    //        HotSpot[7].SetActive(true);
    //        HotSpot[2].SetActive(true);

    //    }
    //    else if (ButtonNaame == 2)
    //    {
    //        HotSpot[0].SetActive(true);
    //        HotSpot[5].SetActive(true);
    //        HotSpot[7].SetActive(true);
    //        HotSpot[13].SetActive(true);

    //    }
    //    else if (ButtonNaame == 3)
    //    {
    //        HotSpot[4].SetActive(true);
    //        HotSpot[11].SetActive(true);
    //        HotSpot[1].SetActive(true);

    //    }
    //    else if (ButtonNaame == 4)
    //    {
    //        HotSpot[10].SetActive(true);
    //        HotSpot[11].SetActive(true);
    //        HotSpot[6].SetActive(true);
    //        HotSpot[13].SetActive(true);

    //    }
    //    else
    //    {
    //        HotSpot[12].SetActive(true);
    //    }
    //}
    public void OutcomeCrossBtn()
    {
        for (int i = 0; i <= 13; i++)
        {
            HotSpot[i].SetActive(true);
        }
        BusinessOutcomeWindow.SetActive(false);
        //  OutcomeBtn[int.Parse(buttonName)].GetComponent<Image>().color = ColorUtility.TryParseHtmlString("FFFFFF",out Color32(255,255,255,157));
    }
    public void PartnerLink()
    {
        Application.OpenURL(Load_Tour_text.ins.PartnersLink[int.Parse(buttonName)]);
    }
    public IEnumerator LoadImageWithUrlPartners(string ImageLink)
    {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageLink))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(request);

                    // Create a sprite from the texture and assign it to the Image component
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                    PartnerImage.sprite = sprite;
                }
                else
                {
                    Debug.LogError("Image download failed: " + request.error);
                }
            }
        



    }
    public IEnumerator LoadDellImageWithUrlPartners(string ImageLink)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageLink))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);

                // Create a sprite from the texture and assign it to the Image component
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                DellImage.sprite = sprite;
            }
            else
            {
                Debug.LogError("Image download failed: " + request.error);
            }
        }




    }

}
