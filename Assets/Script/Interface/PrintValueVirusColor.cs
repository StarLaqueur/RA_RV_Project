using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class PrintValueVirusColor : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI TextValue;
    void Start()
    {
        TextValue = GetComponent<TextMeshProUGUI>();
    }
    
    //Colors the font of the text depending of the selected color and prints a text with the color name instead of the value. The default is red.
    public void textUpdate(float value)
    {
        string slider_value;
        if (value == 1)
        {
            slider_value = "Rouge";
            TextValue.color = Color.red;
        }
        else if (value == 2)
        {
            slider_value = "Jaune";
            TextValue.color = Color.yellow;
        }
        else if (value == 3)
        {
            slider_value = "Cyan";
            TextValue.color = Color.cyan;
        }
        else
        {
            slider_value = "Rouge";
            TextValue.color = Color.red;
        }
        TextValue.text = slider_value;
    }
}

