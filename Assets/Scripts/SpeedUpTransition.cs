using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpeedUpTransition : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene() {
        yield return new WaitForSeconds(0.4f);
        canvas.gameObject.SetActive(true);
        SfxManager.sfxManagerInstance.PlaySpeedUp();

        yield return new WaitForSeconds(1.2f);
        canvas.gameObject.SetActive(false);
        SfxManager.sfxManagerInstance.StopSpeedUp();
        
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Level01");
    }
}
