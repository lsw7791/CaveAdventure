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

    // Start 메서드에서 프리팹을 할당할 필요 없이
    // 에디터에서 직접 연결하기

    void Start()
    {
        // 풀 초기화
        goblinPool = new ObjectPool<Monster>();
        goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 12); // 몬스터 풀을 12개로 초기화

        zombiePool = new ObjectPool<Monster>();
        zombiePool.Initialize(zombiePrefab.GetComponent<Monster>(), 12);

        demonPool = new ObjectPool<Monster>();
        demonPool.Initialize(demonPrefab.GetComponent<Monster>(), 12);
    }

    // 몬스터 풀에서 꺼내기
    public Monster GetMonster(Vector3 position, Quaternion rotation, ObjectPool<Monster> monsterPool)
    {
        return monsterPool.GetObject(position, rotation);
    }

    // 몬스터를 풀에 반환
    public void ReturnMonster(Monster monster, ObjectPool<Monster> monsterPool)
    {
        monsterPool.ReturnObject(monster);  // 몬스터 풀에 반환
    }
}