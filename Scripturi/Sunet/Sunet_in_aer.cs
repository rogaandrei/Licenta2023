using UnityEngine;
using UnityEngine.InputSystem;

public class Sunet_in_aer : MonoBehaviour
{
    public AudioSource audioSource; // Trageți aici componenta Audio Source din Inspector

    private bool isRightTriggerPressed = false;
    private bool isLeftTriggerPressed = false;
    private float initialVolume = 0f;
    private bool isSoundPlaying = false;

    private void Awake()
    {
        // Păstrăm volumul inițial al sunetului
        if (audioSource != null)
        {
            initialVolume = audioSource.volume;
            audioSource.volume = 0f;
        }
    }

    private void Update()
    {
        if (Gamepad.current != null)
        {
            // Verificăm apăsarea butonului dreapta (rightTrigger)
            if (Gamepad.current.rightTrigger.isPressed && !isRightTriggerPressed)
            {
                // Redăm sunetul doar când butonul este apăsat pentru prima dată
                isRightTriggerPressed = true;

                if (!isSoundPlaying)
                {
                    PlaySoundContinuously();
                }
            }
            else if (!Gamepad.current.rightTrigger.isPressed && isRightTriggerPressed)
            {
                // Oprim sunetul când butonul nu mai este apăsat
                isRightTriggerPressed = false;

                if (isSoundPlaying)
                {
                    StopSound();
                }
            }

            // Verificăm apăsarea butonului stânga (leftTrigger)
            if (Gamepad.current.leftTrigger.isPressed && !isLeftTriggerPressed)
            {
                // Redăm sunetul doar când butonul este apăsat pentru prima dată
                isLeftTriggerPressed = true;

                if (!isSoundPlaying)
                {
                    PlaySoundContinuously();
                }
            }
            else if (!Gamepad.current.leftTrigger.isPressed && isLeftTriggerPressed)
            {
                // Oprim sunetul când butonul nu mai este apăsat
                isLeftTriggerPressed = false;

                if (isSoundPlaying)
                {
                    StopSound();
                }
            }
        }
    }

    private void PlaySoundContinuously()
    {
        if (audioSource != null)
        {
            audioSource.volume = initialVolume;
            audioSource.loop = true;
            audioSource.Play();
            isSoundPlaying = true;
        }
    }

    private void StopSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.volume = 0f;
            isSoundPlaying = false;
        }
    }
}
