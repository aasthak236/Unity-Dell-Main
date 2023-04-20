using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;
using TMPro;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
public class ImageLoader : MonoBehaviour
{
   // public GameObject loading;
    //public GameObject fllipbtn;
    [Header("BB")]
    public static ImageLoader instance;
    public TextMeshProUGUI[] Front;
    public TextMeshProUGUI[] Back;
    public string url;
    public GameObject[] Cards;
    public int Tcards;
    public string[] VP;
    public string[] EC;
    public string[] BO;
    public string[] DS;
    public string[] PS;
    public string[] VPr;
    public string[] ECr;
    public string[] BOr;
    public string[] DSr;
    public string[] PSr;
    public GameObject BackFlipCard;
    public Material HexagonInnerColor;
    public Material HexagonOuterColor;
    public Material HexagonMiddleColor;
    public Color ECInnerColor, ECMiddleColor, ECOuterColor;
    public Color VPInnerColor, VPMiddleColor, VPOuterColor;
    public Color BOInnerColor, BOMiddleColor, BOOuterColor;
    public Color DSInnerColor, DSMiddleColor, DSOuterColor;
    public Color PSInnerColor, PSMiddleColor, PSOuterColor;
    public Color CTAInnerColor, CTAMiddleColor, CTAOuterColor;
    public Color NormalColor;
    public Color PressedColor;

    public Color BackColor1, HeadingColor1, TextColor1;
    public Color BackColor2, HeadingColor2, TextColor2;


    public void Awake()
    {
        instance = this;
        url = "https://dell-unity-dev.s3-accelerate.amazonaws.com/Factory+Assets/cards/outcomes.xml";
       

    }
    public void Start()
    {
        BackColor1 = ColorUtility.TryParseHtmlString("#2A145A", out Color color30) ? color30 : Color.white;
        HeadingColor1 = ColorUtility.TryParseHtmlString("#BEAFFF", out Color color31) ? color31 : Color.white;
        TextColor1 = ColorUtility.TryParseHtmlString("#DEDDFF", out Color color32) ? color32 : Color.white;

        BackColor2 = ColorUtility.TryParseHtmlString("#0D2155", out Color color33) ? color33 : Color.white;
        HeadingColor2 = ColorUtility.TryParseHtmlString("#80C7FB", out Color color34) ? color34 : Color.white;
        TextColor2 = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color35) ? color35 : Color.white;


        ECInnerColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color) ? color : Color.white;
        VPInnerColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color1) ? color1 : Color.white;
        BOInnerColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color2) ? color2 : Color.white;
        DSInnerColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color3) ? color3 : Color.white;
        PSInnerColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color4) ? color4 : Color.white;

        ECMiddleColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color5) ? color5 : Color.white;
        VPMiddleColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color6) ? color6 : Color.white;
        BOMiddleColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color7) ? color7 : Color.white;
        DSMiddleColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color8) ? color8 : Color.white;
        PSMiddleColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color9) ? color9 : Color.white;

        ECOuterColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color10) ? color10 : Color.white;
        VPOuterColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color11) ? color11 : Color.white;
        BOOuterColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color12) ? color12 : Color.white;
        DSOuterColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color13) ? color13 : Color.white;
        PSOuterColor = ColorUtility.TryParseHtmlString("#E5F8FF", out Color color14) ? color14 : Color.white;
        NormalColor = ColorUtility.TryParseHtmlString("#0D2155", out Color color20) ? color20 : Color.white;
        PressedColor = ColorUtility.TryParseHtmlString("#0672CB", out Color color21) ? color21 : Color.white;
        StartCoroutine(LoadAllComponentFrontFaces());
        StartCoroutine(LoadAllComponentBackFaces());
    }
    public void SetComponentCategory(string Component)
    {
        StartCoroutine(frontBB(Component));
        StartCoroutine(backBB(Component));
        Invoke("OpenCard", 2f);
    }
    public bool pressed;
    public static string ComponentName;
    public Button[] MenuButton;
    public void OpenCard(string Component)
    {
        for (int i = 0; i <= 4; i++)
        {
            MenuButton[i].GetComponent<Image>().color = NormalColor;
        }
       
        
        BackCardData.instance.StopCoroutineTour();
        BackCardData.instance.DellWindow.SetActive(false);
        BackCardData.instance.PartnerWindow.SetActive(false);
        BackFlipCard.SetActive(false);
        BackCardData.instance.PartnerFrontWindow.SetActive(false);
        BackCardData.instance.DellFrontWindow.SetActive(false);
        for (int i = 0; i <= 6; i++)
        {
            Cards[i].SetActive(false);
        }
        pressed = false;
        if (ComponentName == Component)
        {
            pressed = true;
            ComponentName = null;
        }
        else
        {
            ComponentName = Component;
        }
        

        if (pressed == false)
        {
           
             if (Component == "VP")
            {
               
                CameraZoomTowardPoint.instance.ZoomBack();
                MenuButton[3].GetComponent<Image>().color = PressedColor;
                HexagonInnerColor.color = VPInnerColor;
                HexagonMiddleColor.color = VPMiddleColor;
                HexagonOuterColor.color = VPOuterColor;
                for (int i = 0; i <= VPCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = VP[i].ToString();
                }
                pressed = true;
                for (int i = 0; i <= 13; i++)
                {
                    BackCardData.instance.HotSpot[i].SetActive(false);
                }


            }
            else if (Component == "EC")
            {
               
                CameraZoomTowardPoint.instance.ZoomBack();
                MenuButton[1].GetComponent<Image>().color = PressedColor;
                HexagonInnerColor.color = ECInnerColor;
                HexagonMiddleColor.color = ECMiddleColor;
                HexagonOuterColor.color = ECOuterColor;
                for (int i = 0; i <= ECCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = EC[i].ToString();
                }
                pressed = true;

                for (int i = 0; i <= 13; i++)
                {
                    BackCardData.instance.HotSpot[i].SetActive(false);
                }

            }
            else if (Component == "BO")
            {
                
                //Image myImage = MenuButton[0].image;
                //Color newColor = myImage.color;
                //newColor.a = 255f; // Set the alpha value to 0.5 (half transparent)
                //myImage.color = newColor;
                CameraZoomTowardPoint.instance.ZoomBack();
                MenuButton[0].GetComponent<Image>().color = PressedColor;
                HexagonInnerColor.color = BOInnerColor;
                HexagonMiddleColor.color = BOMiddleColor;
                HexagonOuterColor.color = BOOuterColor;
                for (int i = 0; i <= 5; i++)
                {
                    BackCardData.instance.BusinessOutcomeText[i].text = ImageLoader.instance.BO[i].ToString();

                }
                BackCardData.instance.BusinessOutcomeWindow.SetActive(true);
                for (int i = 0; i <= 13; i++)
                {
                    BackCardData.instance.HotSpot[i].SetActive(false);
                }
                //for (int i = 0; i <= BOCount; i++)
                //{
                //    Cards[i].SetActive(true);
                //    Front[i].text = BO[i].ToString();
                //}
                // pressed = true;


            }
            else if (Component == "DS")
            {
              
                CameraZoomTowardPoint.instance.ZoomBack();
                MenuButton[2].GetComponent<Image>().color = PressedColor;
                HexagonInnerColor.color = DSInnerColor;
                HexagonMiddleColor.color = DSMiddleColor;
                HexagonOuterColor.color = DSOuterColor;
                BackCardData.instance.DellFrontWindow.SetActive(true);
                for (int i = 0; i <= DSCount; i++)
                {
                    //Cards[i].SetActive(true);
                    BackCardData.instance.DellSolutionText[i].text = DS[i].ToString();
                }
                pressed = true;

                for (int i = 0; i <= 13; i++)
                {
                    BackCardData.instance.HotSpot[i].SetActive(false);
                }

            }
            else if (Component == "PS")
            {
                
                CameraZoomTowardPoint.instance.ZoomBack();
                MenuButton[4].GetComponent<Image>().color = PressedColor;
                HexagonInnerColor.color = PSInnerColor;
                HexagonMiddleColor.color = PSMiddleColor;
                HexagonOuterColor.color = PSOuterColor;
                BackCardData.instance.PartnerFrontWindow.SetActive(true);
                for (int i = 0; i <= PSCount; i++)
                {
                   // Cards[i].SetActive(true);
                    BackCardData.instance.PartnerSolutionText[i].text = PS[i].ToString();
                }
                pressed = true;

                for (int i = 0; i <= 13; i++)
                {
                    BackCardData.instance.HotSpot[i].SetActive(false);
                }
            }
        }
       else
        {
            for (int i = 0; i <= 6; i++)
            {
                Cards[i].SetActive(false);
            }
            pressed = false;
            for (int i = 0; i <= 13; i++)
            {
                BackCardData.instance.HotSpot[i].SetActive(true);
            }
            BackCardData.instance.PartnerFrontWindow.SetActive(false);
            BackCardData.instance.DellFrontWindow.SetActive(false);
        }
    }
    public IEnumerator frontBB(string ComponentName)
   {
        for (int i = 1; i <= 6; i++)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
             yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
   {
    string xmlText = www.downloadHandler.text;
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(xmlText);
    XmlNode node = xmlDoc.SelectSingleNode("ms/"+ (ComponentName) + i);
    XmlNode node1 = xmlDoc.SelectSingleNode("ms/" + (ComponentName)+"Count");
    XmlElement root = xmlDoc.DocumentElement;
    string nodeText = node.InnerText;
    Front[i - 1].text = nodeText;
    XmlElement root1 = xmlDoc.DocumentElement;
    string nodeText1 = node1.InnerText;
    Tcards = int.Parse(nodeText1);


            }
        }
    }
    public IEnumerator backBB(string ComponentName)
    {

        for (int i = 1; i <= 5; i++)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/" + (ComponentName) + i + "r");
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                Back[i - 1].text = nodeText;
            }
        }

    }
    public int VPCount;
    public int ECCount;
    public int BOCount;
    public int DSCount;
    public int PSCount;
    public IEnumerator LoadAllComponentFrontFaces()
    {

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            
            for (int i = 0; i <= VPCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/VP" + (i + 1));
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/VP" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                VPCount = int.Parse(nodeText1)-1;
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;                VP[i] = nodeText;
            }
            for (int i = 0; i <= ECCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/EC" + (i + 1));
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/EC" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                ECCount = int.Parse(nodeText1)-1;
                
                
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                EC[i] = nodeText;
            }
            for (int i = 0; i <= BOCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/BO" + (i + 1));
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/BO" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                BOCount = int.Parse(nodeText1)-1;
               
               
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                BO[i] = nodeText;
            }
            for (int i = 0; i <= DSCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/DS" + (i + 1));
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/DS" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                DSCount = int.Parse(nodeText1)-1;
               
               
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                DS[i] = nodeText;
            }

            for (int i = 0; i <= PSCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/PS" + (i + 1));
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/PS" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                PSCount = int.Parse(nodeText1)-1;
                
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                PS[i] = nodeText;
            }




        }
    }
    public IEnumerator LoadAllComponentBackFaces()
    {

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {

            for (int i = 0; i <= VPCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/VP" + (i + 1)+"r");
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/VP" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                VPCount = int.Parse(nodeText1) - 1;
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText; 
                VPr[i] = nodeText;
            }
            for (int i = 0; i <= ECCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/EC" + (i + 1) + "r");
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/EC" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                ECCount = int.Parse(nodeText1) - 1;
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                ECr[i] = nodeText;
            }
            for (int i = 0; i <= BOCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/BO"+(i + 1) + "r");
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/BO" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                BOCount = int.Parse(nodeText1) - 1;


                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                BOr[i] = nodeText;
            }
            for (int i = 0; i <= DSCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/DS" + (i + 1) + "r");
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/DS" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                DSCount = int.Parse(nodeText1) - 1;


                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                DSr[i] = nodeText;
            }

            for (int i = 0; i <= PSCount; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode("ms/PS" + (i + 1) + "r");
                XmlNode node1 = xmlDoc.SelectSingleNode("ms/PS" + "Count");
                XmlElement root1 = xmlDoc.DocumentElement;
                string nodeText1 = node1.InnerText;
                PSCount = int.Parse(nodeText1) - 1;

                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                PSr[i] = nodeText;
            }




        }
    }
    public void loadingbar()
    {
       
    }
  
}
