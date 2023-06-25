using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Volume: MonoBehaviour
{
    public Slider volumeSlider; 

    private const string VolumePlayerPrefsKey = "Volume"; 

    private void Awake()
    {
        InputSystem.onDeviceChange += UpdateVolumeSlider;
    }

    private void Start()
    {
        float storedVolume = PlayerPrefs.GetFloat(VolumePlayerPrefsKey, 1f); 

        volumeSlider.value = storedVolume; 

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        PlayerPrefs.SetFloat(VolumePlayerPrefsKey, volume); 

        var audioSources = FindObjectsOfType<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }

    private void UpdateVolumeSlider(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added || change == InputDeviceChange.Removed)
        {
            float storedVolume = PlayerPrefs.GetFloat(VolumePlayerPrefsKey, 1f); 
            volumeSlider.value = storedVolume; 
        }
    }
}
