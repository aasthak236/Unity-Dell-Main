using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class Load_Tour_text : MonoBehaviour
{
    public SaveDataFromXML saveDataFile;
    // public TextMeshProUGUI Front;
    string url;
    public static Load_Tour_text ins;
    public int Indx;
    string nodeText;
    int myInt;



    // Start is called before the first frame update
    public void Awake()
    {
        //uc1 get from hotspot
        ins = this;
        //url = Guided_Tour.instance.Assets_Folder+"cards/"+CameraZoomTowardPoint.USECASE+".xml";
        StartCoroutine(LoadPartnerImages());
        StartCoroutine(LoadDellImages());
        StartCoroutine(Guided_Tour.instance.LoadImgWithUrlPartners());
        StartCoroutine(Guided_Tour.instance.LoadImgWithUrlDell());
    }

    private void Start()
    {
       //StartCoroutine(GetAllTexts());

    }

    public IEnumerator GetAllTexts()
    {
        //Get & Add  Intro Text from file

        // StartCoroutine(Tour_Text("INTRO"));
        StartCoroutine(Tour_Text("IntroStartIndx"));
        StartCoroutine(Tour_Text("IntroEndIndx"));
        //Get & Add  PS Text from file
        StartCoroutine(Tour_Text("PSStartIndx"));
        StartCoroutine(Tour_Text("PSEndIndx"));

        //Get & Add  EC Text from file
        StartCoroutine(Tour_Text("ECStartIndx"));
        StartCoroutine(Tour_Text("ECEndIndx"));

        //Get & Add  TT Text from file
        StartCoroutine(Tour_Text("TTStartIndx"));
        StartCoroutine(Tour_Text("TTEndIndx"));


        //Get & Add  Hardware Text from file
        StartCoroutine(Tour_Text("HARDWAREStartIndx"));
        StartCoroutine(Tour_Text("HARDWAREEndIndx"));


        //Get & Add  Factory outcome Text from file
        StartCoroutine(Tour_Text("FOStartIndx"));
        StartCoroutine(Tour_Text("FOEndIndx"));


        //Get & Add  Business Impact from file
        StartCoroutine(Tour_Text("BIStartIndx"));
        StartCoroutine(Tour_Text("BIEndIndx"));

        //Get & Add  Vision Text from file
        // StartCoroutine(Tour_Text("V"));


        //Get & Add  DES Text from file
        StartCoroutine(Tour_Text("DESStartIndx"));
        StartCoroutine(Tour_Text("DESEndIndx"));

        StartCoroutine(Tour_Text("CTAStartIndx"));
        StartCoroutine(Tour_Text("CTAEndIndx"));

        StartCoroutine(Tour_Text("CTA1"));

        yield return new WaitForSeconds(3f);

        for (int i = saveDataFile.IntroStartIndx; i <= saveDataFile.IntroEndIndx; i++)
        {
            StartCoroutine(Tour_Text("Intro" + i));
            yield return new WaitForSeconds(1f);
            // StartCoroutine(Tour_Text("PSDashboard" + i));
        }

        for (int i = saveDataFile.PSStartIndx; i <= saveDataFile.PSEndIndx; i++)
        {
            StartCoroutine(Tour_Text("PS" + i));
            yield return new WaitForSeconds(1f);
            // StartCoroutine(Tour_Text("PSDashboard" + i));
        }


        for (int i = saveDataFile.ECStartIndx; i <= saveDataFile.ECEndIndx; i++)
        {
            StartCoroutine(Tour_Text("EC" + i));
            yield return new WaitForSeconds(1f);
        }

        for (int i = saveDataFile.TTStartIndx; i <= saveDataFile.TTEndIndx; i++)
        {
            StartCoroutine(Tour_Text("TT" + i));
            yield return new WaitForSeconds(1f);
        }

        for (int i = saveDataFile.FOStartIndx; i <= saveDataFile.FOEndIndx; i++)
        {
            StartCoroutine(Tour_Text("FO" + i));
            yield return new WaitForSeconds(1f);
        }
        for (int i = saveDataFile.BIStartIndx; i <= saveDataFile.BIEndIndx; i++)
        {
            StartCoroutine(Tour_Text("BI" + i));
            yield return new WaitForSeconds(1f);
        }

        //for (int i = saveDataFile.DesStartIndx; i <= saveDataFile.DesEndIndx; i++)
        //{
        //    StartCoroutine(Tour_Text("DES" + i));
        //}

        for (int i = saveDataFile.HARDWAREStartIndx; i <= saveDataFile.HARDWAREEndIndx; i++)
        {
            StartCoroutine(Tour_Text("HARDWARE" + i));
            yield return new WaitForSeconds(1f);

        }

        for (int i = saveDataFile.CtaStartIndx; i <= saveDataFile.CtaEndIndx; i++)
        {
            StartCoroutine(Tour_Text("CTA" + i));
            yield return new WaitForSeconds(1f);

        }
        StartCoroutine(Tour_Text("CTA1"));
        StartCoroutine(Tour_Text("CTA2"));
        StartCoroutine(Tour_Text("CTA3"));
        StartCoroutine(Tour_Text("CTA4"));
    }

    //For Getting String Values
    public IEnumerator Tour_Text(string ComponentName)
    {

        UnityWebRequest www = UnityWebRequest.Get(Guided_Tour.instance.Assets_Folder + "cards/" + ImageToggleOnHover.UseCase + ".xml");
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
            XmlNode node = xmlDoc.SelectSingleNode("fp/" + ComponentName);
            XmlElement root = xmlDoc.DocumentElement;

            if (node != null)
            {
                nodeText = node.InnerText;

            }

           
            //This will remove integer from string
            var output = Regex.Replace(ComponentName, @"[\d-]", string.Empty);

            if (string.IsNullOrEmpty(output))
            {
                output = ComponentName;
            }
            SaveDataAccToKey(output,ComponentName);

        }
    }

    private void SaveDataAccToKey(string output, string componentName)
    {
        switch (componentName)
        {

            case "IntroStartIndx":
                //Indx = saveDataFile.IntroStartIndx;
                saveDataFile.IntroStartIndx = int.Parse(nodeText);
                break;
            case "IntroEndIndx":
                //Indx = saveDataFile.IntroEndIndx;
                saveDataFile.IntroEndIndx = int.Parse(nodeText);

                break;

            case "PSStartIndx":
                //Indx = saveDataFile.PSStartIndx;
                saveDataFile.PSStartIndx = int.Parse(nodeText);
                break;
            case "PSEndIndx":

                saveDataFile.PSEndIndx = int.Parse(nodeText);

                break;

            case "ECStartIndx":
                //Indx = saveDataFile.PSStartIndx;
                saveDataFile.ECStartIndx = int.Parse(nodeText);
                break;
            case "ECEndIndx":
                saveDataFile.ECEndIndx = int.Parse(nodeText);
                break;

            case "TTStartIndx":

                // Indx = saveDataFile.PSStartIndx;
                saveDataFile.TTStartIndx = int.Parse(nodeText);
                break;
            case "TTEndIndx":
                saveDataFile.TTEndIndx = int.Parse(nodeText);
                break;

            case "HARDWAREStartIndx":
                // Indx = saveDataFile.PSStartIndx;
                saveDataFile.HARDWAREStartIndx = int.Parse(nodeText);
                break;
            case "HARDWAREEndIndx":
                saveDataFile.HARDWAREEndIndx = int.Parse(nodeText);
                break;

            case "FOStartIndx":
                // Indx = saveDataFile.PSStartIndx;
                saveDataFile.FOStartIndx = int.Parse(nodeText);
                break;
            case "FOEndIndx":
                saveDataFile.FOEndIndx = int.Parse(nodeText);
                break;

            case "BIStartIndx":
                // Indx = saveDataFile.PSStartIndx;
                saveDataFile.BIStartIndx = int.Parse(nodeText);
                break;
            case "BIEndIndx":
                saveDataFile.BIEndIndx = int.Parse(nodeText);
                break;
            case "CTAStartIndx":
                saveDataFile.CtaStartIndx = int.Parse(nodeText);
                break;

            case "CTAEndIndx":
                saveDataFile.CtaEndIndx = int.Parse(nodeText);
                break;
            case "CTA1":
                saveDataFile.CTA1 = nodeText;
                break;
            case "CTA2":
                saveDataFile.CTA2 = nodeText;
                break;
            case "CTA3":
                saveDataFile.CTA3 = nodeText;
                break;
            case "CTA4":
                saveDataFile.CTA4 = nodeText;
                break;
        }
        switch (output)
        {
            //case "INTRO":
            //    saveDataFile.INTRO = nodeText;
            //    break;
            case "Intro":

                saveDataFile.INTRO.Add(nodeText);

                //  Indx++;
                break;

            case "PS":

                saveDataFile.PS.Add(nodeText);

                //  Indx++;
                break;


            case "EC":
                saveDataFile.EC.Add(nodeText);


                // string temp = saveDataFile.EC[0];

                //saveDataFile.EC[1] = temp;
                //saveDataFile.EC[2] = saveDataFile.EC[1];
                //Indx++;
                break;

            //case "V":
            //    saveDataFile.V = nodeText;
            //    break;



            case "TT":
                saveDataFile.TT.Add(nodeText);

                //Indx++;
                break;



         





            case "HARDWARE":
                saveDataFile.HARDWARE.Add(nodeText);

                //nodeText
                break;




            case "FO":
                saveDataFile.FO.Add(nodeText);

                break;

            case "BI":
                saveDataFile.BI.Add(nodeText);
                break;

            //case "CTA":
            //    saveDataFile.CTA.Add(nodeText);
            //    break;
            case "CTA1":
                saveDataFile.CTA1 = nodeText;
                break;
            case "CTA2":
                saveDataFile.CTA2 = nodeText;
                break;
            case "CTA3":
                saveDataFile.CTA3 = nodeText;
                break;
            case "CTA4":
                saveDataFile.CTA4 = nodeText;
                break;


        }
    }

    //private void OnApplicationQuit()
    //{
    //    saveDataFile.ResetSaveData();
    //}
    public string[] partners;
    public string[] PartnerDescription;
    public string[] PartnersLink;
    public string[] PSVideoLink;
    public string[] Dell;
    public string[] DellDescription;
    public string[] DellLink;
    //public string[] Dell;
    public int PartnerTCount;
    public IEnumerator LoadPartnerImages()
    {
       
            UnityWebRequest www = UnityWebRequest.Get("https://dell-unity-dev.s3.amazonaws.com/Factory+Assets/cards/partners.xml");
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
            XmlNode node1 = xmlDoc.SelectSingleNode("partners/totalcount");
            XmlElement root1 = xmlDoc.DocumentElement;
            string nodeText1 = node1.InnerText;
            PartnerTCount = int.Parse(nodeText1);
            for (int i = 0; i <PartnerTCount; i++)
            {

                XmlNode node = xmlDoc.SelectSingleNode("partners/PS" + (i + 1));
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                partners[i] = nodeText;

                XmlNode node5 = xmlDoc.SelectSingleNode("partners/PSvideo" + (i + 1));
                XmlElement root5 = xmlDoc.DocumentElement;
                string nodeText5= node5.InnerText;
                PSVideoLink[i] = nodeText5;

                XmlNode node3 = xmlDoc.SelectSingleNode("partners/PSlink" + (i + 1));
                XmlElement roo3 = xmlDoc.DocumentElement;
                string nodeText3 = node3.InnerText;
                PartnersLink[i] = nodeText3;

                XmlNode node4 = xmlDoc.SelectSingleNode("partners/PSdesc" + (i + 1));
                XmlElement roo4 = xmlDoc.DocumentElement;
                string nodeText4 = node4.InnerText;
                PartnerDescription[i] = nodeText4;
            }

        }
    }
    public int DellTCount;
    public IEnumerator LoadDellImages()
    {
        
            UnityWebRequest www = UnityWebRequest.Get("https://dell-unity-dev.s3.amazonaws.com/Factory+Assets/cards/dellsolutions.xml");
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
            XmlNode node1 = xmlDoc.SelectSingleNode("ds/totalcount");
            XmlElement root1 = xmlDoc.DocumentElement;
            string nodeText1 = node1.InnerText;
            DellTCount = int.Parse(nodeText1);
            for (int i = 0; i < DellTCount; i++)
            {

                XmlNode node = xmlDoc.SelectSingleNode("ds/DS" + (i + 1));
                XmlElement root = xmlDoc.DocumentElement;
                string nodeText = node.InnerText;
                Dell[i] = nodeText;
               

                XmlNode node3 = xmlDoc.SelectSingleNode("ds/DSlink" + (i + 1));
                XmlElement roo3 = xmlDoc.DocumentElement;
                string nodeText3 = node3.InnerText;
                DellLink[i] = nodeText3;

                XmlNode node4 = xmlDoc.SelectSingleNode("ds/DSdesc" + (i + 1));
                XmlElement roo4 = xmlDoc.DocumentElement;
                string nodeText4 = node4.InnerText;
                DellDescription[i] = nodeText4;
            }

        }
    }


}
