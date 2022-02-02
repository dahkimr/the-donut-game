using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StampController : MonoBehaviour
{
    [SerializeField] private GameObject donut;
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private GameObject game;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    private float speed;
    private bool keepMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameInfo.getSpeed();
        transform.position = start.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepMoving) {
            transform.position = Vector2.MoveTowards(transform.position, 
                end.transform.position,
                speed * Time.deltaTime);
        }
    }

    void OnStamp(InputValue input) {
        if (keepMoving) {
            keepMoving = false;
            Instantiate(holePrefab, new Vector2(transform.position.x, -0.09f), Quaternion.identity);
            float distance = Mathf.Abs(transform.position.x - donut.transform.position.x);

            transform.position = start.transform.position;

            game.GetComponent<Game>().CalcRank(distance);
        }
    }
}

