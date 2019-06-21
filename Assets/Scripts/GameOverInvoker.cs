using UnityEngine;
using UnityEngine.Events;

public class GameOverInvoker : MonoBehaviour
{
    [SerializeField] private SoundMngr m_soundMngr = default;

    public static UnityEvent GameOverEvent = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOverEvent.Invoke();

        m_soundMngr.PlaySoundGameOver();
    }
}
