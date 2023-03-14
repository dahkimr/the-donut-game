using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    public void OnClick() {
        SceneManager.LoadScene("Level01");
    }

    IEnumerator PlayIntro() {
        yield return new WaitForSeconds(0.5f);
        
    }
}
