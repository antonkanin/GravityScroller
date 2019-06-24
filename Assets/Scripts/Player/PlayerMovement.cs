using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D playerRigidbody2D;

    private static readonly int isJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer.flipY = true;
    }

    public void Land()
    {
        animator.SetBool(isJumping, false);
    }

    public void Fly()
    {
        Physics2D.gravity = -Physics2D.gravity;

        spriteRenderer.flipY = Physics2D.gravity.y > 0f;

        animator.SetBool(isJumping, true);
    }

    public void Jump()
    {
        var jumpForce = -Mathf.Sign(Physics2D.gravity.y) * 5f * Vector2.up;

        playerRigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
    }
}