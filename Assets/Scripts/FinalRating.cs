using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRating : MonoBehaviour
{
    [SerializeField] private GameObject[] donutImages = new GameObject[4];

    void Start()
    {
        showFinalRating();
    }

    private void showFinalRating() {
        float score = GameInfo.getTotalScore();
        GameObject donut;
        string text = "";
        if (score > 4) {
            text = "Yuck, you call these donuts?";
            donut = donutImages[0];
        }
        else if (score > 3) {
            text = "I guess these are ok.";
            donut = donutImages[1];
        }
        else if (score > 1) {
            text = "These are pretty good.";
            donut = donutImages[2];
        }
        else {
            text = "These are out of the world!";
            donut = donutImages[3];
        }
        
        this.gameObject.GetComponent<TextMeshProUGUI>().text = text;
        Instantiate(donut, new Vector2(0, -1.1f), Quaternion.identity);
    }
}
