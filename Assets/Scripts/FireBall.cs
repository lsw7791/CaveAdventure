using UnityEngine;

public class FireBall : MonoBehaviour
{
    public SkillSO fireBallData; // 파이어볼 데이터 (스킬 속성)
    private Rigidbody2D rb;      // 파이어볼 Rigidbody2D
    public Vector2 fireBallDir = Vector2.right; // 파이어볼 방향 (기본값: 오른쪽)
    private ObjectPool<FireBall> pool;          // 오브젝트 풀 참조

    // 오브젝트 풀 설정 메서드
    public void SetPool(ObjectPool<FireBall> objectPool)
    {
        pool = objectPool;
    }

   
    public void Shoot(Vector2 dir)
    {
        fireBallDir = dir;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; // 초기 속도 리셋
        rb.velocity = fireBallDir.normalized * fireBallData.skillSpeed; // 발사 속도 설정

        // FireBall과 플레이어의 충돌을 무시
        Player player = FindObjectOfType<Player>(); // 플레이어 객체 찾기
        if (player != null)
        {
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            Collider2D fireBallCollider = GetComponent<Collider2D>();
            if (playerCollider != null && fireBallCollider != null)
            {
                Physics2D.IgnoreCollision(fireBallCollider, playerCollider, true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 몬스터와 충돌 처리
        if (collision.gameObject.CompareTag("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(fireBallData.skillDamage); // 데미지 적용
            }
        }

        // 지형과 충돌 처리
        if (collision.gameObject.CompareTag("Groundlayer"))
        {
            // 지형과 충돌 시 오브젝트 풀로 반환
            ReturnToPool();
        }
    }

    // FireBall을 ObjectPool로 반환
    private void ReturnToPool()
    {
        gameObject.SetActive(false); // FireBall 비활성화
        pool.ReturnObject(this);     // ObjectPool로 반환
    }
}
