using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackCardData : MonoBehaviour
{
    public TextMeshProUGUI BackCardText;
    public TextMeshProUGUI BackCardLowerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowBackFlipper()
    {
        ImageLoader.instance.BackFlipCard.SetActive(true);
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        string buttonName = clickedButton.name;
       BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
        //  BackCardLowerText.text = Load_Tour_text.ins.DVSCardFace[int.Parse(buttonName)].ToString();
        if (ImageLoader.ComponentName == "VP")
        {
            BackCardText.text = ImageLoader.instance.VPr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "EC")
        {
            BackCardText.text = ImageLoader.instance.ECr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "BO")
        {
            BackCardText.text = ImageLoader.instance.BOr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "DS")
        {

            BackCardText.text = ImageLoader.instance.DSr[int.Parse(buttonName)].ToString();
        }
        else if (ImageLoader.ComponentName == "PS")
        {
            BackCardText.text = ImageLoader.instance.PSr[int.Parse(buttonName)].ToString();
        }

    }
}
