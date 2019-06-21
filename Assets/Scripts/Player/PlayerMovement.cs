using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private static readonly int isJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipY = true;
    }

    public void Land()
    {
        animator.SetBool(isJumping, false);
    }

    public void Jump()
    {
        Physics2D.gravity = -Physics2D.gravity;

        spriteRenderer.flipY = Physics2D.gravity.y > 0f;

        animator.SetBool(isJumping, true);
    }
}