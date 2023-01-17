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
        string slider_value = value.ToString();
        TextValue.text = slider_value;
    }
}
