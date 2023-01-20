using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownChoice : MonoBehaviour
{
    const string gameOption = "gameSetup";
    private TMP_Dropdown _dropdown;


    void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();

        _dropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(i =>
        {
            PlayerPrefs.SetInt(gameOption, _dropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(gameOption, 0);
    }
}