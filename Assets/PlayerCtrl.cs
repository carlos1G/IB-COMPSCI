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
        spriteRenderer.flipX = false; // Start facing right
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        playerHalfWidth = spriteRenderer.bounds.size.x;
        xPosLastFrame = transform.position.x; // Initialize last frame position
    }

    private void Update()
    {
        HandleMovement();
        FlipCharacterX();
    }

    private void FlipCharacterX()
    {
        float threshold = 0.01f; // Prevent small unintended flips

        if (Mathf.Abs(transform.position.x - xPosLastFrame) > threshold) // Corrected flip logic
        {
            spriteRenderer.flipX = transform.position.x < xPosLastFrame; // Flip left or right
        }

        xPosLastFrame = transform.position.x;
    }

    private void ClampMovement()
    {
        float extendedBounds = screenBounds.x * 2; // Extend beyond camera view
        float clampedX = Mathf.Clamp(transform.position.x, -extendedBounds + playerHalfWidth, extendedBounds - playerHalfWidth);

        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;
    }

    private void HandleMovement()
    {
        float input = Input.GetAxis("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);

        animator.SetBool("isRunning", input != 0); // Simplified animation logic
    }
}