using UnityEngine;
using UnityEngine.UI;

public class UIHeart : MonoBehaviour
{
    public int lifeIncrement = 1;  // 하트 증가량
    private int currentLives = 1;  // 현재 하트 수

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
        // 게임 시작 시 저장된 하트 수를 불러옵니다.
        CurrentLives = PlayerPrefs.GetInt("HeartCount", 1);  // 기본값은 1로 설정
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
