using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Animator animCtlr;
    [SerializeField] private GameObject ratingText;
    public void CalcRank(float distance) {
        Debug.Log("started");
        if (distance > 3.0) {
            GameOver();
        }
        else {
            string text = "";
            if (distance > 0.8) {
                text = "really?";
            }
            else if (distance > 0.1) {
                text = "nice.";
            }
            else {
                text = "amazing!";
            }
            ratingText.GetComponent<TextMeshProUGUI>().text = text;
            Debug.Log("animation started");
            animCtlr.SetBool("showRating", true);

            StartCoroutine(NextScene(distance));
        }
    }

    private void GameOver() {
        SceneManager.LoadSceneAsync("GameOver");
    }

    IEnumerator NextScene(float distance) {
        yield return new WaitForSeconds(1f);
        GameInfo.setNextScene(distance);
    }
}
