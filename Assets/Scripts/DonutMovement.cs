using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutMovement : MonoBehaviour {
    [SerializeField] private Transform[] waypoints;
    private int waypointsLength;
    private float speed = 2.5f;
    private int currPoint = 1;
    private float t;
    private float wait = 0.5f;

    void Start() {
        transform.position = waypoints[0].position;
        waypointsLength = waypoints.Length;
        t = Time.time;
    }

    void Update() {
        if (Time.time - t > wait) {
            Move();
        }
    }

    private void Move() {
        if (currPoint < waypointsLength) {
            transform.position = Vector2.MoveTowards(transform.position, 
                waypoints[currPoint].transform.position,
                speed * Time.deltaTime);

            if (transform.position == waypoints[currPoint].transform.position) {
                currPoint++;
            }
        }
    }
}
