using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TastingTransition : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition() {
        yield return new WaitForSeconds(0.4f);
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.4f);
        canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("FinalScene");
    }
}
