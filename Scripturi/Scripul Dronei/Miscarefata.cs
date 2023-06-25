using UnityEngine;
using UnityEngine.InputSystem;

public class Miscarefata : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody droneRigidbody;
    private float currentHeight;
    private bool isLeftTriggerPressed = false;

    private InputAction leftTriggerAction;

    private void OnEnable()
    {
        leftTriggerAction = new InputAction("LeftTrigger", binding: "<Gamepad>/leftTrigger");
        leftTriggerAction.Enable();
        leftTriggerAction.started += OnLeftTriggerPressed;
        leftTriggerAction.canceled += OnLeftTriggerReleased;

        droneRigidbody = GetComponent<Rigidbody>();
    }

    private void OnLeftTriggerPressed(InputAction.CallbackContext context)
    {
        isLeftTriggerPressed = true;
    }

    private void OnLeftTriggerReleased(InputAction.CallbackContext context)
    {
        isLeftTriggerPressed = false;
    }

    private void FixedUpdate()
    {
        if (isLeftTriggerPressed)
        {
            // Set the movement velocity to move the drone forward at its current height
            Vector3 movement = transform.forward * movementSpeed;
            movement.y = droneRigidbody.velocity.y;

            // Set the vertical velocity to zero to prevent upward movement
            movement.y = 0f;

            droneRigidbody.velocity = movement;
        }
    }

    private void OnDisable()
    {
        leftTriggerAction.Disable();
    }
}
