using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;

public class LoadTour : MonoBehaviour
{
    public SaveDataFromXML saveDataFile;
    public TextMeshProUGUI Front;
    public string url;
    public static LoadTour ins;
    // Start is called before the first frame update
    public void Awake()
    {
        ins = this;
        url = "https://dell-unity-dev.s3.amazonaws.com/Assets/cards/FP.xml";
    }
    void Start()
    {
       // StartCoroutine(LoadAllComponentFaces());
       //StartCoroutine(Tour_Text("INTRO", saveDataFile.INTRO));
        // instance = this;
    }
    public IEnumerator Tour_Text(string ComponentName, string saveVariableString)
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
            XmlNode node = xmlDoc.SelectSingleNode( "fp/" + ComponentName);
            XmlElement root = xmlDoc.DocumentElement;
            string nodeText = node.InnerText;
            saveVariableString = nodeText;

        }
    }
    public string[] OutcomeCardFace;
    public string[] BBCardFace;
    public string[] DVSCardFace;
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
           
            for (int i = 1; i <= 5; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/Outcome" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                OutcomeCardFace[i - 1] = nodeText;

            }
            for (int i = 1; i <= 5; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/BB" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                BBCardFace[i - 1] = nodeText;
            }
            for (int i = 1; i <= 5; i++)
            {
                string xmlText = www.downloadHandler.text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName + "/DVS" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                DVSCardFace[i - 1] = nodeText;
            }



        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
