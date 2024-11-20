using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public SoundManager instance;
    private GameObject _bgmObj;
    private GameObject _sfxObj;

    private AudioSource _bgmSource;
    private AudioSource _sfxSource;

    [Header("BGM")]
    [SerializeField] private AudioClip bgmClip;

    [Header("SFX")]
    [SerializeField] private AudioClip collisionSfx;
    [SerializeField] private AudioClip clickSfx;
    [SerializeField] private AudioClip itemSfx;
    protected override void Awake()
    {
        base.Awake();
        SetAudioSource();
        SetAudioClip();
    }
    private void Start()
    {
        _bgmSource.volume = 0.5f;
        _sfxSource.volume = 0.5f;
        PlayBGM(bgmClip);
    }
    private void SetAudioSource()
    {
        // AudioManager�� �ڽ����� AudioSource ������Ʈ ���� @BGM ����
        _bgmObj = new GameObject("@BGM");
        _bgmObj.transform.parent = transform;
        _bgmSource = _bgmObj.AddComponent<AudioSource>();

        // AudioManager�� �ڽ����� AudioSource ������Ʈ ���� @SFX ����
        _sfxObj = new GameObject("@SFX");
        _sfxObj.transform.parent = transform;
        _sfxSource = _sfxObj.AddComponent<AudioSource>();
    }

    private void SetAudioClip()
    {
        // Resource �������� �� AudioClip�� �´� ���� �ε�
        bgmClip = Resources.Load<AudioClip>("Prefabs/Sounds/ambient-game-67014");
        collisionSfx = Resources.Load<AudioClip>("Prefabs/Sounds/game-start-6104");
        clickSfx = Resources.Load<AudioClip>("Prefabs/Sounds/game-start-6104");
        itemSfx = Resources.Load<AudioClip>("Prefabs/Sounds/collect-ring-15982");
    }

    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.clip != clip)
        {
            _bgmSource.clip = clip;
            _bgmSource.loop = true;
            _bgmSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void PlayStartBGM() => PlayBGM(bgmClip);
    public void PlayCollsionSFX() => PlaySFX(collisionSfx);
    public void PlayClickSFX() => PlaySFX(clickSfx);

    public float GetBGMVolume() => _bgmSource.volume;
    public void SetBGMVolume(float volume) => _bgmSource.volume = volume;

    public float GetSFXVolume() => _sfxSource.volume;
    public void SetSFXVolume(float volume) => _sfxSource.volume = volume;
}
