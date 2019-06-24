using UnityEngine;

public class GameOverInvoker : MonoBehaviour
{
    [SerializeField] private GameEvent gameOverEvent = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOverEvent.Raise();
    }
}