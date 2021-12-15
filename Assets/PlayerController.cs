using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float SPEED = 3.0f;
    private Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(SPEED * move * Time.deltaTime);
    }

    void OnMove(InputValue input) {
        move = input.Get<Vector2>();
    }
}
