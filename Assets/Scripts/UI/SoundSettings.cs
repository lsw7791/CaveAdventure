using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource musicSource;  
    public Slider musicSlider;       
    public Text volumeText;          

    void Start()
    {
        if (musicSlider != null && musicSource != null)
        {
            musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            musicSlider.value = musicSource.volume;  
            UpdateVolumeText(musicSlider.value);    
        }
    }

    
    public void OnMusicVolumeChanged(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = value;
            UpdateVolumeText(value);  
        }
    }

    
    private void UpdateVolumeText(float value)
    {
        if (volumeText != null)
        {
            int percentage = Mathf.RoundToInt(value * 100);  
            volumeText.text = "Volume: " + percentage + "%";  
        }
    }
}
