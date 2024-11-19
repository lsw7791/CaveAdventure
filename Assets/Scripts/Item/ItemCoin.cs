using UnityEngine;
using UnityEngine.UI;

public class ItemCoin : MonoBehaviour, ICollectible
{
    public Text coinText;
    public int coinCount;

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
