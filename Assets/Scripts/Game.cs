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
    // add reference to text and change content depending on rating
    public void CalcRank(float distance) {
        // run text animation
        string text = "";
        if (distance > 1) {
            text = "really?";
        }
        else if (distance > 0.5) {
            text = "nice.";
        }
        else {
            text = "amazing!";
        }
        Debug.Log(text);
        ratingText.GetComponent<TextMeshProUGUI>().text = text;
        animCtlr.SetBool("showRating", true);
        // if (distance > 1.55) {
        //     GameOver();
        // }
        // else {
        //     NextScene(distance);
        // }
    }
    private void GameOver() {
        SceneManager.LoadSceneAsync("GameOver");
    }

    private void NextScene(float distance) {
        GameInfo.setNextScene(distance);
    }
}
