using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;

public class Hower_Active : MonoBehaviour
{
    public TextMeshProUGUI[] HotSpot_Text;
    public string url;
    public GameObject Camanim;
    public static bool Howeractive;
    public static Hower_Active ins;
    // Start is called before the first frame update
    void Start()
    {
        ins = this;
        url = "https://dell-unity-dev.s3-accelerate.amazonaws.com/Assets/cards/" + Module_Name.ModuleName + ".xml";
        StartCoroutine(Tour_Text("Outcome"));
        
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
            for (int i = 1; i <= 5; i++)
            {
                string xmlText = www.downloadHandler.text;
                 XmlDocument xmlDoc = new XmlDocument();
                 xmlDoc.LoadXml(xmlText);
                 XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/" + ComponentName+i);
                 XmlElement root = xmlDoc.DocumentElement;
                 string nodeText = node.InnerText;
                 HotSpot_Text[i-1].text = nodeText;
            }
           

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void offanimator()
    {
        Invoke("waitoff",10f);
        
    }

    public void waitoff()
    {
        Howeractive = true;
        this.gameObject.GetComponent<Animator>().enabled = false;
        Camanim.gameObject.GetComponent<Animator>().enabled = false;
    }
}
