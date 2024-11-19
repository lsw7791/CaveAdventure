using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterData;
    public int health;
    Vector2 moveDir;
    private Rigidbody2D rb;
    private Animator animator;
    private ObjectPool<Monster> monsterPool;  // 몬스터를 반환할 풀 참조

    // MonsterManager에서 해당 풀을 설정할 수 있도록 추가하는 생성자 또는 메서드
    public void Initialize(ObjectPool<Monster> pool)
    {
        monsterPool = pool;
    }

    private void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();

        // 이동 방향 설정 (랜덤)
        moveDir = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, 0);

        // 몬스터 초기 건강 설정
        health = monsterData.maxHealth;
    }

    void FixedUpdate()
    {
        Move();
        MonsterDrop();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌 시 이동 방향을 반대로 바꿈
        moveDir *= new Vector2(-1, 0);
    }

    // 이동
    public virtual void Move()
    {
        rb.velocity = moveDir * monsterData.movementSpeed;
    }
    void MonsterDrop()
    {
        if(gameObject.transform.position.y<-10)
        {
            ReturnToPool();
        }
    }
    // 데미지 받았을 때
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // 몬스터가 죽으면 풀로 반환
            ReturnToPool();
        }
    }

    // 풀로 반환하는 메서드
    private void ReturnToPool()
    {
        if (monsterPool != null)
        {
            gameObject.SetActive(false);  // 비활성화
            monsterPool.ReturnObject(this);  // 풀로 반환
            Debug.Log("Monster returned to pool.");
        }
    }

    public virtual void Attack()
    {
    }
}