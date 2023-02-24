using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StampController : MonoBehaviour
{
    [SerializeField] private Animator animCtlr;
    [SerializeField] private GameObject donut;
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private GameObject game;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private AudioSource audioSource;

    private const float downSpeed = 2.0f;
    private const float downDiff = 0.8f;
    private Vector3 downPosition;
    private float speed;
    private bool keepMoving = true;
    private bool movingDown = false;

    // Start is called before the first frame update
    void Start() {
        speed = GameInfo.getSpeed();
        transform.position = start.transform.position;
    }

    void Update() {
        if (keepMoving && transform.position.x < end.transform.position.x) {
            transform.position = new Vector2(transform.position.x + 4 * Time.deltaTime, transform.position.y);
            // transform.position = Vector2.MoveTowards(transform.position, 
            //     end.transform.position,
            //     speed * Time.deltaTime);
        }
        else if (movingDown) {
            MoveHandDown();
        }
    }

    void OnStamp(InputValue input) {
        if (keepMoving) {
            audioSource.Play();
            keepMoving = false;

            downPosition = transform.position - new Vector3(0, downDiff, 0);
            movingDown = true;
        }
    }

    private void MoveHandDown() {
        transform.position = Vector2.MoveTowards(transform.position,
            downPosition,
            downSpeed * Time.deltaTime);

        if (transform.position == downPosition) {
            movingDown = false;

            // lower opacity of hand
            animCtlr.SetBool("fadeHand", true);

            // appear hole and calculate and show rank
            Instantiate(holePrefab, new Vector2(transform.position.x, -0.09f), Quaternion.identity);
            float distance = Mathf.Abs(transform.position.x - donut.transform.position.x);

            game.GetComponent<Game>().CalcRank(distance);
        }
    }
}

