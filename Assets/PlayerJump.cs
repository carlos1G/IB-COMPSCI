using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float jumpForce = 6;


    private float playerHalfHeight;
    void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || GetIsGrounded())
        {
            Jump();
        }
    }

    private bool GetIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight+0.1f, LayerMask.GetMask("Ground"));
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
