using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameRespawn());
    }

    IEnumerator GameRespawn()
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
        SceneManager.LoadScene("GameScene");
    }
}
