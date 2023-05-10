using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;

public class QRCodeGenerator : MonoBehaviour
{
    public RawImage _rawImageBackgroundDell;
    private Texture2D StoreQrcode;
    public static QRCodeGenerator instance;
    void Start()
    {
        instance = this;
        StoreQrcode = new Texture2D(256,256);
  
    }
    private  Color32[] Encode(string textForEncoding, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);

    }
  

    public void TexttoqrcodeDell()
    {
        string textwriter = string.IsNullOrEmpty(Load_Tour_text.ins.DS_Link[int.Parse(GUI_Control.instance.buttonName)]) ? "you should write" : Load_Tour_text.ins.DS_Link[int.Parse(GUI_Control.instance.buttonName)];
        Color32[] converttexturetopixle = Encode(textwriter, StoreQrcode.width, StoreQrcode.height);
        StoreQrcode.SetPixels32(converttexturetopixle);
        StoreQrcode.Apply();
        _rawImageBackgroundDell.texture = StoreQrcode;
    }
}