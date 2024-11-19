using UnityEngine;
using UnityEngine.UI;

public class ItemCoin : MonoBehaviour, ICollectible
{
    public UICoin uiCoin;  
    public Text coinText;   
    public int coinCount;

    private void Awake()
    {
        uiCoin = FindObjectOfType<UICoin>();
        coinText = uiCoin.GetComponentInChildren<Text>();
        int.TryParse(coinText.text, out coinCount);
    }

    public void Collect()
    {
        coinCount++;
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinText.text = coinCount.ToString();
    }
}
