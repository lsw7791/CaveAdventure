using UnityEngine;

public class FireBallDamage : MonoBehaviour
{
    private GameManager gameManager;

    public float damageMultiplier = 1f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // FireBall을 발사하는 메서드
    public void Shoot(Vector2 direction)
    {
        // 풀에서 FireBall을 가져옵니다
        FireBall fireBall = gameManager.GetFireBallFromPool(transform.position, Quaternion.identity); // 현재 위치와 기본 회전값으로 FireBall 가져오기
        if (fireBall != null)
        {
            fireBall.SetDamageMultiplier(damageMultiplier); // 데미지 배율 설정
            fireBall.Shoot(direction); // FireBall 발사
        }
    }

    // FireBall의 데미지 배율만 설정하는 메서드
    public void ApplyDamageMultiplier(FireBall fireBall)
    {
        fireBall.SetDamageMultiplier(damageMultiplier); // FireBall의 데미지 배율 설정
    }
}
