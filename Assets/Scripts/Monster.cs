using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterData;
    public int health;
    Vector2 moveDir;
    private Rigidbody2D rb;
    private ObjectPool<Monster> monsterPool;  // ���͸� ��ȯ�� Ǯ ����
    public UIHeart uiHeart;

    // MonsterManager���� �ش� Ǯ�� ������ �� �ֵ��� �߰��ϴ� ������ �Ǵ� �޼���
    public void Initialize(ObjectPool<Monster> pool)
    {
        monsterPool = pool;
    }

    private void Start()
    {
        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();

        uiHeart = GetComponent<UIHeart>();

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        moveDir *= new Vector2(-1, 0);

        if (other.CompareTag("Player"))
        {
            uiHeart.Loss();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
            DropRandomItem();
            ReturnToPool();
        }
    }

    // Ǯ�� ��ȯ�ϴ� �޼���
    private void ReturnToPool()
    {
        if (monsterPool != null)
        {
            health = monsterData.maxHealth;
            gameObject.SetActive(false);  // ��Ȱ��ȭ
            monsterPool.ReturnObject(this);  // Ǯ�� ��ȯ
        }
    }

    private void DropRandomItem()
    {
        // dropTable이 null이거나 dropItems가 비어 있으면 바로 리턴
        if (monsterData.dropTable == null || monsterData.dropTable.dropItems.Count == 0)
            return;

        float randomValue = Random.Range(0f, 1f);
        float cumulativeProbability = 0f;

        foreach (var dropItem in monsterData.dropTable.dropItems)
        {
            cumulativeProbability += dropItem.dropRate;

            // 랜덤 값이 cumulativeProbability 이하일 때 드랍
            if (randomValue <= cumulativeProbability)
            {
                int dropCount = Random.Range(dropItem.minAmount, dropItem.maxAmount + 1);

                for (int i = 0; i < dropCount; i++)
                {
                    GameObject prefabToDrop = dropItem.GetRandomPrefab();

                    // 아이템이 존재할 경우
                    if (prefabToDrop != null)
                    {
                        // 드랍 포지션 수정: y는 0.5 위로 고정
                        Vector3 dropPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0.5f, 0f);
                        Instantiate(prefabToDrop, dropPosition, Quaternion.identity);
                    }
                }
                return; // 하나의 DropItem만 드랍
            }
        }
    }



}