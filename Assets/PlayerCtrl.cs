using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private float x;
    private float y;

    private Vector2 input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x * moveSpeed, y * moveSpeed);
    }

    private void GetInput()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if(x > 1)
        {
            x = 1;
        }

        input = new Vector2(x, y);
        input.Normalize(); // Normalize the input vector to prevent faster diagonal movement
    }
}