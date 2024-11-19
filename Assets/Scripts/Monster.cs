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
    private ObjectPool<Monster> monsterPool;  // ���͸� ��ȯ�� Ǯ ����

    // MonsterManager���� �ش� Ǯ�� ������ �� �ֵ��� �߰��ϴ� ������ �Ǵ� �޼���
    public void Initialize(ObjectPool<Monster> pool)
    {
        monsterPool = pool;
    }

    private void Start()
    {
        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();

        // �̵� ���� ���� (����)
        moveDir = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, 0);

        // ���� �ʱ� �ǰ� ����
        health = monsterData.maxHealth;
    }

    void FixedUpdate()
    {
        Move();
        MonsterDrop();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹 �� �̵� ������ �ݴ�� �ٲ�
        moveDir *= new Vector2(-1, 0);
    }

    // �̵�
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
    // ������ �޾��� ��
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // ���Ͱ� ������ Ǯ�� ��ȯ
            ReturnToPool();
        }
    }

    // Ǯ�� ��ȯ�ϴ� �޼���
    private void ReturnToPool()
    {
        if (monsterPool != null)
        {
            gameObject.SetActive(false);  // ��Ȱ��ȭ
            monsterPool.ReturnObject(this);  // Ǯ�� ��ȯ
            Debug.Log("Monster returned to pool.");
        }
    }

    public virtual void Attack()
    {
    }
}