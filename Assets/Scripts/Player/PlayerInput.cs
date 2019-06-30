using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameEvent jumpEvent = default;
    [SerializeField] private GameEvent flyEvent = default;
    [SerializeField] private GameEvent landEvent = default;

    private bool isTouchPossible;

    private bool isMouseDown = false;
    private Vector3 initialMousePosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GetComponent<PlayerMovement>().Land();

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
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isMouseDown)
            {
                isMouseDown = true;
                initialMousePosition = Input.mousePosition;
            }
        }
        else if (isMouseDown)
        {
            isMouseDown = false;

            const float swipeSquaredDistance = 20000.0f; // pixels;

            var sqrMagnitude = (Input.mousePosition - initialMousePosition).sqrMagnitude;

            if (sqrMagnitude >= swipeSquaredDistance)
            {
                var deltaY = initialMousePosition.y - Input.mousePosition.y;

                if ((Physics2D.gravity.y > 0 && deltaY > 0) ||
                    (Physics2D.gravity.y < 0 && deltaY < 0))
                {
                    Swipe();
                }
            }
            // jump should only work when the player is walking on the platform
            else if (isTouchPossible)
            {
                Tap();
            }
        }
    }

    private void Swipe()
    {
        flyEvent.Raise();
    }

    private void Tap()
    {
        jumpEvent.Raise();
    }
}