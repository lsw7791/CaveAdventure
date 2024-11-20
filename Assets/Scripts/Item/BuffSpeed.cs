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
    }

    public void RemoveBuff(Player player)
    {
        var playerMovement = player.GetComponent<PlayerController>();
        playerMovement.moveSpeed /= speedMultiplier;
    }

    public void ActivateEffect(Player player)
    {
        Transform effect = player.transform.Find("BuffSpdEff");
        if (effect != null) effect.gameObject.SetActive(true);
    }

    public void DeactivateEffect(Player player)
    {
        Transform effect = player.transform.Find("BuffSpdEff");
        if (effect != null) effect.gameObject.SetActive(false);
    }
}
