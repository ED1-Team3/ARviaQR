using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using TMPro;

public class QRCodeGenerator : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageReceiver;     //receives and displays QR code
    [SerializeField]
    private TMP_InputField _textInputField; //receives text in input field

    private Texture2D _storeEncodedTexture; //receives generated QR code

    /***********************FUNCITON HEADER ******************************************************************************************************************
    Name:  Start
    Pre-Conditon: None.
    Post-Condition: Variable to store QR code is initialized to 256x256.
    Description:  Start is called before the first frame update and initializes the target variable. 
    **********************************************************************************************************************************************************/
    void Start()
    {
        _storeEncodedTexture = new Texture2D(256, 256);
    }

    /***********************FUNCITON HEADER ******************************************************************************************************************
    Name: Color32
    Pre-Conditon: None
    Post-Condition: QR code is generated from input text. 
    Description:  Transforms input field text into a QR code.
    **********************************************************************************************************************************************************/
    private Color32 [] Encode(string textforEncoding, int width, int height) 
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
        return writer.Write(textforEncoding);
    }

    /***********************FUNCITON HEADER ******************************************************************************************************************
    Name: OnClickEncode
    Pre-Conditon: EncodeTextToQRCode function is defined.
    Post-Condition: EncodeTextToQRCode function is run.
    Description: Converts text to QR code once button is clicked. 
    **********************************************************************************************************************************************************/
    public void OnClickEncode()
    {
        EncodeTextToQRCode();
    }

    /***********************FUNCITON HEADER ******************************************************************************************************************
    Name: EncodeTextToQRCode
    Pre-Conditon: Variables to receive generated QR code, input text, and display QR code to image receiver are initialized. 
    Post-Condition: Generated QR code is displayed as an image
    Description: Main function body
    **********************************************************************************************************************************************************/
    private void EncodeTextToQRCode()
    {
        string textWrite = string.IsNullOrEmpty(_textInputField.text) ?
            "Please add text" : _textInputField.text;
        Color32[] _convertPixelTotexture = Encode(textWrite, _storeEncodedTexture.width,
            _storeEncodedTexture.height);
        _storeEncodedTexture.SetPixels32(_convertPixelTotexture);
        _storeEncodedTexture.Apply();
        _rawImageReceiver.texture = _storeEncodedTexture;
    }
}
