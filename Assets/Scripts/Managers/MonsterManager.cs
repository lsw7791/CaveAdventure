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
    private void Awake()
    {
        
    }
    void Start()
    {
        // 풀 초기화
        if (GoblinPrefab != null)
        {
            goblinPool = new ObjectPool<Monster>();
            goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 12); // 몬스터 풀을 12개로 초기화
        }
        if (zombiePrefab != null)
        {
            zombiePool = new ObjectPool<Monster>();
            zombiePool.Initialize(zombiePrefab.GetComponent<Monster>(), 12);
            Debug.Log("Zombie Pool Initialized");
        }
        if (demonPrefab != null)
        {
            demonPool = new ObjectPool<Monster>();
            demonPool.Initialize(demonPrefab.GetComponent<Monster>(), 12);
            Debug.Log("Demon Pool Initialized");
        }

    }

    // 몬스터 풀에서 꺼내기
    public Monster GetMonster(Vector3 position, ObjectPool<Monster> monsterPool)
    {
        Monster monster = monsterPool.GetObject(position, Quaternion.identity);
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

    // 몬스터를 풀에 반환
    public void ReturnMonster(Monster monster, ObjectPool<Monster> monsterPool)
    {
        monsterPool.ReturnObject(monster);  // 몬스터 풀에 반환
        Debug.Log("Monster returned to pool.");
    }
}