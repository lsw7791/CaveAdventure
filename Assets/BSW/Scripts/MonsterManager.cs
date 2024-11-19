using System.Threading;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject GoblinPrefab;  // 몬스터 1 프리팹
    public GameObject zombiePrefab;  // 몬스터 2 프리팹
    public GameObject demonPrefab;  // 몬스터 3 프리팹

    public ObjectPool<Monster> goblinPool;
    public ObjectPool<Monster> zombiePool;
    public ObjectPool<Monster> demonPool;

    void Start()
    {
        Debug.Log("MonsterManager Start() called");
        // 풀 초기화
        if (GoblinPrefab != null)
        {
            goblinPool = new ObjectPool<Monster>();
            goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 12); // 몬스터 풀을 12개로 초기화
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

    // 몬스터 풀에서 꺼내기
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

    // 몬스터를 풀에 반환
    public void ReturnMonster(Monster monster, ObjectPool<Monster> monsterPool)
    {
        monsterPool.ReturnObject(monster);  // 몬스터 풀에 반환
        Debug.Log("Monster returned to pool.");
    }
}