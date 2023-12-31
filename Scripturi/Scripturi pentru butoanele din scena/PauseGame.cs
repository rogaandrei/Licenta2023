﻿using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Text pauseText; 
    private bool isPaused = false; 

    private void Start()
    {
        pauseText.gameObject.SetActive(false); 
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
        Time.timeScale = 0f; 
        isPaused = true;
        pauseText.gameObject.SetActive(true); 
        Debug.Log("Game paused!");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        pauseText.gameObject.SetActive(false); 
        Debug.Log("Game resumed!");
    }
}
