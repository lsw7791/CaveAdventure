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

        // 몬스터 배열을 선언합니다.
        Monster[] goblinMonsters = new Monster[5];  // 5개의 Goblin 몬스터 배열
        Monster[] zombieMonsters = new Monster[5];   // 5개의 Zombie 몬스터 배열
        Monster[] demonMonsters = new Monster[5];    // 5개의 Demon 몬스터 배열

    protected override void Awake()
    {
        base.Awake();
        MonsterSet();
    }

    void Start()
    {
        //ObjectPool<Monster> selectedPool = goblinPool;
        //Monster newMonster = GetMonster(new Vector3(2f, -3f, 0), selectedPool);
    }
    private void MonsterSet()
    {
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
    public void Stage1Monster()
    {
        ObjectPool<Monster> selectedPool = goblinPool;
        goblinMonsters[0] = GetMonster(new Vector3(2f, -3f, 0), selectedPool);
        goblinMonsters[1] = GetMonster(new Vector3(12f, -3f, 0), selectedPool);
        goblinMonsters[2] = GetMonster(new Vector3(22f, -3f, 0), selectedPool);
        goblinMonsters[3] = GetMonster(new Vector3(24f, -3f, 0), selectedPool);
    }
    public void Stage2Monster()
    {
        ObjectPool<Monster> selectedPool = goblinPool;
        goblinMonsters[0] = GetMonster(new Vector3(2f, -3f, 0), selectedPool);

    }
    public Monster GetMonster(Vector3 position, ObjectPool<Monster> monsterPool)
    {
        Monster monster = monsterPool.GetObject(position, Quaternion.identity);
        if (monster != null)
        {
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