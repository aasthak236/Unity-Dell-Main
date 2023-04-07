using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;

public class Load_Card_Text : MonoBehaviour
{
    public TextAsset xmlFile; // Reference to the XML file
    public TextMeshProUGUI textComponent; // Reference to the Text component in Unity

    // Start is called before the first frame update
    void Start()
    {
        // Create a new XmlDocument object
        XmlDocument xmlDoc = new XmlDocument();

        // Load the XML data from the TextAsset object
        xmlDoc.LoadXml(xmlFile.text);
        XmlNode node = xmlDoc.SelectSingleNode("UM/Cards/Outcome1");
        // Get the root element of the XML document
        XmlElement root = xmlDoc.DocumentElement;

        // Get the inner text of the root element
       // string xmlText = root.InnerText;
        string nodeText = node.InnerText;
        // Set the text of the Text component to the XML text
        textComponent.text = nodeText;
    }
}
