using UnityEngine;

public class UIHeart : MonoBehaviour, ICollectible
{
    public int lifeIncrement = 1; 
    private int currentLives = 1;
   
    public void Collect()
    {
        currentLives += lifeIncrement; 
    }
}
