using UnityEngine;
using UnityEngine.InputSystem;

public class North : MonoBehaviour
{
    public string targetSceneName; 

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
    }
}
