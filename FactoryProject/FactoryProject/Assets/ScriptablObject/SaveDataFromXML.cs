
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//[CreateAssetMenu(menuName = "TextDataSave")]

public class SaveDataFromXML : MonoBehaviour
{
    
    //public string INTRO;
    public List<string> INTRO ;
    public List<string> Img_INTRO;
    public List<string> Sub_INTRO;
    public int IntroEndIndx;

   // public string IntroCaption;

    public List<string> EC;
    public List<string> Img_EC;
    public List<string> Sub_EC;
    public int ECStartIndx;
    public int ECEndIndx;

   
    public List<string> HARDWARE;
    public List<string> Img_HARDWARE;
    public List<string> Sub_HARDWARE;
    public int HARDWAREStartIndx;
    public int HARDWAREEndIndx;

    public List<string> TT;
    public List<string> Img_TT;
    public List<string> Sub_TT;
    public int TTStartIndx;
    public int TTEndIndx;

    public List<string> PS;
    public List<string> Img_PS;
    public List<string> Sub_PS;
    public int PSStartIndx;
    public int PSEndIndx;

    

    public List<string> FO;
    public List<string> Img_FO;
    public List<string> Sub_FO;
    public int FOStartIndx;
    public int FOEndIndx;

    public List<string> BI;
    public List<string> Img_BI;
    public List<string> Sub_BI;
    public int BIStartIndx;
    public int BIEndIndx;

    public List<string> CTA;
    public List<string> Img_CTA;
    public List<string> Sub_CTA;
    public int CtaStartIndx;
    public int CtaEndIndx;
    public string CTA1;
    public string CTA2;
    public string CTA3;
    public string CTA4;
    
    public static SaveDataFromXML ins;

    public void Start()
    {
        ins = this;
      
    }
    public void ResetSaveData()
    {
        INTRO.Clear();
        Img_INTRO.Clear();
        Sub_INTRO.Clear();
        PS.Clear();
        Img_PS.Clear();
        Sub_PS.Clear();
        EC.Clear();
        Img_EC.Clear();
        Sub_EC.Clear();
        TT.Clear();
        Img_TT.Clear();
        Sub_TT.Clear();
        BI.Clear();
        Img_BI.Clear();
        Sub_BI.Clear();
        HARDWARE.Clear();
        Img_HARDWARE.Clear();
        Sub_HARDWARE.Clear();
        FO.Clear();
        for (int i = 0; i <= 4; i++)
        {
            INTRO.Add("");
            Sub_INTRO.Add("");
            Img_INTRO.Add("");
            PS.Add("");
            Sub_PS.Add("");
            Img_PS.Add("");
            EC.Add("");
            Sub_EC.Add("");
            Img_EC.Add("");
            TT.Add("");
            Sub_TT.Add("");
            Img_TT.Add("");
            BI.Add("");
            Sub_BI.Add("");
            Img_BI.Add("");
            HARDWARE.Add("");
            Sub_HARDWARE.Add("");
            Img_HARDWARE.Add("");
            FO.Add("");
            Img_FO.Add("");
            Sub_FO.Add("");
           // Guided_Tour.instance.TourImages[i] = null;
        }
        //INTRO.Clear();
       
        IntroEndIndx = 0;
      //  IntroCaption = "";
        ///PS.Clear();
        PSStartIndx = 1;
        PSEndIndx = 0;

       // EC.Clear();
        ECStartIndx = 1;
        ECEndIndx = 0;

        
        //TT.Clear();
        TTStartIndx = 1;
        TTEndIndx = 0;
       

        //HARDWARE.Clear();
        HARDWAREEndIndx = 0;
        HARDWAREStartIndx = 1;

        //FO.Clear();
        FOStartIndx = 1;
        FOEndIndx = 0;

        BIStartIndx = 1;
        BIEndIndx = 0;
       // BI.Clear();
        CtaStartIndx = 1;
        CtaEndIndx = 0;
    }
}
