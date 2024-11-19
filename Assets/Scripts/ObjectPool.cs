using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();  // 객체를 담을 큐
    private T prefab;  // 풀링할 객체의 프리팹
    private Transform parent;  // 부모 객체 (선택 사항)

    // 초기화 시 풀 크기만큼 객체를 미리 생성하여 큐에 넣어둠
    public void Initialize(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        // 초기 객체 생성
        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab, parent);  // 객체 생성
            obj.gameObject.SetActive(false);  // 비활성화하여 풀에 넣음
            pool.Enqueue(obj);  // 큐에 객체 추가
        }
    }

    // 객체를 풀에서 꺼내는 메서드
    public T GetObject(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();  // 풀에서 객체 꺼내기
            obj.gameObject.SetActive(true);  // 객체 활성화
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }
        else
        {
            // 풀에 객체가 없으면 새로 생성해서 반환
            T obj = Object.Instantiate(prefab, position, rotation, parent);
            return obj;
        }
    }

    // 객체를 풀에 반환하는 메서드
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);  // 객체 비활성화
        pool.Enqueue(obj);  // 풀에 객체 추가
    }
}