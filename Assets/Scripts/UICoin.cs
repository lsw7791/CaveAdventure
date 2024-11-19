using UnityEngine;

public class UICoin : MonoBehaviour, ICollectible
{
    public int coinIncrement = 1; 
    private int currentCoins = 0; 

    public void Collect()
    {
        currentCoins += coinIncrement; 
    }
}
