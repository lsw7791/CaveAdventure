using UnityEngine;

public class BuffAttack : MonoBehaviour, IBuff
{
    public float attackMultiplier = 2f; // 데미지 배율
    public float duration = 10f;        // 버프 지속 시간
    public float BuffDuration => duration;

    public void ApplyBuff(Player player)
    {
        // FireBall 데미지 배율을 증가
        SkillManager.Instance.ApplyDamageMultiplierToAllFireBalls(attackMultiplier);
    }

    public void RemoveBuff(Player player)
    {
        // FireBall 데미지 배율을 원래 값으로 복구
        SkillManager.Instance.ApplyDamageMultiplierToAllFireBalls(1f);
    }

    public void ActivateEffect(Player player)
    {
        Transform effect = player.transform.Find("BuffAttEff");
        if (effect != null) effect.gameObject.SetActive(true); // 효과 오브젝트 활성화
    }

    public void DeactivateEffect(Player player)
    {
        Transform effect = player.transform.Find("BuffAttEff");
        if (effect != null) effect.gameObject.SetActive(false); // 효과 오브젝트 비활성화
    }
}
