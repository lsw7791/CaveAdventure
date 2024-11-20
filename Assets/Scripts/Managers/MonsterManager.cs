using System.Threading;
using UnityEngine;

public class MonsterManager : MonoSingleton<MonsterManager>
{
    public GameObject GoblinPrefab;
    public GameObject zombiePrefab;
    public GameObject demonPrefab;

    public ObjectPool<Monster> goblinPool;
    public ObjectPool<Monster> zombiePool;
    public ObjectPool<Monster> demonPool;

    protected override void Awake()
    {
        base.Awake();
        GoblinPrefab = Resources.Load<GameObject>("Prefabs/Monsters/Goblin");
        zombiePrefab = Resources.Load<GameObject>("Prefabs/Monsters/Zombie");
        demonPrefab = Resources.Load<GameObject>("Prefabs/Monsters/Demon");

        if (GoblinPrefab != null)
        {
            goblinPool = new ObjectPool<Monster>();
            goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 6);
        }
        if (zombiePrefab != null)
        {
            zombiePool = new ObjectPool<Monster>();
            zombiePool.Initialize(zombiePrefab.GetComponent<Monster>(), 6);
        }
        if (demonPrefab != null)
        {
            demonPool = new ObjectPool<Monster>();
            demonPool.Initialize(demonPrefab.GetComponent<Monster>(), 6);
        }
    }

    void Start()
    {
        // ���͸� Ǯ���� ��������
        Vector3 spawnPosition = new Vector3(2f, -3f, 0);  // ���͸� ������ ��ġ
        ObjectPool<Monster> selectedPool = goblinPool;  // ������ Ǯ ����

        Monster newMonster = GetMonster(spawnPosition, selectedPool);
    }

    // ���� Ǯ���� ������
    public Monster GetMonster(Vector3 position, ObjectPool<Monster> monsterPool)
    {
        Monster monster = monsterPool.GetObject(position, Quaternion.identity);
        if (monster != null)
        {
            // Ǯ���� ������ ���� �ʱ�ȭ
            monster.Initialize(monsterPool);
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