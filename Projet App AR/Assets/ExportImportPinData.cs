using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Globalization;


public class ExportImportPinData : MonoBehaviour
{
    //lists
    public GameObject[] PinContaminationList;
    public GameObject[] PinThrowableList;
    public GameObject[] PinSpawnList;
    public Pin[] PinList;

    //Global interface
    public Button ExportButton;
    public Button ImportButton;
    public InputField inputField;

    //modals
    public GameObject AlertBackground;
    public GameObject AlertExist;
    public Button ContinueButton;
    public Button StopButton;
    public GameObject AlertText;
    public Button NameContinueButton;
    public Text NameContinueText;

    //creating pins
    public GameObject Parent;
    public GameObject PinContamination;
    public GameObject PinThrowable;
    public GameObject PinSpawn;

    //loading existing pins
    GameObject LoadStoredPin;

    [Serializable]
    public class Pin
    {
        public string PinType;
        public string PinPosition;
    }

    [System.Serializable]
    public class RootObject
    {
        public List<Pin> items;
    }


    // Start is called before the first frame update
    void Start()
    {
        Button ExportBtn = ExportButton.GetComponent<Button>();
        ExportButton.onClick.AddListener(ExportButtonOnClick);
        Button ImportBtn = ImportButton.GetComponent<Button>();
        ImportButton.onClick.AddListener(ImportButtonOnClick);
    }

    //Function testing states of the inputField when the export button is clicked and calling associated functions
    void ExportButtonOnClick()
    {
        if (inputField.text != "") {
            if (File.Exists(Application.dataPath + "/" + inputField.text + ".json")) {
                OpenAlertExist();
            } else {
                SavePinsData();
            }
        } else {
            OpenAlertText("Please enter a name before exporting your datas");
        }
    }

    //Function testing states of the inputField when the import button is clicked and calling associated functions
    void ImportButtonOnClick() {
        if (inputField.text != "")
        {
            if (File.Exists(Application.persistentDataPath + "/" + inputField.text + ".json"))
            {
                //Get JSON file data if it exist
                string FileData = File.ReadAllText(Application.persistentDataPath + "/" + inputField.text + ".json");
                //convert data from string to array of object
                List<Pin> pins = JsonConvert.DeserializeObject<List<Pin>>(FileData);

                //Delete existing pins
                PinContaminationList = GameObject.FindGameObjectsWithTag("PinContamination");
                PinThrowableList = GameObject.FindGameObjectsWithTag("PinThrowable");
                PinSpawnList = GameObject.FindGameObjectsWithTag("PinSpawn");
                foreach (GameObject PinContamination in PinContaminationList)
                {
                    Destroy(PinContamination);
                }
                foreach (GameObject PinThrowable in PinThrowableList)
                {
                    Destroy(PinThrowable);
                }
                foreach (GameObject PinSpawn in PinSpawnList)
                {
                    Destroy(PinSpawn);
                }

                //iterate through every object of the array and create the pins at the correct position
                foreach (Pin pin in pins)
                {
                    // Do something with the pin
                    switch(pin.PinType)
                    {
                        case "PinContamination":
                            LoadStoredPin = Instantiate(PinContamination, Parent.transform);
                            break;
                        case "PinThrowable":
                            LoadStoredPin = Instantiate(PinThrowable, Parent.transform);
                            break;
                        case "PinSpawn":
                            LoadStoredPin = Instantiate(PinSpawn, Parent.transform);
                            break;
                    }
                    LoadStoredPin.transform.localPosition = StringToVector(pin.PinPosition.ToString());
                }
                //Message modal
                OpenAlertText("Success");
            }
            else
            {
                //Message modal
                OpenAlertText("This file do not exist");
            }
        }
        else
        {
            //Message modal
            OpenAlertText("Please enter the name of the file to import");
        }
    }

    //function opening a modal to display informations to the user
    void OpenAlertText(string AlertTextValue)
    {
        AlertBackground.SetActive(true);
        AlertText.SetActive(true);
        AlertExist.SetActive(false);

        NameContinueText.GetComponent<UnityEngine.UI.Text>().text = AlertTextValue;
        NameContinueButton.onClick.AddListener(Close);
    }

    //function oppening the modal used when a file with the same name already exist 
    void OpenAlertExist()
    {
        AlertBackground.SetActive(true);
        AlertExist.SetActive(true);
        AlertText.SetActive(false);

        ContinueButton.onClick.AddListener(SavePinsData);
        ContinueButton.onClick.AddListener(Close);

        StopButton.onClick.AddListener(Close);
    }

    //fuction closing all modals
    private void Close()
    {
        ContinueButton.onClick.RemoveAllListeners();
        StopButton.onClick.RemoveAllListeners();
        NameContinueButton.onClick.RemoveAllListeners();
        AlertBackground.SetActive(false);
        AlertExist.SetActive(false);
        AlertText.SetActive(false);
        NameContinueText.GetComponent<UnityEngine.UI.Text>().text = "";
    }

    //function geting position of every pins on the map and saving them as JSON in a file
    private void SavePinsData()
    {
        //get pins positions
        PinContaminationList = GameObject.FindGameObjectsWithTag("PinContamination");
        PinThrowableList = GameObject.FindGameObjectsWithTag("PinThrowable");
        PinSpawnList = GameObject.FindGameObjectsWithTag("PinSpawn");

        if (PinContaminationList.Length == 0 || PinSpawnList.Length == 0)
        {
            OpenAlertText("You need to have at least one spawn point and contamination area");
        }
        else
        {
            //get number of pin created in order to set the lenght of the array
            int lenght = PinContaminationList.Length + PinThrowableList.Length + PinSpawnList.Length;
            PinList = new Pin[lenght];

            int index = 0;
            //transforming every object in array into usable pin object
            foreach (GameObject PinContamination in PinContaminationList)
            {
                PinList[index] = new Pin();
                PinList[index].PinType = "PinContamination";
                PinList[index].PinPosition = PinContamination.transform.localPosition.ToString();
                index += 1;
            }
            foreach (GameObject PinThrowable in PinThrowableList)
            {
                PinList[index] = new Pin();
                PinList[index].PinType = "PinThrowable";
                PinList[index].PinPosition = PinThrowable.transform.localPosition.ToString();
                index += 1;
            }
            foreach (GameObject PinSpawn in PinSpawnList)
            {
                PinList[index] = new Pin();
                PinList[index].PinType = "PinSpawn";
                PinList[index].PinPosition = PinSpawn.transform.localPosition.ToString();
                index += 1;
            }

            //converting array to json and saving the file
            string json = JsonConvert.SerializeObject(PinList);
            string path = Path.Combine(Application.persistentDataPath, inputField.text + ".json");
            File.WriteAllText(path, json);
            OpenAlertText("Success");
        }
    }


    //Function to create vector3 object from a string with the coordonates of the point
    Vector3 StringToVector(string sVector)
    {
        // Remove the parentheses
        sVector = sVector.Replace("(", "");
        sVector = sVector.Replace(")", "");

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0], CultureInfo.InvariantCulture.NumberFormat),
            float.Parse(sArray[1], CultureInfo.InvariantCulture.NumberFormat),
            float.Parse(sArray[2], CultureInfo.InvariantCulture.NumberFormat));

        return result;
    }
}
