using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Text pauseText; // Referință la componenta Text pentru a afișa textul de pauză
    private bool isPaused = false; // Indicator pentru pauză

    private void Start()
    {
        pauseText.gameObject.SetActive(false); // Dezactivează textul la început
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f; // Pauzează timpul jocului
        isPaused = true;
        pauseText.gameObject.SetActive(true); // Activează textul de pauză
        Debug.Log("Game paused!");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Reia timpul jocului
        isPaused = false;
        pauseText.gameObject.SetActive(false); // Dezactivează textul de pauză
        Debug.Log("Game resumed!");
    }
}
