using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;
using TMPro;
using System.IO;
using System.Collections.Generic;
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
    public void Awake()
    {
        instance = this;
        url = "https://dell-unity-dev.s3-accelerate.amazonaws.com/Factory+Assets/cards/outcomes.xml";
       

    }
    public void Start()
    {
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
    public void OpenCard(string Component)
    {
        ComponentName = Component;
        if (pressed == false)
        {
             if (Component == "VP")
            {

                for (int i = 0; i <= VPCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = VP[i].ToString();
                }
                pressed = true;



            }
            else if (Component == "EC")
            {

                for (int i = 0; i <= ECCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = EC[i].ToString();
                }
                pressed = true;



            }
            else if (Component == "BO")
            {

                for (int i = 0; i <= BOCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = BO[i].ToString();
                }
                pressed = true;


            }
            else if (Component == "DS")
            {

                for (int i = 0; i <= DSCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = DS[i].ToString();
                }
                pressed = true;



            }
            else if (Component == "PS")
            {

                for (int i = 0; i <= PSCount; i++)
                {
                    Cards[i].SetActive(true);
                    Front[i].text = PS[i].ToString();
                }
                pressed = true;


            }
        }
       else
        {
            for (int i = 0; i <= 6; i++)
            {
                Cards[i].SetActive(false);
            }
            pressed = false;
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
