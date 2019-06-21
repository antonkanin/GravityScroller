using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    private static readonly int isJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().flipY = true;
    }

    public void Land()
    {
        animator.SetBool(isJumping, false);
    }

    public void Jump()
    {
        Physics2D.gravity = -Physics2D.gravity;

        if (Physics2D.gravity.y > 0f)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }

        animator.SetBool(isJumping, true);
    }
}