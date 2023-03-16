using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private float WAIT_TIME = 3.6f;
    void Start()
    {
        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext() {
        yield return new WaitForSeconds(WAIT_TIME);
        SceneManager.LoadScene("Start");
    }
}
