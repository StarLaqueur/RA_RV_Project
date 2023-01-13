using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class DenySpecialCharacterInInput : MonoBehaviour
{
    public InputField inputField;
    public bool allowSpecialCharacters = false;
    // Start is called before the first frame update
    void Start()
    {
        inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) {
            if (!allowSpecialCharacters)
            {
                if (!char.IsLetterOrDigit(addedChar) && !char.IsWhiteSpace(addedChar) && addedChar != '-' && addedChar != '_')
                {
                    return '\0';
                }
            }
            return addedChar;
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
