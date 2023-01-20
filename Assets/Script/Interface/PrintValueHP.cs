using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

[System.Serializable]
//Prints the value of the slider Player Health above the slider
public class PrintValueHP : MonoBehaviour
{

    public TextMeshProUGUI TextValue;
    void Start()
    {
        TextValue = GetComponent<TextMeshProUGUI>();
    }
    //Updates the value of the text bow above the slider to the value of the slider
    public void textUpdate(float value)
    {
        string slider_value = value.ToString();
        TextValue.text = slider_value;

    }

}
