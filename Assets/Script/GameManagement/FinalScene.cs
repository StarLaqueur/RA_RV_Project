using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] TextMeshProUGUI textWinner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameEnd());
        textWinner.text = "WINNER " + PlayerPrefs.GetString("winner");
    }

    // Method call when ending the game to show the countdown and exit the application
    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez etre redirige dans 5 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez etre redirige dans 4 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez etre redirige dans 3 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez etre redirige dans 2 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez etre redirige dans 1 secondes...";
        Application.Quit();
    }
}
