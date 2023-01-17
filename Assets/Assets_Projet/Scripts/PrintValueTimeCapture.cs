using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class PrintValueTimeCapture : MonoBehaviour
{
    // Start is called before the first frame update
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
