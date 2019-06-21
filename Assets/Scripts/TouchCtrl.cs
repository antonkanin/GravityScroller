using UnityEngine;

public class TouchCtrl : MonoBehaviour
{
    [SerializeField] private GameCtrl m_gameCtrl = default;
    [SerializeField] private SoundMngr m_soundMngr = default;

    private bool isTouchPossible;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isTouchPossible = true;

            m_gameCtrl.AddPoint();

            m_soundMngr.PlaySoundBall();
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
        }
    }
}
