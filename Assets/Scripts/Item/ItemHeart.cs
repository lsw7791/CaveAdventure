using UnityEngine;
using UnityEngine.UI;


public class ItemHeart : MonoBehaviour, ICollectible
{
    public int heartCount;         
    public Text heartText;       

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
