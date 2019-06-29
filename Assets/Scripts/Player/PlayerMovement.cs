using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D playerRigidbody2D;

    private static readonly int isJumping = Animator.StringToHash("isJumping");

    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }

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
        var jumpForceVector = -Mathf.Sign(Physics2D.gravity.y) * jumpForce * Vector2.up;

        playerRigidbody2D.AddForce(jumpForceVector, ForceMode2D.Impulse);
    }
}