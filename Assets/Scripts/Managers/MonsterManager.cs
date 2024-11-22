using UnityEngine;

public class MonsterManager : MonoSingleton<MonsterManager>
{
    [SerializeField] private GameObject GoblinPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject demonPrefab;

    ObjectPool<Monster> goblinPool;
     ObjectPool<Monster> zombiePool;
     ObjectPool<Monster> demonPool;
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
        goblinMonsters[0] = GetMonster(new Vector3(2f, -3.35f, 0), goblinPool);
        goblinMonsters[1] = GetMonster(new Vector3(12f, -3.35f, 0), goblinPool);
        goblinMonsters[2] = GetMonster(new Vector3(22f, -3.35f, 0), goblinPool);
        goblinMonsters[3] = GetMonster(new Vector3(24f, -3.35f, 0), goblinPool);
    }
    public void StageMonsterReturn()
    {
        for(int i=0;i< goblinMonsters.Length; i++)
        {
            if (goblinMonsters[i] != null)
            {
                ReturnMonster(goblinMonsters[i], goblinPool);
            }
            if (zombieMonsters[i] != null)
            {
                ReturnMonster(zombieMonsters[i], zombiePool);
            }
            if (demonMonsters[i] != null)
            {
                ReturnMonster(demonMonsters[i], demonPool);
            }
        }
    }
    public void Stage2Monster()
    {
        goblinMonsters[0] = GetMonster(new Vector3(5f, -3.35f, 0), goblinPool); 
        zombieMonsters[0] = GetMonster(new Vector3(-5f, -2.8f, 0), zombiePool);
        goblinMonsters[1] = GetMonster(new Vector3(-4f, -3.35f, 0), goblinPool);
        demonMonsters[0] = GetMonster(new Vector3(25.5f, -2.8f, 0), demonPool);

        zombieMonsters[1] = GetMonster(new Vector3(-5f, 6.2f, 0), zombiePool);
        goblinMonsters[2] = GetMonster(new Vector3(16f, 3.6f, 0), goblinPool);
        demonMonsters[1] = GetMonster(new Vector3(17f, 5.1f, 0), demonPool);
        goblinMonsters[3] = GetMonster(new Vector3(30f, 3.6f, 0), goblinPool);

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
    }
}