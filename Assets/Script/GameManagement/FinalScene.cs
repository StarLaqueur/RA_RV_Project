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
        textMesh.text = "Vous allez �tre redirig� dans 5 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez �tre redirig� dans 4 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez �tre redirig� dans 3 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez �tre redirig� dans 2 secondes...";
        yield return new WaitForSeconds(1);
        textMesh.text = "Vous allez �tre redirig� dans 1 secondes...";
        Application.Quit();
    }
}
