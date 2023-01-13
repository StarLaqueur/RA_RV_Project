using UnityEngine;
using UnityEngine.UI;


public class PinManager : MonoBehaviour
{
    //type selection toggle
    public Toggle ContaminationToggle;
    public Toggle ThrowableToggle;
    public Toggle SpawnToggle;

    //Pins prefab and parent
    public GameObject PinContamination;
    public GameObject PinThrowable;
    public GameObject PinSpawn;
    public GameObject Parent;

    //lists
    public GameObject[] PinContaminationList;
    public GameObject[] PinThrowableList;
    public GameObject[] PinSpawnList;

    //modals
    public GameObject AlertBackground;
    public GameObject AlertText;
    public Button NameContinueButton;
    public Text NameContinueText;
    public int MaxPinAmountByType;

    void Start()
    {
        //initiate base state
        ContaminationToggle.GetComponent<Toggle>().isOn = false;
        ThrowableToggle.GetComponent<Toggle>().isOn = false;
        SpawnToggle.GetComponent<Toggle>().isOn = true;
    }

    void Update()
    {
        //on left click on a floor tile of the map create a pin object at the mouse click position depending of the selectionned pin type 
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            
            

            //get number of pin created in order to set the lenght of the array
            int lenght = PinContaminationList.Length;




            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Floor")
                {
                    if (ContaminationToggle.GetComponent<Toggle>().isOn)
                    {
                        PinContaminationList = GameObject.FindGameObjectsWithTag("PinContamination");
                        if (PinContaminationList.Length >= MaxPinAmountByType)
                        {
                            OpenAlertText("Max amount of this pin type reached!!");
                        }
                        else
                        { 
                            Instantiate(PinContamination, hit.point, Quaternion.identity, Parent.transform);
                        }
                    }
                    else if (ThrowableToggle.GetComponent<Toggle>().isOn)
                    {
                        PinThrowableList = GameObject.FindGameObjectsWithTag("PinThrowable");
                        if (PinThrowableList.Length >= MaxPinAmountByType)
                        {
                            OpenAlertText("Max amount of this pin type reached!!");
                        }
                        else
                        {
                            Instantiate(PinThrowable, hit.point, Quaternion.identity, Parent.transform);
                    
                        }
                    }
                    else if (SpawnToggle.GetComponent<Toggle>().isOn)
                    {
                        PinSpawnList = GameObject.FindGameObjectsWithTag("PinSpawn");
                        if (PinSpawnList.Length >= MaxPinAmountByType)
                        {
                            OpenAlertText("Max amount of this pin type reached!!");
                        }
                        else
                        {
                            Instantiate(PinSpawn, hit.point, Quaternion.identity, Parent.transform);
                        }
                    }
                }
            }
        }
    }

    void OpenAlertText(string AlertTextValue)
    {
        AlertBackground.SetActive(true);
        AlertText.SetActive(true);

        NameContinueText.GetComponent<UnityEngine.UI.Text>().text = AlertTextValue;
        NameContinueButton.onClick.AddListener(Close);
    }
    private void Close()
    {
        NameContinueButton.onClick.RemoveAllListeners();
        AlertBackground.SetActive(false);
        AlertText.SetActive(false);
        NameContinueText.GetComponent<UnityEngine.UI.Text>().text = "";
    }
}
