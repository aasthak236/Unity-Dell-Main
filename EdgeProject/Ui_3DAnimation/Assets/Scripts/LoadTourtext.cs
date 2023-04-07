using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;

public class LoadTourtext : MonoBehaviour
{
    public static LoadTourtext ins;
    public TextMeshProUGUI Front;
    public string url = "https://dell-unity-dev.s3.amazonaws.com/Assets/cards/UM.xml";

    // Start is called before the first frame update
    public void Awake()
    {
        ins = this;
    }
    void Start()
    {
      
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
                XmlNode node = xmlDoc.SelectSingleNode("UM/");
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                 Front.text = nodeText;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
