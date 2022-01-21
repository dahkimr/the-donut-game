using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Animator animCtlr;
    // add reference to text and change content depending on rating
    public void CalcRank(float distance) {
        // run text animation
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
