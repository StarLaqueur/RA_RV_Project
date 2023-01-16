using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameEnd());
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez être redirigé dans 5 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez être redirigé dans 4 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez être redirigé dans 3 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez être redirigé dans 2 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez être redirigé dans 1 secondes...";
        Application.Quit();
    }
}
