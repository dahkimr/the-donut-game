using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject game;
    private const int NUM_OF_POINTS = 9;
    private Rigidbody2D rb;
    private float SPEED = 3f;
    private Vector2 move;
    private CircleCollider2D playerCol;
    private CircleCollider2D goalCol;
    private Vector3[] points; 
    private float playerRadius;
    private float goalRadius;
    // Start is called before the first frame update
    void Start() {
        Debug.Log(goal.transform.parent.lossyScale);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        playerCol = this.gameObject.GetComponent<CircleCollider2D>();
        goalCol = goal.gameObject.GetComponent<CircleCollider2D>();
        playerRadius = playerCol.radius * this.gameObject.transform.lossyScale.x;
        goalRadius = goalCol.radius * goal.transform.lossyScale.x;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(SPEED * move * Time.deltaTime);
    }

    void FixedUpdate() {
        if (!IsFullyOverlapping()) {
            Debug.Log("not fully overlapping");
            game.GetComponent<Game>().GameOver();
        }
        else {
            Debug.Log("fully overlapping");
        }
    }

    void OnMove(InputValue input) {
        move = input.Get<Vector2>();
    }

    private bool IsFullyOverlapping() {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 goalPos = new Vector2(goal.transform.position.x, goal.transform.position.y);

        if (playerPos.x + playerRadius <= goalPos.x + goalRadius &&
            playerPos.y + playerRadius <= goalPos.y + goalRadius &&
            playerPos.x - playerRadius >= goalPos.x - goalRadius &&
            playerPos.y - playerRadius >= goalPos.y - goalRadius) {
                return true;
        }
        else {
            return false;
        }
    }

    // private Vector3[] GetPoints() {
    //     Vector3[] points = new Vector3[9];
    //     points[0] = Vector3.zero;

    //     for (int i = 1; i < 9; i++) {
    //         float degree = (i - 1) * 45.0f;
    //         float x = degree * Mathf.Cos(degree * Mathf.Deg2Rad);
    //         float y = degree * Mathf.Sin(degree * Mathf.Deg2Rad);   
    //         points[i] = new Vector3(x, y);
    //     }
    //     return points;
    // }

    // private bool IsFullyOverlapping() {
    //     points = new Vector3[9];
    //     points[0] = Vector3.zero;
    //     float radius = col.radius;

    //     foreach (var point in points) {
    //         Vector3 pointToCheck = transform.position + point;
    //         Collider2D pathCollider = Physics2D.OverlapPoint(pointToCheck, 1 << mask);

    //         if (pathCollider == null) {
    //             return false;
    //         }
    //     }
    //     return true;
    // }
}
