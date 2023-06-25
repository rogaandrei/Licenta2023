using UnityEngine;
using UnityEngine.InputSystem;

public class Sunet_in_aer : MonoBehaviour
{
    public AudioSource audioSource; 

    private bool isRightTriggerPressed = false;
    private bool isLeftTriggerPressed = false;
    private float initialVolume = 0f;
    private bool isSoundPlaying = false;

    private void Awake()
    {
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
            if (Gamepad.current.rightTrigger.isPressed && !isRightTriggerPressed)
            {
                isRightTriggerPressed = true;

                if (!isSoundPlaying)
                {
                    PlaySoundContinuously();
                }
            }
            else if (!Gamepad.current.rightTrigger.isPressed && isRightTriggerPressed)
            {
                isRightTriggerPressed = false;

                if (isSoundPlaying)
                {
                    StopSound();
                }
            }

            if (Gamepad.current.leftTrigger.isPressed && !isLeftTriggerPressed)
            {
                isLeftTriggerPressed = true;

                if (!isSoundPlaying)
                {
                    PlaySoundContinuously();
                }
            }
            else if (!Gamepad.current.leftTrigger.isPressed && isLeftTriggerPressed)
            {
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
