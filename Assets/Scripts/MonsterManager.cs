using System.Threading;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject GoblinPrefab;  // ���� 1 ������
    public GameObject zombiePrefab;  // ���� 2 ������
    public GameObject demonPrefab;  // ���� 3 ������

    public ObjectPool<Monster> goblinPool;
    public ObjectPool<Monster> zombiePool;
    public ObjectPool<Monster> demonPool;

    void Start()
    {
        Debug.Log("MonsterManager Start() called");
        // Ǯ �ʱ�ȭ
        if (GoblinPrefab != null)
        {
            goblinPool = new ObjectPool<Monster>();
            goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 12); // ���� Ǯ�� 12���� �ʱ�ȭ
            Debug.Log("Goblin Pool Initialized");
        }
        else
        {
            Debug.LogError("GoblinPrefab is not assigned!");
        }

        if (zombiePrefab != null)
        {
            zombiePool = new ObjectPool<Monster>();
            zombiePool.Initialize(zombiePrefab.GetComponent<Monster>(), 12);
            Debug.Log("Zombie Pool Initialized");
        }
        else
        {
            Debug.LogError("ZombiePrefab is not assigned!");
        }

        if (demonPrefab != null)
        {
            demonPool = new ObjectPool<Monster>();
            demonPool.Initialize(demonPrefab.GetComponent<Monster>(), 12);
            Debug.Log("Demon Pool Initialized");
        }
        else
        {
            Debug.LogError("DemonPrefab is not assigned!");
        }
    }

    // ���� Ǯ���� ������
    public Monster GetMonster(Vector3 position, Quaternion rotation, ObjectPool<Monster> monsterPool)
    {
        Monster monster = monsterPool.GetObject(position, rotation);
        if (monster != null)
        {
            Debug.Log("Monster spawned at position: " + position);
        }
        else
        {
            Debug.LogError("Failed to spawn monster.");
        }
        return monster;
    }

    // ���͸� Ǯ�� ��ȯ
    public void ReturnMonster(Monster monster, ObjectPool<Monster> monsterPool)
    {
        monsterPool.ReturnObject(monster);  // ���� Ǯ�� ��ȯ
        Debug.Log("Monster returned to pool.");
    }
}