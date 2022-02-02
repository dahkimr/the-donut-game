using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameInfo {
    private static float[] speeds = new float[] {5.0f, 6.0f, 7.0f, 8.0f, 8.0f, 9.0f};
    private static int sceneNum = 0;
    private static float currentSpeed = speeds[0];
    private static float[] scores = new float[6];

    public static void setNextScene(float score) {
        scores[sceneNum] = score;
        sceneNum++;

        if (sceneNum < speeds.Length) {
            currentSpeed = speeds[sceneNum];
            SceneManager.LoadScene("SpeedUp");
        }
        else {
            showFinalScene();
        }
    }

    public static float getSpeed() {
        return currentSpeed;
    }

    private static void showFinalScene() {
        // add up the scores
        // show different text depending
        SceneManager.LoadScene("FinalScene");
    }
}
