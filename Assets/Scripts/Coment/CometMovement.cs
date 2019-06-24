using System;
using UnityEngine;

public class CometMovement : MonoBehaviour
{
    [SerializeField] private float speed = default;

    [SerializeField] private GameObject explosionPrefab = default;

    void Update()
    {
        transform.position += Vector3.left * speed;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var explosion = Instantiate(explosionPrefab, transform.position + 2f * Vector3.left, Quaternion.identity);
        Destroy(explosion, 1.0f);
    }
}