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

    // Start �޼��忡�� �������� �Ҵ��� �ʿ� ����
    // �����Ϳ��� ���� �����ϱ�

    void Start()
    {
        // Ǯ �ʱ�ȭ
        goblinPool = new ObjectPool<Monster>();
        goblinPool.Initialize(GoblinPrefab.GetComponent<Monster>(), 12); // ���� Ǯ�� 12���� �ʱ�ȭ

        zombiePool = new ObjectPool<Monster>();
        zombiePool.Initialize(zombiePrefab.GetComponent<Monster>(), 12);

        demonPool = new ObjectPool<Monster>();
        demonPool.Initialize(demonPrefab.GetComponent<Monster>(), 12);
    }

    // ���� Ǯ���� ������
    public Monster GetMonster(Vector3 position, Quaternion rotation, ObjectPool<Monster> monsterPool)
    {
        return monsterPool.GetObject(position, rotation);
    }

    // ���͸� Ǯ�� ��ȯ
    public void ReturnMonster(Monster monster, ObjectPool<Monster> monsterPool)
    {
        monsterPool.ReturnObject(monster);  // ���� Ǯ�� ��ȯ
    }
}