using UnityEngine;

public class TouchCtrl : MonoBehaviour
{
    [SerializeField] private GameController mGameController = default;
    [SerializeField] private SoundMngr m_soundMngr = default;

    private Animator animator;

    private bool isTouchPossible;

    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<SpriteRenderer>().flipY = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isTouchPossible = true;

            mGameController.AddPoint();

            m_soundMngr.PlaySoundBall();
            
            animator.SetBool(IsJumping, false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchPossible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTouchPossible)
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

            animator.SetBool(IsJumping, true);
        }
    }
}