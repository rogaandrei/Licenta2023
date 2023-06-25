using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private int currentCameraIndex = 0;

    private InputAction buttonSouthAction;

    private void OnEnable()
    {
        buttonSouthAction = new InputAction("ButtonSouth", binding: "<Gamepad>/buttonSouth");
        buttonSouthAction.Enable();
        buttonSouthAction.performed += OnButtonSouthPressed;
    }

    private void OnButtonSouthPressed(InputAction.CallbackContext context)
    {
        currentCameraIndex++;

        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }

    private void OnDisable()
    {
        buttonSouthAction.Disable();
    }
}
