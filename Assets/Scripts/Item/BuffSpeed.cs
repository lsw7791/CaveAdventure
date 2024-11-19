using UnityEngine;

public class BuffSpeed : MonoBehaviour, IBuff
{
    public float speedMultiplier = 1.5f;  
    public float duration = 10f;           
    public float BuffDuration => duration; 

    public void ApplyBuff(Player player)
    {
        var playerMovement = player.GetComponent<PlayerController>();
        playerMovement.moveSpeed *= speedMultiplier; 
        player.StartCoroutine(RemoveBuffAfterDuration(playerMovement)); 
    }

    public void RemoveBuff(Player player)
    {
        var playerMovement = player.GetComponent<PlayerController>();
        playerMovement.moveSpeed /= speedMultiplier;  
    }

    private System.Collections.IEnumerator RemoveBuffAfterDuration(PlayerController playerMovement)
    {
        yield return new WaitForSeconds(duration);

        playerMovement.moveSpeed /= speedMultiplier; 
    }
}
