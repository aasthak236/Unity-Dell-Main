using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;
using System;
using System.IO;

public class Load_Tour_text : MonoBehaviour
{

    public TextMeshProUGUI Front;
    public string url;
    public static Load_Tour_text ins;
    // Start is called before the first frame update
    public void Awake()
    {
        ins = this;
        url = Guided_Tour.instance.Assets_Folder + "/cards/" + Module_Name.ModuleName + ".xml";
    }
    void Start()
    {
        StartCoroutine(LoadAllComponentFaces());
        StartCoroutine(LoadAllComponentFacesBack());
        StartCoroutine(LoadAllDellBackCardData());
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
            XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName+"/" + ComponentName);
            XmlElement root = xmlDoc.DocumentElement;
            string nodeText = node.InnerText;
            Front.text = nodeText;

        }
    }
    public string[] OutcomeCardFace;
    public string[] Sub_Outcome;
    public string[] OutcomeCardFaceBack;
    public string[] BBCardFace;
    public string[] BBCardFaceBack;
    public string[] sub_BB;
    public string[] DVSCardFace;
    public string[] DVSCardFaceBack;
    public string[] sub_DVS;
    public string[] Intro;
    public string[] sub_Intro;
    public string[] Ending;
    public string[] sub_Ending;
    public string[] VideoLink;
    public string OutcomeIntro;
    public string BBIntro;
    public string DVSIntro;
    public string[] PartnerGraphics;
    public int[] PartnerGraphicsIndex;
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
             
                    XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/Outcome" + i);
                if (node != null)
                {
                    XmlElement root = xmlDoc.DocumentElement;
                    string nodeText = node.InnerText;
                    OutcomeCardFace[i - 1] = nodeText;
                }
                    
               

                
                    XmlNode nodesub = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/sub_Outcome" + i);
                if (nodesub != null)
                {
                    XmlElement rootsub = xmlDoc.DocumentElement;
                    string nodeTextsub = nodesub.InnerText;
                    Sub_Outcome[i - 1] = nodeTextsub;
                }
               
             

            }
            for (int i = 1; i <= 5; i++)
            {
               
                    XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/BB" + i);
                if (node != null)
                {
                    XmlElement root = xmlDoc.DocumentElement;
                    string nodeText = node.InnerText;
                    BBCardFace[i - 1] = nodeText;
                }
               

               
                    XmlNode nodesub = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/sub_BB" + i);
                if (nodesub != null)
                {
                    XmlElement rootsub = xmlDoc.DocumentElement;
                    string nodeTextsub = nodesub.InnerText;
                    sub_BB[i - 1] = nodeTextsub;
                }
               
               
            }
            for (int i = 1; i <= 5; i++)
            {
                  XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/DVS" + i);
                if (node != null)
                {
                    XmlElement root = xmlDoc.DocumentElement;
                    string nodeText = node.InnerText;
                    DVSCardFace[i - 1] = nodeText;
                }
               

                
              
                    XmlNode nodesub = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/sub_DVS" + i);
                if (nodesub != null)
                {
                    XmlElement rootsub = xmlDoc.DocumentElement;
                    string nodeTextsub = nodesub.InnerText;
                    sub_DVS[i - 1] = nodeTextsub;
                }
              
                
            }

            for (int i = 0; i <= 5; i++)
            {
              
                    XmlNode node1 = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/Intro"+i);
                if (node1 != null)
                {
                    XmlElement root1 = xmlDoc.DocumentElement;
                    string nodeText1 = node1.InnerText;
                    Intro[i] = nodeText1;
                }
                else
                {
                    Debug.Log("node is null");
                }
             
                    XmlNode nodesub = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/sub_Intro" + i);
                if (nodesub != null)
                {
                    XmlElement rootsub = xmlDoc.DocumentElement;
                    string nodeTextsub = nodesub.InnerText;
                    sub_Intro[i] = nodeTextsub;
                }
                else
                {
                    Debug.Log("node is null");
                }

            }
         
            XmlNode node2 = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/OutcomeIntro");
            XmlElement root2 = xmlDoc.DocumentElement;
            string nodeText2 = node2.InnerText;
            OutcomeIntro = nodeText2;
           
            XmlNode node3 = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/BBIntro");
            XmlElement root3 = xmlDoc.DocumentElement;
            string nodeText3 = node3.InnerText;
            BBIntro = nodeText3;
           
            XmlNode node4 = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/DVSIntro");
            XmlElement root4 = xmlDoc.DocumentElement;
            string nodeText4 = node4.InnerText;
            DVSIntro = nodeText4;

            for (int i = 0; i <= 5; i++)
            {
              
                    XmlNode node5 = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/Ending" + i);
                if (node5 != null)
                {
                    XmlElement root5 = xmlDoc.DocumentElement;
                    string nodeText5 = node5.InnerText;
                    Ending[i] = nodeText5;
                }
              
                 XmlNode nodesub = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/sub_Ending" + i);
                if (nodesub != null)
                {
                    XmlElement rootsub = xmlDoc.DocumentElement;
                    string nodeTextsub = nodesub.InnerText;
                    sub_Ending[i] = nodeTextsub;
                }
              

            }


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

                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/Outcome" + i+"r");
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                OutcomeCardFaceBack[i - 1] = nodeText;

            }

            for (int i = 1; i <= 5; i++)
            {

                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/BB" + i + "r");
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                BBCardFaceBack[i - 1] = nodeText;

            }

            for (int i = 1; i <= 5; i++)
            {

                XmlNode node = xmlDoc.SelectSingleNode(Module_Name.ModuleName + "/Graphics" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                VideoLink[i - 1] = nodeText;

            }
        }
    }


    public string[] DS_Image;
    public string[] DS_Link;
    public string[] DS_Detail;
    // Update is called once per frame
    public IEnumerator LoadAllDellBackCardData()
    {

        UnityWebRequest www = UnityWebRequest.Get(Guided_Tour.instance.Assets_Folder + "/cards/validated_solns.xml");
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

            int ListIndex = 0;
            int j = 0;
            for (int i = 1; i <= 5; i++)
            {

                XmlNode node = xmlDoc.SelectSingleNode("ds/DS" + i);
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                DS_Image[i - 1] = nodeText;


                XmlNode nodelink = xmlDoc.SelectSingleNode("ds/DSlink" + i);
                XmlElement rootlink = xmlDoc.DocumentElement;
                string nodeTextlink = nodelink.InnerText;
                DS_Link[i - 1] = nodeTextlink;

                XmlNode nodedetail = xmlDoc.SelectSingleNode("ds/DSdesc" + i);
                XmlElement rootdetail = xmlDoc.DocumentElement;
                string nodeTextdetail = nodedetail.InnerText;
                DS_Detail[i - 1] = nodeTextdetail;
              
                j = 1;
                bool bContinue = true;

                while (bContinue && ListIndex < 50)
                {
                    XmlNode nodegraphics = xmlDoc.SelectSingleNode("ds/Graphics" + (i + 1) + j.ToString("00"));
                    // Debug.Log("partners/Graphics" + (i + 1) + j.ToString("00"));
                    if (nodegraphics != null)
                    {
                        XmlElement rootgraphics = xmlDoc.DocumentElement;
                        string nodeTextgraphics = nodegraphics.InnerText;
                        PartnerGraphics[ListIndex] = nodeTextgraphics;
                        ListIndex++;
                        j++;
                    }
                    else
                    {
                        bContinue = false;
                        PartnerGraphicsIndex[i] = ListIndex;
                    }



                }

            }
        }
    }
}
