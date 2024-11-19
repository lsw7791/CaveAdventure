using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public SkillSO fireBallData; // 파이어볼의 데이터 (데미지 등)
    private Rigidbody2D rb;      // 파이어볼의 Rigidbody2D 컴포넌트
    private Vector2 fireBallDir = Vector2.right; // 파이어볼의 방향 (기본적으로 오른쪽으로 설정)

    private void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(fireBallDir * fireBallData.skillSpeed, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 몬스터와 충돌 시 데미지 주기
        if (collision.gameObject.CompareTag("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>(); // 몬스터 컴포넌트 가져오기
            if (monster != null)
            {
                monster.TakeDamage(fireBallData.skillDamage); // 몬스터에게 데미지를 줌
            }
        }

        // GroundLayer와 충돌 시 (필요한 처리)
        if (collision.gameObject.CompareTag("GroundLayer"))
        {
            // 바닥과 충돌했을 때 할 작업을 여기에 추가
        }

        // 충돌 시 파이어볼 비활성화
        gameObject.SetActive(false);
    }
}