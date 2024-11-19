using UnityEngine;
using UnityEngine.UI;

public class UICoin : MonoBehaviour
{
    public int coinIncrement = 1;  // 코인 획득 시 증가할 양
    private int currentCoins = 0;   // 현재 보유한 코인 수

    public int CurrentCoins
    {
        get { return currentCoins; }
        private set
        {
            currentCoins = value;
            UpdateUI();  // 코인 수가 변경될 때마다 UI를 갱신
        }
    }

    private void Start()
    {
        // 게임 시작 시 저장된 코인 수를 불러옵니다.
        CurrentCoins = PlayerPrefs.GetInt("CoinCount", 0); // "CoinCount"는 PlayerPrefs에서 저장된 키
    }

    public void Collect()
    {
        // 코인 증가
        CurrentCoins += coinIncrement;
        PlayerPrefs.SetInt("CoinCount", CurrentCoins); // 새로운 코인 수 저장
        PlayerPrefs.Save();  // 변경 사항 저장
    }

    private void UpdateUI()
    {
        // UI 갱신
        Text coinText = GetComponentInChildren<Text>();
        if (coinText != null)
        {
            coinText.text = CurrentCoins.ToString();
        }
    }
}
