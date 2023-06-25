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
        // Increment the current camera index
        currentCameraIndex++;

        // Check if we have exceeded the number of available cameras
        if (currentCameraIndex >= cameras.Length)
        {
            // If so, reset the index to 0
            currentCameraIndex = 0;
        }

        // Activate the current camera and deactivate the other cameras
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
