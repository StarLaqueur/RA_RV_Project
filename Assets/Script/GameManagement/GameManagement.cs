using Newtonsoft.Json;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    private string fileName = "exportDataMap";

    public GameObject Parent;
    //public GameObject PinContamination;
    //public GameObject PinThrowable;
    public GameObject PinSpawn;
    public GameObject Panel;
    public NetworkPlayerSpawn npt;

    public AudioSource respawnSound;
    public AudioSource deathSound;

    public TextMeshProUGUI textMesh;

    public GameObject LoadStoredPin;
    private List<PinSpawn> ListPinSpawn;

    public static GameManagement instance;
    public static int VRTeam = 0;
    public static int TPPTeam = 0;
    public TextMeshProUGUI VRTeamText;
    public TextMeshProUGUI TPPTeamText;

    private void Awake()
    {
        SetScoreText();
        instance = this;
    }

    void SetScoreText()
    {
        VRTeamText.text = VRTeam.ToString();
        TPPTeamText.text = TPPTeam.ToString();
    }

    void Update()
    {
        SetScoreText();

        if(VRTeam >= 2)
        {
            EndGame("VRTEAM");
        }

        if(TPPTeam >= 10)
        {
            EndGame("KMSTEAM");
        }
    }

    public void SetPinPoint()
    {
        string locationJson = File.ReadAllText(Application.streamingAssetsPath + "/" + fileName + ".json");
        List<Pin> pins = JsonConvert.DeserializeObject<List<Pin>>(locationJson);
        ListPinSpawn = new List<PinSpawn>();

        foreach (Pin pin in pins)
        {
            switch (pin.PinType)
            {
                //case "PinContamination":
                //    LoadStoredPin = Instantiate(PinContamination, Parent.transform);
                //    break;
                //case "PinThrowable":
                //    LoadStoredPin = Instantiate(PinThrowable, Parent.transform);
                //    break;
                case "PinSpawn":
                    LoadStoredPin = Instantiate(PinSpawn, Parent.transform);
                    ListPinSpawn.Add(new PinSpawn { PinPosition = StringToVector(pin.PinPosition.ToString()) });
                    break;
            }
            LoadStoredPin.transform.localPosition = StringToVector(pin.PinPosition.ToString());
        }
    }

    public Vector3 SetSpawnPoint()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(ListPinSpawn.Count);
        Vector3 position = ListPinSpawn[index].PinPosition;
        return position;
    }

    public void EndGame(string winner)
    {
        SceneManager.LoadScene("EndGameScene");
        PlayerPrefs.SetString("winner", winner);
        PlayerPrefs.Save();
    }

    public void Respawn(GameObject player)
    {
        Panel.gameObject.SetActive(true);
        PhotonNetwork.Destroy(player);
        StartCoroutine(GameRespawn());
    }

    IEnumerator GameRespawn()
    {
        deathSound.Play();
        textMesh.text = "Vous allez reapparaitre dans 5 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez reapparaitre dans 4 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez reapparaitre dans 3 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez reapparaitre dans 2 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez reapparaitre dans 1 secondes...";
        yield return new WaitForSeconds(1);
        Panel.gameObject.SetActive(false);
        npt.CreateController();
    }

    private Vector3 StringToVector(string sVector)
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

public class Pin
{
    public string PinType;
    public string PinPosition;
}

public class PinSpawn
{
    public Vector3 PinPosition;
}
