using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();  // ��ü�� ���� ť
    private T prefab;  // Ǯ���� ��ü�� ������
    private Transform parent;  // �θ� ��ü (���� ����)

    // �ʱ�ȭ �� Ǯ ũ�⸸ŭ ��ü�� �̸� �����Ͽ� ť�� �־��
    public void Initialize(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        // �ʱ� ��ü ����
        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab, parent);  // ��ü ����
            obj.gameObject.SetActive(false);  // ��Ȱ��ȭ�Ͽ� Ǯ�� ����
            pool.Enqueue(obj);  // ť�� ��ü �߰�
        }
    }

    // ��ü�� Ǯ���� ������ �޼���
    public T GetObject(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();  // Ǯ���� ��ü ������
            obj.gameObject.SetActive(true);  // ��ü Ȱ��ȭ
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }
        else
        {
            // Ǯ�� ��ü�� ������ ���� �����ؼ� ��ȯ
            T obj = Object.Instantiate(prefab, position, rotation, parent);
            return obj;
        }
    }

    // ��ü�� Ǯ�� ��ȯ�ϴ� �޼���
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);  // ��ü ��Ȱ��ȭ
        pool.Enqueue(obj);  // Ǯ�� ��ü �߰�
    }

    public IEnumerable<T> GetAllObjects()
    {
        foreach (var item in pool)
        {
            yield return item;
        }
    }
}