using UnityEngine;
using System.Collections;
using System;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    float inputHorizontal;
    float inputVertical;
    float speed = 10f;

    bool facingRight = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(inputHorizontal * speed, rb.linearVelocity.y);

        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

}