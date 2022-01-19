using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameInfo {
    private static float[] speeds = new float[] {5.0f, 5.5f, 6.0f, 7.0f, 7.5f, 8.0f};
    private static int sceneNum = 0;
    private static float currentSpeed = speeds[0];
    private static float[] scores = new float[6];

    public static void setNextScene(float score) {
        scores[sceneNum] = score;
        sceneNum++;
        currentSpeed = speeds[sceneNum];
        SceneManager.LoadScene("Level01");
    }

    public static float getSpeed() {
        return currentSpeed;
    }
}
