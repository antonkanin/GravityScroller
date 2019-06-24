using System;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (!isTouchPossible)
        {
            return;
        }

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

            const float swipeDistance = 0.001f;

            var sqrMagnitude = (Input.mousePosition - initialMousePosition).sqrMagnitude;

            if (sqrMagnitude >= swipeDistance)
            {
                Swipe();
            }
            else
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