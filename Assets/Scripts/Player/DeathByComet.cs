using UnityEngine;

public class DeathByComet : MonoBehaviour
{
    [SerializeField] private GameEvent cometHitEvent = default;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Consts.CometTag))
        {
            cometHitEvent.Raise();
        }
    }
}