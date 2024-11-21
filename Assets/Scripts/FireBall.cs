using UnityEngine;

public class FireBall : MonoBehaviour
{
    public SkillSO fireBallData;  // 파이어볼 데이터 (스킬 속성)
    private Rigidbody2D rb;       // 파이어볼 Rigidbody2D
    public Vector2 fireBallDir = Vector2.right; // 파이어볼 방향 (기본값: 오른쪽)
    public GameObject hitEff;
    public Transform effPos;
    private ObjectPool<FireBall> pool;           // 오브젝트 풀 참조
    public ParticleSystem FireParticle;             //파티클

    public float damageMultiplier = 1f;         // 데미지 배율 (기본 1배)

    // 오브젝트 풀 설정 메서드
    public void SetPool(ObjectPool<FireBall> objectPool)
    {
        pool = objectPool;
    }

    // 데미지 배율을 설정하는 메서드
    public void SetDamageMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }

    // 발사 메서드
    public void Shoot(Vector2 dir)
    {
        fireBallDir = dir;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; // 초기 속도 리셋
        rb.velocity = fireBallDir.normalized * fireBallData.skillSpeed; // 발사 속도 설정

        IgnoreItemCollisions();  // 아이템과의 충돌 무시
        IgnorePlayerCollision();
    }

    private void IgnorePlayerCollision()
    {
        Player player = FindObjectOfType<Player>(); // 플레이어 객체 찾기
        Collider2D fireBallCollider = GetComponent<Collider2D>(); // 파이어볼의 콜라이더 가져오기

        Collider2D playerCollider = player.GetComponent<Collider2D>(); // 플레이어의 콜라이더 가져오기

        Physics2D.IgnoreCollision(fireBallCollider, playerCollider, true);
    }

    // 아이템과의 충돌을 무시하는 메서드
    private void IgnoreItemCollisions()
    {
        Collider2D fireBallCollider = GetComponent<Collider2D>(); // 파이어볼의 콜라이더 가져오기
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item"); // 아이템 오브젝트들 찾기
        foreach (GameObject item in items)
        {
            Collider2D itemCollider = item.GetComponent<Collider2D>();
            if (itemCollider != null)
            {
                Physics2D.IgnoreCollision(fireBallCollider, itemCollider, true); // 충돌 무시
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 몬스터와 충돌 처리
        if (collision.gameObject.CompareTag("Monster"))
        {
            Monster monster = collision.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                float finalDamage = fireBallData.skillDamage * damageMultiplier;
                monster.TakeDamage((int)finalDamage); // 데미지 적용
                ReturnToPool(); // FireBall을 풀로 반환
                Instantiate(FireParticle, transform.position, Quaternion.identity);
                FireParticle.Play();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 지형과 충돌 처리
        if (collision.gameObject.CompareTag("Groundlayer"))
        {
            ReturnToPool(); // FireBall을 풀로 반환
        }
    }

    // FireBall을 ObjectPool로 반환
    private void ReturnToPool()
    {
        gameObject.SetActive(false); // FireBall 비활성화
        pool.ReturnObject(this);     // ObjectPool로 반환
    }
}
