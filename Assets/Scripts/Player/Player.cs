using UnityEngine;

public class Player : MonoBehaviour
{
    public FireBall fireBallPrefab; 
    public Transform firePoint;    
    private ObjectPool<FireBall> fireBallPool;

    private void Start()
    {
        fireBallPool = new ObjectPool<FireBall>();
        fireBallPool.Initialize(fireBallPrefab, 10, transform);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭
        {
            ShootFireBall(false); // 좌클릭 시 왼쪽으로 발사
        }

        if (Input.GetMouseButtonDown(1)) // 마우스 우클릭
        {
            ShootFireBall(true); // 우클릭 시 오른쪽으로 발사
        }
    }

    private void ShootFireBall(bool isRightDirection)
    {
        Vector3 firePointPosition = firePoint.position;

        FireBall fireBall = fireBallPool.GetObject(firePointPosition, firePoint.rotation);
        if (fireBall != null)
        {
            // 발사 방향 설정 (좌클릭 -> 왼쪽, 우클릭 -> 오른쪽)
            Vector2 dir = isRightDirection ? Vector2.right : Vector2.left;
            fireBall.Shoot(dir);

            fireBall.SetPool(fireBallPool);
        }
        else
        {
            Debug.LogWarning("Failed to get FireBall from ObjectPool.");
        }
    }
}
