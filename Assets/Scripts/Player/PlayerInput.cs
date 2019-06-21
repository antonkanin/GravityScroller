using UnityEngine;

public class PlayerInput: MonoBehaviour
{
    [SerializeField] private GameEvent jumpEvent = default;
    [SerializeField] private GameEvent landEvent = default;

    private bool isTouchPossible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            landEvent.Raise();

            isTouchPossible = true;
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
            jumpEvent.Raise();
        }
    }
}