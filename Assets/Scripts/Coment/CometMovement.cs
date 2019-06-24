using UnityEngine;

public class CometMovement : MonoBehaviour
{
    [SerializeField] private float speed = default;

    void Update()
    {
        transform.position += Vector3.left * speed;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}