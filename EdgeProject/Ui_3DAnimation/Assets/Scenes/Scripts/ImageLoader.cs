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
    public TextMeshProUGUI[] Front1;
    public TextMeshProUGUI[] Back;
    public string[] gettext;
    public string url;
    public GameObject BackFlipCard;
    public GameObject SC, SS, UM;
    public void Awake()
    {
        instance = this;
        url = Guided_Tour.instance.Assets_Folder + "/cards/" + Module_Name.ModuleName + ".xml";

    }
    public void Start()
    {
        if (Module_Name.ModuleName == "sc")
        {
            SC.SetActive(true);
        }
        else if(Module_Name.ModuleName == "ss")
        {
            SS.SetActive(true);
        }
        else
        {
            UM.SetActive(true);

        }
    }
    //    public IEnumerator frontBB(string ComponentName)
    //   {

    //            UnityWebRequest www = UnityWebRequest.Get(url);
    //             yield return www.SendWebRequest();

    //            if (www.result != UnityWebRequest.Result.Success)
    //            {
    //                Debug.Log(www.error);
    //            }
    //            else
    //   {
    //            for (int i = 1; i <= 5; i++)
    //            {
    //                string xmlText = www.downloadHandler.text;
    //                XmlDocument xmlDoc = new XmlDocument();
    //                xmlDoc.LoadXml(xmlText);
    //                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.instance.ModuleName+"/"+ (ComponentName) + i);
    //                XmlElement root = xmlDoc.DocumentElement;
    //                string nodeText = node.InnerText;
    //                Front[i - 1].text = nodeText;
    //                gettext[i-1] = nodeText;
    //}
    //        }
    //    }
    public void LoadFliperText(string ComponentName)
    {
        if (ComponentName == "BB")
        {
            for (int i = 1; i <= 5; i++)
            {
                Front[i - 1].text = Load_Tour_text.ins.BBCardFace[i-1];
                Back[i - 1].text = Load_Tour_text.ins.BBCardFaceBack[i-1];
                NewCard[i - 1].SetActive(false);
            }
        }
        if (ComponentName == "Outcome")
        {
            for (int i = 1; i <= 5; i++)
            {
                Front[i - 1].text = Load_Tour_text.ins.OutcomeCardFace[i -1].ToString();
                Front[i - 1].text = Load_Tour_text.ins.OutcomeCardFaceBack[i -1].ToString();
            }
        }
        if (ComponentName == "DVS")
        {
            for (int i = 1; i <= 5; i++)
            {
                Front[i - 1].text = Load_Tour_text.ins.DVSCardFace[i - 1].ToString();
                NewCard[i - 1].SetActive(false);
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
                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName+"/" + (ComponentName) + i+"r");
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                Back[i - 1].text = nodeText;
            }
        }

    }
    public GameObject[] NewCard;
    public GameObject OpenCard;
    public bool ispressed;
    public bool pressed;
    public static string ComponentNameGet;
    public void OpenOutcome(string ComponentName)
    {
        pressed = false;
        if (ComponentNameGet == ComponentName)
        {
            pressed = true;
            ComponentName = null;
        }
        else
        {
            ComponentNameGet = ComponentName;
        }
        ComponentNameGet =ComponentName;
        if (pressed == false)
        {
            OpenCard.SetActive(true);
            GUI_Control.instance.DellDetailWindow.SetActive(false);
            GUI_Control.instance.DellSolutionPanel.SetActive(false);
            ispressed = true;
            if (ComponentName == "Outcome")
            {
                GUI_Control.instance.RotatingComponent.SetActive(false);
                GUI_Control.instance.FlipBtn.SetActive(false);
                for (int i = 1; i <= 5; i++)
                {  
                    NewCard[i - 1].SetActive(true);
                    Front1[i - 1].text = Load_Tour_text.ins.OutcomeCardFace[i - 1].ToString();
                }
            }

            if (ComponentName == "BB")
            {
                GUI_Control.instance.RotatingComponent.SetActive(false);
                GUI_Control.instance.FlipBtn.SetActive(false);
                for (int i = 1; i <= 5; i++)
                {
                    NewCard[i - 1].SetActive(true);
                    Front1[i - 1].text = Load_Tour_text.ins.BBCardFace[i - 1].ToString();
                }
            }
        }
        else
        {
            OpenCard.SetActive(false);
            pressed = false;
            
        }
        
       
    }
    public void BackCard()
    {
        for (int i = 1; i <= 5; i++)
        {
            NewCard[i - 1].SetActive(true);
            Front1[i - 1].text = Load_Tour_text.ins.OutcomeCardFace[i - 1].ToString();
        }
        BackFlipCard.SetActive(false);
    }
  

    }
