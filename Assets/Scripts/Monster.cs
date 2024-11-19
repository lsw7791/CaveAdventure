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

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void Attack()
    {
    }
}