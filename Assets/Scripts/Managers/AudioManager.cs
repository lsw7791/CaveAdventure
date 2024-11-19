using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;

    public static object Instance { get; internal set; }

    private void Start()
    {
        PlayMusic(0);
    }

    public void PlayMusic(int musicIndex)
    {
        if (musicClips.Length > musicIndex)
        {
            musicSource.clip = musicClips[musicIndex];
            musicSource.Play();
        }
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxClips.Length > sfxIndex)
        {
            sfxSource.PlayOneShot(sfxClips[sfxIndex]);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
