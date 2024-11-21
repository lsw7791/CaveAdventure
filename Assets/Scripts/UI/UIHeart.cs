using UnityEngine;
using UnityEngine.UI;

public class UIHeart : MonoBehaviour
{
    public int lifeIncrement = 1;  // 하트 증가량
    private int currentLives = 1;  // 현재 하트 수

    private PlayerController playerController;

    public int CurrentLives
    {
        get { return currentLives; }
        private set
        {
            currentLives = value;
            UpdateUI();  // 하트 수가 변경될 때마다 UI를 갱신
        }
    }

    private void Start()
    {
        InitializeLives();

        // 게임 시작 시 저장된 하트 수를 불러옵니다.
        CurrentLives = PlayerPrefs.GetInt("HeartCount", 1);  // 기본값은 1로 설정
        playerController= FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.uiHeart = this;
        }
        GameManager.Instance.uiHeart = this;
    }

    public void InitializeLives()
    {
        // 하트를 1로 초기화
        CurrentLives = 1;
        PlayerPrefs.SetInt("HeartCount", CurrentLives);  // 하트 수를 PlayerPrefs에 저장
        PlayerPrefs.Save();  // 저장 강제 적용
    }

    public void Collect()
    {
        // 하트를 증가시키고 UI를 갱신합니다.
        CurrentLives += lifeIncrement;
        PlayerPrefs.SetInt("HeartCount", CurrentLives);  // 새로운 하트 수 저장
        PlayerPrefs.Save();  // 변경 사항 저장
    }

    public void Loss()
    {
        CurrentLives -= lifeIncrement ;  // 하트 감소
        PlayerPrefs.SetInt("HeartCount", CurrentLives);  // 새로운 하트 수 저장
        PlayerPrefs.Save();  // 변경 사항 저장
        
    }

    private void UpdateUI()
    {
        // UI 갱신
        
        Text heartText = GetComponentInChildren<Text>();
        if (heartText != null)
        {
            heartText.text = CurrentLives.ToString();
        }
    }
}
