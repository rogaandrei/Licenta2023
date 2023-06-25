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
        // Obținem input-ul de la joystick
        lookInput = context.ReadValue<Vector2>();
    }

    private void OnLookCanceled(InputAction.CallbackContext context)
    {
        // Resetăm input-ul când joystick-ul nu este folosit
        lookInput = Vector2.zero;
    }

    private void LateUpdate()
    {
        // Fixăm camera să se uite drept înainte
        transform.rotation = initialRotation;

        // Calculăm poziția dorită a camerei în funcție de offset și poziția țintei
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Interpolăm în mod liniar între poziția curentă a camerei și poziția dorită pentru un efect de mișcare lină
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizăm poziția camerei
        transform.position = smoothedPosition;

        // Rotim camera în funcție de rotația dronei
        transform.rotation = target.rotation;
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }
}
