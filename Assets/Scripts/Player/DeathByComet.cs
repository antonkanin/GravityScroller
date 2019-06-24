using System;
using UnityEngine;

public class DeathByComet : MonoBehaviour
{
    [SerializeField] private GameEvent cometHitEvent = default;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Consts.CometTag))
        {
            Debug.Log("DeathByComet::HitEvent()");
            cometHitEvent.Raise();
        }
    }
}