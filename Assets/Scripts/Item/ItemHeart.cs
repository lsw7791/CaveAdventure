using UnityEngine;
using UnityEngine.UI;

public class ItemHeart : MonoBehaviour, ICollectible
{
    public UIHeart uiHeart;
    public int heartCount;
    public Text heartText;

    private void Awake()
    {
        uiHeart = FindObjectOfType<UIHeart>();
        heartText = uiHeart.GetComponentInChildren<Text>();
        int.TryParse(heartText.text, out heartCount);

    }

    public void Collect()
    {
        heartCount++; 
        UpdateUI();  
    }

    public void UpdateUI()
    {
        heartText.text = heartCount.ToString();
    }
}
