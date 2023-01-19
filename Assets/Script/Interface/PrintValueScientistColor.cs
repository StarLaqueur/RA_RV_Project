using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PrintValueScientistColor : MonoBehaviour
{
    public TextMeshProUGUI TextValue;
    void Start()
    {
        TextValue = GetComponent<TextMeshProUGUI>();
    }

    public void textUpdate(float value)
    {
        string slider_value;
        if (value==1)
        {
            slider_value = "Vert";
            TextValue.color = Color.green;
        }
        else if (value==2)
        {
            slider_value = "Bleu";
            TextValue.color = Color.blue;
        }
        else if (value == 3)
        {
            slider_value = "Blanc";
            TextValue.color = Color.white;
        }
        else
        {
            slider_value = "Vert";
            TextValue.color = Color.green;
        }
        TextValue.text = slider_value;
    }
}
