using UnityEngine;

public class ItemHeart : MonoBehaviour, ICollectible
{
    private UIHeart uiHeart;  // UIHeart 참조

    private void Awake()
    {
        // UIHeart를 찾아서 참조
        uiHeart = FindObjectOfType<UIHeart>();
    }

    public void Collect()
    {
        // 하트를 증가시키고 UI 갱신
        uiHeart.Collect();
    }
}
