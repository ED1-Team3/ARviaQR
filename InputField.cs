using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public string getText;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreText()
    {
        getText = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text =  getText;
    }
}

//This is a test 