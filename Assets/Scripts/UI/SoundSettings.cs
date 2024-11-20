using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource BGMSource;
    public AudioSource SFXSource;

    public Slider musicSlider;
    public Text volumeText;

    void Start()
    {
        // Initialize BGMSource and SFXSource from SoundManager
        BGMSource = SoundManager.Instance._bgmSource;
        SFXSource = SoundManager.Instance._sfxSource;

        // Check if musicSlider and BGMSource are assigned before adding listener
        if (musicSlider != null && BGMSource != null)
        {
            musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            musicSlider.value = BGMSource.volume;  // Set initial slider value to current BGM volume
            UpdateVolumeText(musicSlider.value);   // Update the volume text
        }
    }

    // This method will be triggered when the slider value changes
    public void OnMusicVolumeChanged(float value)
    {
        value /= 100f;
        if (BGMSource != null)
        {
            BGMSource.volume = value;  // Set the volume of the BGM
            UpdateVolumeText(value);   // Update the text showing the volume percentage
        }
    }

    // Updates the volume text to show the current volume as a percentage
    private void UpdateVolumeText(float value)
    {
        if (volumeText != null)
        {
            int percentage = Mathf.RoundToInt(value * 100);  // Convert the value to percentage
            volumeText.text = "Volume: " + percentage + "%";  // Update the text
        }
    }
}