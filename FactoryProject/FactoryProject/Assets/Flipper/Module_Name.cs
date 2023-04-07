using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_Name : MonoBehaviour
{
    public static Module_Name instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  string ModuleName;
    //refrence go to open main BB 
    public void GetModule(string ModuleNames)
    {
        ModuleName = ModuleNames;
    }
}
