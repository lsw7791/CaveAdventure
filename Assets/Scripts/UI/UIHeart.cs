using UnityEngine;
using UnityEngine.UI;  // 기존 UI.Text를 사용하기 위한 네임스페이스

public class UIHeart : MonoBehaviour
{
    private int currentLives;  // 현재 하트 수
    [SerializeField] public Text heartText;  // 기존 UI.Text를 사용


    private void Awake()
    {
        // 기존 UI.Text를 자식에서 찾기
        if (heartText == null)
        {
            heartText = GetComponentInChildren<Text>();
            if (heartText == null)
            {
                Debug.LogError("Text 컴포넌트를 자식 오브젝트에서 찾을 수 없습니다. 인스펙터에서 수동으로 할당하세요.");
            }
        }

        // 게임 시작 시 저장된 하트 수를 불러옵니다.
        GameManager.Instance.uiHeart = this;
        GameManager.Instance.playerLife = PlayerPrefs.GetInt("HeartCount", 1);  // 기본값은 1로 설정
    }

    private void Start()
    {
        GameManager.Instance.UpdateUI();
    }


 
}