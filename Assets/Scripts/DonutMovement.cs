using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private readonly int MIN_SPEED = 2;
    private readonly int MAX_SPEED = 4;
    private readonly float MIN_CHANGE_TIME = 1.0f;
    private readonly float MAX_CHANGE_TIME = 2.0f;
    private readonly float BORDER = 0.5f;
    
    private Vector2 bounds;

    IDictionary<string, bool> outOfBounds;
    private Vector2 movementPerSecond;
    private float lastDirectionChangeTime;
    private float changeTime;

    // Start is called before the first frame update
    void Start()
    {
        outOfBounds = new Dictionary<string, bool>(){
            {"left", false},
            {"right", false},
            {"top", false},
            {"bottom", false}
        };
        lastDirectionChangeTime = 0f;

        calcBounds();
        calcChangeTime();
        changeVelocity();
    }

    void FixedUpdate(){
        // calculate a new movement vector if time is up
        if (isOutOfBounds() || Time.time - lastDirectionChangeTime > changeTime) {
            lastDirectionChangeTime = Time.time;
            calcChangeTime();
            changeVelocity();
        }
    }

    void changeVelocity() {
        // we're going to calculate the movement vector first
        float xNeg = -1.0f;
        float xPos = 1.0f;
        float yNeg = -1.0f;
        float yPos = 1.0f;

        // if bounds are out, set float val to 0
        // so you don't go in that direction
        if (outOfBounds["left"]) {
            xNeg = 0.001f;
        }
        else if (outOfBounds["right"]) {
            xPos = -0.001f;
        }
        if (outOfBounds["bottom"]) {
            yNeg = 0.001f;
        }
        else if (outOfBounds["top"]) {
            yPos = -0.001f;
        }

        Vector2 direction = new Vector2(Random.Range(xNeg, xPos), Random.Range(yNeg, yPos)).normalized;
        float speed = Random.Range(MIN_SPEED, MAX_SPEED);
        Vector2 movementPerSecond = direction * speed;

        // then set the velocity
        rb.velocity = movementPerSecond;
    }

    void calcChangeTime() {
        changeTime = Random.Range(MIN_CHANGE_TIME, MAX_CHANGE_TIME);
    }

    bool isOutOfBounds() {
        Vector2 position = this.transform.position;
        bool isOut = false;

        outOfBounds["left"] = false;
        outOfBounds["right"] = false;
        outOfBounds["top"] = false;
        outOfBounds["bottom"] = false;

        if (position.x < -bounds.x) {
            outOfBounds["left"] = true;
            isOut = true;
        }
        else if (position.x > bounds.x) {
            outOfBounds["right"] = true;
            isOut = true;
        }
        
        if (position.y < -bounds.y) {
            outOfBounds["bottom"] = true;
            isOut = true;
        }
        else if (position.y > bounds.y) {
            outOfBounds["top"] = true;
            isOut = true;
        }
        return isOut;
    }

    void calcBounds() {
        SpriteRenderer donutSprite = this.gameObject.GetComponent<SpriteRenderer>();
        Vector2 donutDimensions = new Vector2(
            donutSprite.bounds.size.x / 2,
            donutSprite.bounds.size.y / 2
        );
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        bounds = new Vector2(
            screenBounds.x - donutDimensions.x - BORDER,
            screenBounds.y - donutDimensions.y - BORDER
        );
    }
}