using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameInfo {
    private static float[] speeds = new float[] {8.0f, 12.0f, 18.0f, 21.0f, 23.0f, 26.0f};
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
            showTastingScene();
        }
    }

    public static float getSpeed() {
        return currentSpeed;
    }

    public static float getTotalScore() {
        Debug.Log(scores.Sum());
        return scores.Sum();
    }

    public static void restartGame() {
        sceneNum = 0;
        currentSpeed = speeds[0];
        scores = new float[6];

        SceneManager.LoadScene("Level01");
    }

    private static void showTastingScene() {
        SceneManager.LoadScene("Tasting");
    }
}
