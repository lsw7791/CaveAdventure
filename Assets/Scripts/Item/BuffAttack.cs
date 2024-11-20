using UnityEngine;

public class BuffAttack : MonoBehaviour, IBuff
{
    public float attackMultiplier = 2f;
    public float duration = 10f;
    public float BuffDuration => duration;
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // 플레이어의 FireBall을 사용하도록 수정
    public void ApplyBuff(Player player)
    {
        // 게임매니저를 통해 FireBall 풀의 모든 FireBall에 데미지 배율 적용
        SkillManager.Instance.ApplyDamageMultiplierToAllFireBalls(attackMultiplier); // 모든 FireBall의 데미지 배율을 2배로 설정
        player.StartCoroutine(RemoveBuffAfterDuration());
    }

    // 버프 해제 메서드
    public void RemoveBuff(Player player)
    {
        // 게임매니저를 통해 FireBall 풀의 모든 FireBall에 원래 데미지 배율 적용
        SkillManager.Instance.ApplyDamageMultiplierToAllFireBalls(1f); // 모든 FireBall의 데미지 배율을 원래대로 설정
    }

    // 버프 해제 코루틴
    private System.Collections.IEnumerator RemoveBuffAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        SkillManager.Instance.ApplyDamageMultiplierToAllFireBalls(1f); // 원래 데미지 배율로 복원
    }
}
