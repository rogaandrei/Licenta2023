using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{
    private void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
