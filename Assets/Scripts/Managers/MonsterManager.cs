using System.Threading;
using UnityEngine;

public class MonsterManager : MonoSingleton<MonsterManager>
{
    public GameObject GoblinPrefab;  // 몬스터 1 프리팹
    public GameObject zombiePrefab;  // 몬스터 2 프리팹
    public GameObject demonPrefab;  // 몬스터 3 프리팹

    public ObjectPool<Monster> goblinPool;
    public ObjectPool<Monster> zombiePool;
    public ObjectPool<Monster> demonPool;

    protected override void Awake()
    {
        base.Awake();  // 필요하면 부모의 Awake 메서드를 호출
        // 리소스에서 프리팹 불러오기
        GoblinPrefab = Resources.Load<GameObject>("Prefab/Goblin");
        zombiePrefab = Resources.Load<GameObject>("Prefab/Zombie");
        demonPrefab = Resources.Load<GameObject>("Prefab/Demon");

        // 풀 초기화
        if (GoblinPrefab != null)
        {
            goblinPool = new ObjectPool<Monster>();
            goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 6);  // 몬스터 풀을 6개로 초기화
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
        // 몬스터를 풀에서 가져오기
        Vector3 spawnPosition = new Vector3(2f, -3f, 0);  // 몬스터를 생성할 위치
        ObjectPool<Monster> selectedPool = goblinPool;  // 생성할 풀 선택

        Monster newMonster = GetMonster(spawnPosition, selectedPool);
    }

    // 몬스터 풀에서 꺼내기
    public Monster GetMonster(Vector3 position, ObjectPool<Monster> monsterPool)
    {
        Monster monster = monsterPool.GetObject(position, Quaternion.identity);
        if (monster != null)
        {
            // 풀에서 가져온 몬스터 초기화
            monster.Initialize(monsterPool);
        }
        else
        {
            Debug.LogError("Failed to spawn monster.");
        }
        return monster;
    }

    // 몬스터를 풀에 반환
    public void ReturnMonster(Monster monster, ObjectPool<Monster> monsterPool)
    {
        monsterPool.ReturnObject(monster);  // 몬스터 풀에 반환
        Debug.Log("Monster returned to pool.");
    }
}