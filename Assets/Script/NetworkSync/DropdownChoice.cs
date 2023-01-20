using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownChoice : MonoBehaviour
{
    const string gameOption = "gameSetup";
    private TMP_Dropdown _dropdown;

    // Set the drop-down menu at game startup based on its last choice
    // And update of the global variable to find its choice
    void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();

        _dropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(i =>
        {
            PlayerPrefs.SetInt(gameOption, _dropdown.value);
            PlayerPrefs.Save();
        }));
    }

    // Updated drop-down menu
    void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(gameOption, 0);
    }
}