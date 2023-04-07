using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;

public class Load_Tour_text : MonoBehaviour
{

    public TextMeshProUGUI Front;
    public string url;
    public static Load_Tour_text ins;
    // Start is called before the first frame update
    public void Awake()
    {
        ins = this;
        url = "https://dell-unity-dev.s3.amazonaws.com/Assets/cards/" + Module_Name.instance.ModuleName + ".xml";
    }
    void Start()
    {
        StartCoroutine(LoadAllComponentFaces());
        StartCoroutine(LoadAllComponentFacesBack());
        // instance = this;
    }
    public IEnumerator Tour_Text(string ComponentName)
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
            XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName+"/" + ComponentName);
            XmlElement root = xmlDoc.DocumentElement;
            string nodeText = node.InnerText;
            Front.text = nodeText;

        }
    }
    public string[] OutcomeCardFace;
    public string[] OutcomeCardFaceBack;
    public string[] BBCardFace;
    public string[] DVSCardFace;
    public string Intro;
    public string OutcomeIntro;
    public string BBIntro;
    public string DVSIntro;
    public string Ending;
    public IEnumerator LoadAllComponentFaces()
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
            for (int i = 1; i <= 5; i++)
            {
                
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/Outcome" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                OutcomeCardFace[i - 1] = nodeText;

            }
            for (int i = 1; i <= 5; i++)
            {
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/BB" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                BBCardFace[i - 1] = nodeText;
            }
            for (int i = 1; i <= 5; i++)
            {
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/DVS" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                DVSCardFace[i - 1] = nodeText;
            }

        
            XmlNode node1 = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/Intro");
            XmlElement root1 = xmlDoc.DocumentElement;
            string nodeText1 = node1.InnerText;
            Intro = nodeText1;
         
            XmlNode node2 = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/OutcomeIntro");
            XmlElement root2 = xmlDoc.DocumentElement;
            string nodeText2 = node2.InnerText;
            OutcomeIntro = nodeText2;
           
            XmlNode node3 = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/BBIntro");
            XmlElement root3 = xmlDoc.DocumentElement;
            string nodeText3 = node3.InnerText;
            BBIntro = nodeText3;
           
            XmlNode node4 = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/DVSIntro");
            XmlElement root4 = xmlDoc.DocumentElement;
            string nodeText4 = node4.InnerText;
            DVSIntro = nodeText4;
           
            XmlNode node5 = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/Ending");
            XmlElement root5 = xmlDoc.DocumentElement;
            string nodeText5 = node5.InnerText;
            Ending = nodeText5;


        }
    }
    public IEnumerator LoadAllComponentFacesBack()
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
            for (int i = 1; i <= 5; i++)
            {

                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/Outcome" + i+"r");
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                OutcomeCardFaceBack[i - 1] = nodeText;

            }
        }
    }
            // Update is called once per frame
            void Update()
    {
        
    }
}
