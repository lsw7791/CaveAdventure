using UnityEngine;

public class ItemCoin : MonoBehaviour, ICollectible
{
    private UICoin uiCoin;

    private void Awake()
    {
        // UICoin을 찾아서 참조합니다.
        uiCoin = FindObjectOfType<UICoin>();
    }

    public void Collect()
    {
        // 코인 획득 시 UICoin의 Collect 메서드 호출
        uiCoin.Collect();
    }
}
