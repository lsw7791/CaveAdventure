using UnityEngine;

public class Player : MonoBehaviour
{
    public FireBall fireBallPrefab;
    public Transform firePoint;
    private ObjectPool<FireBall> fireBallPool;
    private SpriteRenderer spriteRenderer; // SpriteRenderer 참조

    private void Start()
    {
        fireBallPool = new ObjectPool<FireBall>();
        fireBallPool.Initialize(fireBallPrefab, 10, transform);
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 가져오기
    }

    private void Update()
    {
        // 마우스 우클릭으로 발사
        if (Input.GetMouseButtonDown(1)) // 우클릭 입력 확인
        {
            ShootFireBall();
        }
    }

    private void ShootFireBall()
    {
        Vector3 firePointPosition = firePoint.position;

        FireBall fireBall = fireBallPool.GetObject(firePointPosition, firePoint.rotation);
            // SpriteRenderer의 flipX 상태를 기반으로 발사 방향 설정
        float direction = spriteRenderer.flipX ? -1f : 1f; // flipX가 true면 왼쪽(-1), false면 오른쪽(1)
        Vector2 dir = new Vector2(direction, 0); // x축 방향으로만 발사

        fireBall.Shoot(dir); // 발사체에 방향 전달
        fireBall.SetPool(fireBallPool);
    }

}

