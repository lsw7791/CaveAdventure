using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource BGMSource;  // 배경 음악을 담당하는 AudioSource
    public AudioSource SFXSource;  // 효과음을 담당하는 AudioSource

    public Slider musicSlider;     // 음악 볼륨 조절을 위한 Slider
    public Text volumeText;        // 볼륨 텍스트 (볼륨 비율을 보여줄 텍스트)

    void Start()
    {
        // SoundManager에서 BGMSource와 SFXSource를 가져오기
        BGMSource = SoundManager.Instance._bgmSource;
        SFXSource = SoundManager.Instance._sfxSource;

        // musicSlider와 BGMSource가 올바르게 할당되었는지 확인 후 초기화
        if (musicSlider != null && BGMSource != null)
        {
            // 슬라이더를 활성화하여 마우스로 조작할 수 있게 함
            musicSlider.interactable = true;  // 마우스로 조작 가능하도록 설정

            // 키보드 입력을 막기 위해 포커스 제거
            musicSlider.navigation = new Navigation
            {
                mode = Navigation.Mode.None  // 키보드 입력을 받지 않도록 설정
            };

            // 슬라이더 값 초기화 (0 ~ 1 범위로 설정)
            musicSlider.value = BGMSource.volume * 100f;  // 0~1 범위의 값을 0~100 범위로 설정
            UpdateVolumeText(musicSlider.value);   // 볼륨 텍스트 업데이트

            // 슬라이더 값이 변경될 때마다 `OnMusicVolumeChanged` 호출
            musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }
    }

    // 슬라이더 값이 변경될 때 호출되는 메서드
    public void OnMusicVolumeChanged(float value)
    {
        float normalizedValue = value / 100f;  // 값을 0~1 범위로 변환
        if (BGMSource != null)
        {
            BGMSource.volume = normalizedValue;  // BGM 볼륨을 변경
            UpdateVolumeText(normalizedValue);   // 볼륨 텍스트를 업데이트
        }
    }

    // 볼륨 텍스트를 갱신하는 메서드 (백분율로 표시)
    private void UpdateVolumeText(float value)
    {
        if (volumeText != null)
        {
            int percentage = Mathf.RoundToInt(value * 100);  // 백분율로 변환
            volumeText.text = "Volume: " + percentage + "%";  // 텍스트에 볼륨 표시
        }
    }
}
