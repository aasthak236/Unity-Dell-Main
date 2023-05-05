using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.IO;

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

    //public IEnumerator GetAllTexts()
    //public IEnumerator GetAllTexts()
    //{
    //    //Get & Add  Intro Text from file

    //    // StartCoroutine(Tour_Text("INTRO"));

    //    StartCoroutine(Tour_Text("IntroEndIndx"));
    //    //Get & Add  PS Text from file
    //    StartCoroutine(Tour_Text("Intro0"));
    //    StartCoroutine(Tour_Text("PSEndIndx"));

    //    //Get & Add  EC Text from file

    //    StartCoroutine(Tour_Text("ECEndIndx"));

    //    //Get & Add  TT Text from file

    //    StartCoroutine(Tour_Text("TTEndIndx"));


    //    //Get & Add  Hardware Text from file

    //    StartCoroutine(Tour_Text("HARDWAREEndIndx"));


    //    //Get & Add  Factory outcome Text from file

    //    StartCoroutine(Tour_Text("FOEndIndx"));


    //    //Get & Add  Business Impact from file

    //    StartCoroutine(Tour_Text("BIEndIndx"));

    //    //Get & Add  Vision Text from file
    //    // StartCoroutine(Tour_Text("V"));


    //    //Get & Add  DES Text from file

    //    StartCoroutine(Tour_Text("DESEndIndx"));






    //    yield return new WaitForSeconds(3f);

    //    for (int i = 1; i <= saveDataFile.IntroEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("Intro" + i));
    //        yield return new WaitForSeconds(1f);
    //        // StartCoroutine(Tour_Text("PSDashboard" + i));
    //    }

    //    for (int i = 1; i <= saveDataFile.PSEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("PS" + i));
    //        yield return new WaitForSeconds(1f);
    //        // StartCoroutine(Tour_Text("PSDashboard" + i));
    //    }


    //    for (int i = 1; i <= saveDataFile.ECEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("EC" + i));
    //        yield return new WaitForSeconds(1f);
    //    }

    //    for (int i = 1; i <= saveDataFile.TTEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("TT" + i));
    //        yield return new WaitForSeconds(1f);
    //    }

    //    for (int i = 1; i <= saveDataFile.FOEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("FO" + i));
    //        yield return new WaitForSeconds(1f);
    //    }
    //    for (int i = 1; i <= saveDataFile.BIEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("BI" + i));
    //        yield return new WaitForSeconds(1f);
    //    }

    //    //for (int i = saveDataFile.DesStartIndx; i <= saveDataFile.DesEndIndx; i++)
    //    //{
    //    //    StartCoroutine(Tour_Text("DES" + i));
    //    //}

    //    for (int i = 1; i <= saveDataFile.HARDWAREEndIndx; i++)
    //    {
    //        StartCoroutine(Tour_Text("HARDWARE" + i));
    //        yield return new WaitForSeconds(1f);

    //    }


    //    StartCoroutine(Tour_Text("CTA1"));
    //    StartCoroutine(Tour_Text("CTA2"));
    //    StartCoroutine(Tour_Text("CTA3"));
    //    StartCoroutine(Tour_Text("CTA4"));
    //}

    public void ProcessFileContent(string content)
    {
        
        using (TextReader textReader = new StringReader(content))
        {
            using (XmlReader reader = XmlReader.Create(textReader))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "IntroEndIndx":
                                //Indx = saveDataFile.IntroEndIndx;
                                saveDataFile.IntroEndIndx = int.Parse(reader.ReadString());

                                break;

                            case "ECEndIndx":
                                saveDataFile.ECEndIndx = int.Parse(reader.ReadString());
                                break;


                            case "HARDWAREEndIndx":
                                saveDataFile.HARDWAREEndIndx = int.Parse(reader.ReadString());
                                break;

                            case "TTEndIndx":
                                saveDataFile.TTEndIndx = int.Parse(reader.ReadString());
                                break;




                            case "PSEndIndx":

                                saveDataFile.PSEndIndx = int.Parse(reader.ReadString());

                                break;

                            case "FOEndIndx":
                                saveDataFile.FOEndIndx = int.Parse(reader.ReadString());
                                break;


                            case "BIEndIndx":
                                saveDataFile.BIEndIndx = int.Parse(reader.ReadString());
                                break;


                            case "CTA1":
                                saveDataFile.CTA1 = reader.ReadString();
                                break;
                            case "CTA2":
                                saveDataFile.CTA2 = reader.ReadString();
                                break;
                            case "CTA3":
                                saveDataFile.CTA3 = reader.ReadString();
                                break;
                            case "CTA4":
                                saveDataFile.CTA4 = reader.ReadString();
                                break;


                            case "EC1":
                                saveDataFile.EC[0] = reader.ReadString();
                                break;
                            case "EC2":
                                saveDataFile.EC[1] = reader.ReadString();
                                break;
                            case "EC3":
                                saveDataFile.EC[2] = reader.ReadString();
                                break;
                            case "EC4":
                                saveDataFile.EC[3] = reader.ReadString();
                                break;
                            case "EC5":
                                saveDataFile.EC[4] = reader.ReadString();
                                break;

                                //img

                            case "img_EC1":
                                saveDataFile.Img_EC[0] = reader.ReadString();
                                break;
                            case "img_EC2":
                                saveDataFile.Img_EC[1] = reader.ReadString();
                                break;
                            case "img_EC3":
                                saveDataFile.Img_EC[2] = reader.ReadString();
                                break;
                            case "img_EC4":
                                saveDataFile.Img_EC[3] = reader.ReadString();
                                break;
                            case "img_EC5":
                                saveDataFile.Img_EC[4] = reader.ReadString();
                                break;
                            case "introvideo":
                                saveDataFile.IntroVideo = reader.ReadString();
                                break;
                            case "ecvideo":
                                saveDataFile.ECVideo = reader.ReadString();
                                break;

                            //sub

                            case "sub_EC1":
                                saveDataFile.Sub_EC[0] = reader.ReadString();
                                break;
                            case "sub_EC2":
                                saveDataFile.Sub_EC[1] = reader.ReadString();
                                break;
                            case "sub_EC3":
                                saveDataFile.Sub_EC[2] = reader.ReadString();
                                break;
                            case "sub_EC4":
                                saveDataFile.Sub_EC[3] = reader.ReadString();
                                break;
                            case "sub_EC5":
                                saveDataFile.Sub_EC[4] = reader.ReadString();
                                break;

                            //INTRO

                            case "Intro0":
                                saveDataFile.INTRO[0] = reader.ReadString();
                                break;
                            case "Intro1":
                                saveDataFile.INTRO[1] = reader.ReadString();
                                break;
                            case "Intro2":
                                saveDataFile.INTRO[2] = reader.ReadString();
                                break;
                            case "Intro3":
                                saveDataFile.INTRO[3] = reader.ReadString();
                                break;
                            case "Intro4":
                                saveDataFile.INTRO[4] = reader.ReadString();
                                break;

                            //img

                            case "img_Intro1":
                                saveDataFile.Img_INTRO[0] = reader.ReadString();
                                break;
                            case "img_Intro2":
                                saveDataFile.Img_INTRO[1] = reader.ReadString();
                                break;
                            case "img_Intro3":
                                saveDataFile.Img_INTRO[2] = reader.ReadString();
                                break;
                            case "img_Intro4":
                                saveDataFile.Img_INTRO[3] = reader.ReadString();
                                break;
                            case "img_Intro5":
                                saveDataFile.Img_INTRO[4] = reader.ReadString();
                                break;

                            //sub

                            case "sub_Intro1":
                                saveDataFile.Sub_INTRO[0] = reader.ReadString();
                                break;
                            case "sub_Intro2":
                                saveDataFile.Sub_INTRO[1] = reader.ReadString();
                                break;
                            case "sub_Intro3":
                                saveDataFile.Sub_INTRO[2] = reader.ReadString();
                                break;
                            case "sub_Intro4":
                                saveDataFile.Sub_INTRO[3] = reader.ReadString();
                                break;
                            case "sub_Intro5":
                                saveDataFile.Sub_INTRO[4] = reader.ReadString();
                                break;



                            //Hardware

                            case "HARDWARE1":
                                saveDataFile.HARDWARE[0] = reader.ReadString();
                                break;
                            case "HARDWARE2":
                                saveDataFile.HARDWARE[1] = reader.ReadString();
                                break;
                            case "HARDWARE3":
                                saveDataFile.HARDWARE[2] = reader.ReadString();
                                break;
                            case "HARDWARE4":
                                saveDataFile.HARDWARE[3] = reader.ReadString();
                                break;
                            case "HARDWARE5":
                                saveDataFile.HARDWARE[4] = reader.ReadString();
                                break;

                            //img

                            case "img_HARDWARE1":
                                saveDataFile.Img_HARDWARE[0] = reader.ReadString();
                                break;
                            case "img_HARDWARE2":
                                saveDataFile.Img_HARDWARE[1] = reader.ReadString();
                                break;
                            case "img_HARDWARE3":
                                saveDataFile.Img_HARDWARE[2] = reader.ReadString();
                                break;
                            case "img_HARDWARE4":
                                saveDataFile.Img_HARDWARE[3] = reader.ReadString();
                                break;
                            case "img_HARDWARE5":
                                saveDataFile.Img_HARDWARE[4] = reader.ReadString();
                                break;

                            //sub

                            case "sub_HARDWARE1":
                                saveDataFile.Sub_HARDWARE[0] = reader.ReadString();
                                break;
                            case "sub_HARDWARE2":
                                saveDataFile.Sub_HARDWARE[1] = reader.ReadString();
                                break;
                            case "sub_HARDWARE3":
                                saveDataFile.Sub_HARDWARE[2] = reader.ReadString();
                                break;
                            case "sub_HARDWARE4":
                                saveDataFile.Sub_HARDWARE[3] = reader.ReadString();
                                break;
                            case "sub_HARDWARE5":
                                saveDataFile.Sub_HARDWARE[4] = reader.ReadString();
                                break;


                            //tt

                            case "TT1":
                                saveDataFile.TT[0] = reader.ReadString();
                                break;
                            case "TT2":
                                saveDataFile.TT[1] = reader.ReadString();
                                break;
                            case "TT3":
                                saveDataFile.TT[2] = reader.ReadString();
                                break;
                            case "TT4":
                                saveDataFile.TT[3] = reader.ReadString();
                                break;
                            case "TT5":
                                saveDataFile.TT[4] = reader.ReadString();
                                break;


                            //img

                            case "img_TT1":
                                saveDataFile.Img_TT[0] = reader.ReadString();
                                break;
                            case "img_TT2":
                                saveDataFile.Img_TT[1] = reader.ReadString();
                                break;
                            case "img_TT3":
                                saveDataFile.Img_TT[2] = reader.ReadString();
                                break;
                            case "img_TT4":
                                saveDataFile.Img_TT[3] = reader.ReadString();
                                break;
                            case "img_TT5":
                                saveDataFile.Img_TT[4] = reader.ReadString();
                                break;

                            //sub

                            case "sub_TT1":
                                saveDataFile.Sub_TT[0] = reader.ReadString();
                                break;
                            case "sub_TT2":
                                saveDataFile.Sub_TT[1] = reader.ReadString();
                                break;
                            case "sub_TT3":
                                saveDataFile.Sub_TT[2] = reader.ReadString();
                                break;
                            case "sub_TT4":
                                saveDataFile.Sub_TT[3] = reader.ReadString();
                                break;
                            case "sub_TT5":
                                saveDataFile.Sub_TT[4] = reader.ReadString();
                                break;



                            //PS

                            case "PS1":
                                saveDataFile.PS[0] = reader.ReadString();
                                break;
                            case "PS2":
                                saveDataFile.PS[1] = reader.ReadString();
                                break;
                            case "PS3":
                                saveDataFile.PS[2] = reader.ReadString();
                                break;
                            case "PS4":
                                saveDataFile.PS[3] = reader.ReadString();
                                break;
                            case "PS5":
                                saveDataFile.PS[4] = reader.ReadString();
                                break;


                            //img

                            case "img_PS1":
                                saveDataFile.Img_PS[0] = reader.ReadString();
                                break;
                            case "img_PS2":
                                saveDataFile.Img_PS[1] = reader.ReadString();
                                break;
                            case "img_PS3":
                                saveDataFile.Img_PS[2] = reader.ReadString();
                                break;
                            case "img_PS4":
                                saveDataFile.Img_PS[3] = reader.ReadString();
                                break;
                            case "img_PS5":
                                saveDataFile.Img_PS[4] = reader.ReadString();
                                break;

                            //sub

                            case "sub_PS0":
                                saveDataFile.Sub_PS[0] = reader.ReadString();
                                break;
                            case "sub_PS1":
                                saveDataFile.Sub_PS[1] = reader.ReadString();
                                break;
                            case "sub_PS2":
                                saveDataFile.Sub_PS[2] = reader.ReadString();
                                break;
                            case "sub_PS3":
                                saveDataFile.Sub_PS[3] = reader.ReadString();
                                break;
                            case "sub_PS4":
                                saveDataFile.Sub_PS[4] = reader.ReadString();
                                break;


                            //FO

                            case "FO1":
                                saveDataFile.FO[0] = reader.ReadString();
                                break;
                            case "FO2":
                                saveDataFile.FO[1] = reader.ReadString();
                                break;
                            case "FO3":
                                saveDataFile.FO[2] = reader.ReadString();
                                break;
                            case "FO4":
                                saveDataFile.FO[3] = reader.ReadString();
                                break;
                            case "FO5":
                                saveDataFile.FO[4] = reader.ReadString();
                                break;

                            //img

                            case "img_FO1":
                                saveDataFile.Img_FO[0] = reader.ReadString();
                                break;
                            case "img_FO2":
                                saveDataFile.Img_FO[1] = reader.ReadString();
                                break;
                            case "img_FO3":
                                saveDataFile.Img_FO[2] = reader.ReadString();
                                break;
                            case "img_FO4":
                                saveDataFile.Img_FO[3] = reader.ReadString();
                                break;
                            case "img_FO5":
                                saveDataFile.Img_FO[4] = reader.ReadString();
                                break;

                            //sub

                            case "sub_FO1":
                                saveDataFile.Sub_FO[0] = reader.ReadString();
                                break;
                            case "sub_FO2":
                                saveDataFile.Sub_FO[1] = reader.ReadString();
                                break;
                            case "sub_FO3":
                                saveDataFile.Sub_FO[2] = reader.ReadString();
                                break;
                            case "sub_FO4":
                                saveDataFile.Sub_FO[3] = reader.ReadString();
                                break;
                            case "sub_FO5":
                                saveDataFile.Sub_FO[4] = reader.ReadString();
                                break;



                            //BI

                            case "BI1":
                                saveDataFile.BI[0] = reader.ReadString();
                                break;
                            case "BI2":
                                saveDataFile.BI[1] = reader.ReadString();
                                break;
                            case "BI3":
                                saveDataFile.BI[2] = reader.ReadString();
                                break;
                            case "BI4":
                                saveDataFile.BI[3] = reader.ReadString();
                                break;
                            case "BI5":
                                saveDataFile.BI[4] = reader.ReadString();
                                break;

                            //img

                            case "img_BI1":
                                saveDataFile.Img_BI[0] = reader.ReadString();
                                break;
                            case "img_BI2":
                                saveDataFile.Img_BI[1] = reader.ReadString();
                                break;
                            case "img_BI3":
                                saveDataFile.Img_BI[2] = reader.ReadString();
                                break;
                            case "img_BI4":
                                saveDataFile.Img_BI[3] = reader.ReadString();
                                break;
                            case "img_BI5":
                                saveDataFile.Img_BI[4] = reader.ReadString();
                                break;

                            //sub

                            case "sub_BI1":
                                saveDataFile.Sub_BI[0] = reader.ReadString();
                                break;
                            case "sub_BI2":
                                saveDataFile.Sub_BI[1] = reader.ReadString();
                                break;
                            case "sub_BI3":
                                saveDataFile.Sub_BI[2] = reader.ReadString();
                                break;
                            case "sub_BI4":
                                saveDataFile.Sub_BI[3] = reader.ReadString();
                                break;
                            case "sub_BI5":
                                saveDataFile.Sub_BI[4] = reader.ReadString();
                                break;

                        }

                    }
                }
            }
           
        }
        //StartCoroutine(LoadTourImages());
    }
    public IEnumerator LoadTourImages()
    {
        //Guided_Tour.instance.nTourImages = 0;
        for (int i = 0; i <= 4; i++)
        {
            if (saveDataFile.Img_EC[i] != "")
            {
                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(saveDataFile.Img_EC[i]))
                {
                    yield return request.SendWebRequest();

                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        Texture2D texture = DownloadHandlerTexture.GetContent(request);

                        // Create a sprite from the texture and assign it to the Image component
                        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                       // Guided_Tour.instance.TourImages[Guided_Tour.instance.nTourImages].sprite = sprite;
                    }
                    else
                    {
                        Debug.LogError("Image download failed: " + request.error);
                    }
                }

                //saveDataFile.Img_EC[i] = Guided_Tour.instance.nTourImages.ToString();
               // Guided_Tour.instance.nTourImages++;
            }

            //intro
            if (saveDataFile.Img_INTRO[i] != "")
            {

                using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(saveDataFile.Img_INTRO[i]))
                {
                    yield return request.SendWebRequest();

                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        Texture2D texture = DownloadHandlerTexture.GetContent(request);
                        // Create a sprite from the texture and assign it to the Image component
                        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                       // Guided_Tour.instance.TourImages[Guided_Tour.instance.nTourImages].sprite = sprite;
                    }
                    else
                    {
                        Debug.LogError("Image download failed: " + request.error);
                    }
                }
              //  saveDataFile.Img_INTRO[i] = Guided_Tour.instance.nTourImages.ToString();
               // Guided_Tour.instance.nTourImages++;
            }

        }
    }
    public IEnumerator GetAllTexts()
    {
        url = Guided_Tour.instance.Assets_Folder + "cards/" + ImageToggleOnHover.UseCase + ".xml";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string fileContent = www.downloadHandler.text;
            ProcessFileContent(fileContent);
        }
    }
    //public void GetAllTexts()
                
    //{
    //    using (XmlReader reader = XmlReader.Create(Guided_Tour.instance.Assets_Folder + "cards/" + ImageToggleOnHover.UseCase + ".xml"))
    //    {
    //        while (reader.Read())
    //        {
    //            if (reader.IsStartElement())
    //            {
    //                //return only when you have START tag  
    //                switch (reader.Name.ToString())
    //                {
    //                    case "IntroEndIndx":
    //                        //Indx = saveDataFile.IntroEndIndx;
    //                        saveDataFile.IntroEndIndx = int.Parse(reader.ReadString());

    //                        break;

    //                    case "ECEndIndx":
    //                        saveDataFile.ECEndIndx = int.Parse(reader.ReadString());
    //                        break;


    //                    case "HARDWAREEndIndx":
    //                        saveDataFile.HARDWAREEndIndx = int.Parse(reader.ReadString());
    //                        break;

    //                    case "TTEndIndx":
    //                        saveDataFile.TTEndIndx = int.Parse(reader.ReadString());
    //                        break;




    //                    case "PSEndIndx":

    //                        saveDataFile.PSEndIndx = int.Parse(reader.ReadString());

    //                        break;

    //                    case "FOEndIndx":
    //                        saveDataFile.FOEndIndx = int.Parse(reader.ReadString());
    //                        break;


    //                    case "BIEndIndx":
    //                        saveDataFile.BIEndIndx = int.Parse(reader.ReadString());
    //                        break;


    //                    case "CTA1":
    //                        saveDataFile.CTA1 = reader.ReadString();
    //                        break;
    //                    case "CTA2":
    //                        saveDataFile.CTA2 = reader.ReadString();
    //                        break;
    //                    case "CTA3":
    //                        saveDataFile.CTA3 = reader.ReadString();
    //                        break;
    //                    case "CTA4":
    //                        saveDataFile.CTA4 = reader.ReadString();
    //                        break;


    //                    case "EC1":
    //                        saveDataFile.EC[0] = reader.ReadString();
    //                        break;
    //                    case "EC2":
    //                        saveDataFile.EC[1] = reader.ReadString();
    //                        break;
    //                    case "EC3":
    //                        saveDataFile.EC[2] = reader.ReadString();
    //                        break;
    //                    case "EC4":
    //                        saveDataFile.EC[3] = reader.ReadString();
    //                        break;
    //                    case "EC5":
    //                        saveDataFile.EC[4] = reader.ReadString();
    //                        break;

    //                    //INTRO

    //                    case "Intro0":
    //                        saveDataFile.INTRO[0] = reader.ReadString();
    //                        break;
    //                    case "Intro1":
    //                        saveDataFile.INTRO[1] = reader.ReadString();
    //                        break;
    //                    case "Intro2":
    //                        saveDataFile.INTRO[2] = reader.ReadString();
    //                        break;
    //                    case "Intro3":
    //                        saveDataFile.INTRO[3] = reader.ReadString();
    //                        break;
    //                    case "Intro4":
    //                        saveDataFile.INTRO[4] = reader.ReadString();
    //                        break;

    //                    //Hardware

    //                    case "HARDWARE1":
    //                        saveDataFile.HARDWARE[0] = reader.ReadString();
    //                        break;
    //                    case "HARDWARE2":
    //                        saveDataFile.HARDWARE[1] = reader.ReadString();
    //                        break;
    //                    case "HARDWARE3":
    //                        saveDataFile.HARDWARE[2] = reader.ReadString();
    //                        break;
    //                    case "HARDWARE4":
    //                        saveDataFile.HARDWARE[3] = reader.ReadString();
    //                        break;
    //                    case "HARDWARE5":
    //                        saveDataFile.HARDWARE[4] = reader.ReadString();
    //                        break;

    //                    //tt

    //                    case "TT1":
    //                        saveDataFile.TT[0] = reader.ReadString();
    //                        break;
    //                    case "TT2":
    //                        saveDataFile.TT[1] = reader.ReadString();
    //                        break;
    //                    case "TT3":
    //                        saveDataFile.TT[2] = reader.ReadString();
    //                        break;
    //                    case "TT4":
    //                        saveDataFile.TT[3] = reader.ReadString();
    //                        break;
    //                    case "TT5":
    //                        saveDataFile.TT[4] = reader.ReadString();
    //                        break;


    //                    //PS

    //                    case "PS1":
    //                        saveDataFile.PS[0] = reader.ReadString();
    //                        break;
    //                    case "PS2":
    //                        saveDataFile.PS[1] = reader.ReadString();
    //                        break;
    //                    case "PS3":
    //                        saveDataFile.PS[2] = reader.ReadString();
    //                        break;
    //                    case "PS4":
    //                        saveDataFile.PS[3] = reader.ReadString();
    //                        break;
    //                    case "PS5":
    //                        saveDataFile.PS[4] = reader.ReadString();
    //                        break;


    //                    //FO

    //                    case "FO1":
    //                        saveDataFile.FO[0] = reader.ReadString();
    //                        break;
    //                    case "FO2":
    //                        saveDataFile.FO[1] = reader.ReadString();
    //                        break;
    //                    case "FO3":
    //                        saveDataFile.FO[2] = reader.ReadString();
    //                        break;
    //                    case "FO4":
    //                        saveDataFile.FO[3] = reader.ReadString();
    //                        break;
    //                    case "FO5":
    //                        saveDataFile.FO[4] = reader.ReadString();
    //                        break;


    //                    //BI

    //                    case "BI1":
    //                        saveDataFile.BI[0] = reader.ReadString();
    //                        break;
    //                    case "BI2":
    //                        saveDataFile.BI[1] = reader.ReadString();
    //                        break;
    //                    case "BI3":
    //                        saveDataFile.BI[2] = reader.ReadString();
    //                        break;
    //                    case "BI4":
    //                        saveDataFile.BI[3] = reader.ReadString();
    //                        break;
    //                    case "BI5":
    //                        saveDataFile.BI[4] = reader.ReadString();
    //                        break;
    //                }
               
    //            }
    //        }
    //    }
    
    //}

    //For Getting String Values
   

    //For Getting String Values
    //public IEnumerator Tour_Text(string ComponentName)
    //{

    //    UnityWebRequest www = UnityWebRequest.Get(Guided_Tour.instance.Assets_Folder + "cards/" + ImageToggleOnHover.UseCase + ".xml");
    //    yield return www.SendWebRequest();

    //    if (www.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        string xmlText = www.downloadHandler.text;
    //        XmlDocument xmlDoc = new XmlDocument();
    //        xmlDoc.LoadXml(xmlText);
    //        XmlNode node = xmlDoc.SelectSingleNode("fp/" + ComponentName);
    //        XmlElement root = xmlDoc.DocumentElement;

    //        if (node != null)
    //        {
    //            nodeText = node.InnerText;

    //        }

           
    //        //This will remove integer from string
    //        var output = Regex.Replace(ComponentName, @"[\d-]", string.Empty);

    //        if (string.IsNullOrEmpty(output))
    //        {
    //            output = ComponentName;
    //        }
    //        SaveDataAccToKey(output,ComponentName);

    //    }
    //}

    //private void SaveDataAccToKey(string output, string componentName)
    //{
    //    switch (componentName)
    //    {

           
    //        case "IntroEndIndx":
    //            //Indx = saveDataFile.IntroEndIndx;
    //            saveDataFile.IntroEndIndx = int.Parse(nodeText);

    //            break;

    //        case "ECEndIndx":
    //            saveDataFile.ECEndIndx = int.Parse(nodeText);
    //            break;


    //        case "HARDWAREEndIndx":
    //            saveDataFile.HARDWAREEndIndx = int.Parse(nodeText);
    //            break;

    //        case "TTEndIndx":
    //            saveDataFile.TTEndIndx = int.Parse(nodeText);
    //            break;

          
          

    //        case "PSEndIndx":

    //            saveDataFile.PSEndIndx = int.Parse(nodeText);

    //            break;

    //        case "FOEndIndx":
    //            saveDataFile.FOEndIndx = int.Parse(nodeText);
    //            break;

           
    //        case "BIEndIndx":
    //            saveDataFile.BIEndIndx = int.Parse(nodeText);
    //            break;
  
            
    //        case "CTA1":
    //            saveDataFile.CTA1 = nodeText;
    //            break;
    //        case "CTA2":
    //            saveDataFile.CTA2 = nodeText;
    //            break;
    //        case "CTA3":
    //            saveDataFile.CTA3 = nodeText;
    //            break;
    //        case "CTA4":
    //            saveDataFile.CTA4 = nodeText;
    //            break;
    //    }
    //    switch (output)
    //    {
    //        //case "INTRO":
    //        //    saveDataFile.INTRO = nodeText;
    //        //    break;
    //        case "Intro":

    //            saveDataFile.INTRO.Add(nodeText);

    //            //  Indx++;
    //            break;

         


    //        case "EC":
    //            saveDataFile.EC.Add(nodeText);


    //            // string temp = saveDataFile.EC[0];

    //            //saveDataFile.EC[1] = temp;
    //            //saveDataFile.EC[2] = saveDataFile.EC[1];
    //            //Indx++;
    //            break;

    //        //case "V":
    //        //    saveDataFile.V = nodeText;
    //        //    break;

    //        case "HARDWARE":
    //            saveDataFile.HARDWARE.Add(nodeText);

    //            //nodeText
    //            break;

    //        case "TT":
    //            saveDataFile.TT.Add(nodeText);

    //            //Indx++;
    //            break;

    //        case "PS":

    //            saveDataFile.PS.Add(nodeText);

    //            //  Indx++;
    //            break;
           

    //        case "FO":
    //            saveDataFile.FO.Add(nodeText);

    //            break;

    //        case "BI":
    //            saveDataFile.BI.Add(nodeText);
    //            break;

    //        //case "CTA":
    //        //    saveDataFile.CTA.Add(nodeText);
    //        //    break;
    //        case "CTA1":
    //            saveDataFile.CTA1 = nodeText;
    //            break;
    //        case "CTA2":
    //            saveDataFile.CTA2 = nodeText;
    //            break;
    //        case "CTA3":
    //            saveDataFile.CTA3 = nodeText;
    //            break;
    //        case "CTA4":
    //            saveDataFile.CTA4 = nodeText;
    //            break;


    //    }
    //}

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
    public string[] PartnerGraphics;
    public int[] PartnerGraphicsIndex;
    //public string[] Dell;
    public int PartnerTCount;
    public IEnumerator LoadPartnerImages()
    {
       
            UnityWebRequest www = UnityWebRequest.Get(Guided_Tour.instance.Assets_Folder+"cards/partners.xml");
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
            int ListIndex = 0;
            int j = 0;
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
                j = 1;
                bool bContinue=true;

                while (bContinue&&ListIndex<50)
                {
                    XmlNode nodegraphics = xmlDoc.SelectSingleNode("partners/Graphics" + (i + 1)+j.ToString("00"));
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
