using UnityEngine;
using UnityEngine.UI;  // 기존 UI.Text를 사용하기 위한 네임스페이스

public class UIHeart : MonoBehaviour
{
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
        GameManager.Instance.uiHeart = this;
    }

    private void Start()
    {
        GameManager.Instance.UpdateUI();
    }


 
}