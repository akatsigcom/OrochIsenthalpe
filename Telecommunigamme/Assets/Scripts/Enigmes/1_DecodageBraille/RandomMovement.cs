using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour //manage movements of butterflies
{
    public float maxSpeed = 5f;
    public float maxTimeChangeDirection;
    private Vector2 movement;
    private float timeLeft;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeLeft = Random.Range(0f, maxTimeChangeDirection);    // butterflies change direction at least every maxTimeChangeDirection
    }

    void Update()
    {
        if (timeLeft <= 0) // at the end of movement new direction + new time
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft = Random.Range(0f, maxTimeChangeDirection);
        }
        else
        {
            timeLeft -= 0.1f;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed); 
    }
}
