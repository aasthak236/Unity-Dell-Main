
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//[CreateAssetMenu(menuName = "TextDataSave")]

public class SaveDataFromXML : MonoBehaviour
{
   
    //public string INTRO;
    public List<string> INTRO;
   
    public int IntroEndIndx;
    

    public List<string> EC;
    public int ECStartIndx;
    public int ECEndIndx;

   
    public List<string> HARDWARE;
    public int HARDWAREStartIndx;
    public int HARDWAREEndIndx;

    public List<string> TT;
    public int TTStartIndx;
    public int TTEndIndx;

    public List<string> PS;
    public int PSStartIndx;
    public int PSEndIndx;

    

    public List<string> FO;
    public int FOStartIndx;
    public int FOEndIndx;

    public List<string> BI;
    public int BIStartIndx;
    public int BIEndIndx;

    public List<string> CTA;
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
       
        IntroEndIndx = 0;
        PS.Clear();
        PSStartIndx = 1;
        PSEndIndx = 0;

        EC.Clear();
        ECStartIndx = 1;
        ECEndIndx = 0;

        
        TT.Clear();
        TTStartIndx = 1;
        TTEndIndx = 0;
       

        HARDWARE.Clear();
        HARDWAREEndIndx = 0;
        HARDWAREStartIndx = 1;

        FO.Clear();
        FOStartIndx = 1;
        FOEndIndx = 0;

        BIStartIndx = 1;
        BIEndIndx = 0;
        BI.Clear();
        CtaStartIndx = 1;
        CtaEndIndx = 0;
    }
}
