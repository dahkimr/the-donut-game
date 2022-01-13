using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StampController : MonoBehaviour
{
    [SerializeField] private GameObject hole;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float speed = 5.0f;
    private bool keepMoving = true;
    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(hole, new Vector2(transform.position.x, 0), Quaternion.identity);
        }
    }
}

