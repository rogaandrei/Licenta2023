using UnityEngine;
using UnityEngine.InputSystem;

public class NewCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -5f);

    private InputAction lookAction;
    private Vector2 lookInput;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void OnEnable()
    {
        lookAction = new InputAction("Look", binding: "<Gamepad>/rightStick");
        lookAction.Enable();
        lookAction.performed += OnLookPerformed;
        lookAction.canceled += OnLookCanceled;
    }

    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void OnLookCanceled(InputAction.CallbackContext context)
    {
        lookInput = Vector2.zero;
    }

    private void LateUpdate()
    {
        transform.rotation = initialRotation;

        Vector3 desiredPosition = target.position + target.rotation * offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        transform.rotation = target.rotation;
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }
}
