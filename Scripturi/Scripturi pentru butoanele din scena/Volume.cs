using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Volume: MonoBehaviour
{
    public Slider volumeSlider; // Referință la componenta Slider pentru volum

    private const string VolumePlayerPrefsKey = "Volume"; // Cheia pentru stocarea volumului în PlayerPrefs

    private void Awake()
    {
        InputSystem.onDeviceChange += UpdateVolumeSlider;
    }

    private void Start()
    {
        float storedVolume = PlayerPrefs.GetFloat(VolumePlayerPrefsKey, 1f); // Recuperează volumul din PlayerPrefs sau folosește valoarea implicită (1f)

        volumeSlider.value = storedVolume; // Setează valoarea sliderului la volumul stocat

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        PlayerPrefs.SetFloat(VolumePlayerPrefsKey, volume); // Salvează volumul în PlayerPrefs

        // Aplică volumul în toate componentele AudioSource din scenele respective
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
            float storedVolume = PlayerPrefs.GetFloat(VolumePlayerPrefsKey, 1f); // Recuperează volumul din PlayerPrefs sau folosește valoarea implicită (1f)
            volumeSlider.value = storedVolume; // Actualizează valoarea sliderului cu volumul stocat
        }
    }
}
