using UnityEngine;
using UnityEngine.InputSystem;

public class Elice : MonoBehaviour
{
    public float rotationSpeed = 200f;
    private bool isRotating = false;

    private void Start()
    {
        // Obține referința la acțiunea de apăsare a butonului dreapta
        InputAction rightTriggerAction = new InputAction("RightTrigger", binding: "<Gamepad>/rightTrigger");
        rightTriggerAction.performed += OnRightTrigger;
        rightTriggerAction.canceled += OnRightTrigger;
        rightTriggerAction.Enable();

        // Obține referința la acțiunea de apăsare a butonului stânga
        InputAction leftTriggerAction = new InputAction("LeftTrigger", binding: "<Gamepad>/leftTrigger");
        leftTriggerAction.performed += OnLeftTrigger;
        leftTriggerAction.canceled += OnLeftTrigger;
        leftTriggerAction.Enable();
    }

    private void Update()
    {
        if (isRotating)
        {
            // Rotirea elicei
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnRightTrigger(InputAction.CallbackContext context)
    {
        float triggerValue = context.ReadValue<float>();
        if (triggerValue > 0.2f)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }
    }

    private void OnLeftTrigger(InputAction.CallbackContext context)
    {
        float triggerValue = context.ReadValue<float>();
        if (triggerValue > 0.2f)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }
    }

    private void OnDisable()
    {
        // Dezactivează acțiunile de input
        InputAction rightTriggerAction = new InputAction("RightTrigger", binding: "<Gamepad>/rightTrigger");
        rightTriggerAction.Disable();

        InputAction leftTriggerAction = new InputAction("LeftTrigger", binding: "<Gamepad>/leftTrigger");
        leftTriggerAction.Disable();
    }
}
