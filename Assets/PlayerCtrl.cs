using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Vector2 screenBounds;
    private float playerHalfWidth;
    private float xPosLastFrame;

    void Start()
    {
        FlipCharacterX(); // Ensure the character starts facing right
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        playerHalfWidth = spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        HandleMovement();
        ClampMovement();
        FlipCharacterX();
    }

    private void FlipCharacterX()
    {
        if (transform.position.x >= xPosLastFrame)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < xPosLastFrame)
        {
            spriteRenderer.flipX = true;
        }
        xPosLastFrame = transform.position.x;
    }

    private void ClampMovement()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;
    }

    private void HandleMovement()
    {
        float input = Input.GetAxis("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        if (input != 0)
        {
            animator.SetBool("isRunning", true);
        } 
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}