using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();  // 오브젝트를 저장할 큐
    private T prefab;  // 풀링할 오브젝트의 프리팹
    private Transform parent;  // 부모 오브젝트 (옵션 값)

    // 초기화 메서드: 풀 크기만큼 오브젝트를 미리 생성하여 큐에 넣음
    public void Initialize(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;

        // 초기 오브젝트 생성
        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab, parent);  // 오브젝트 생성
            Object.DontDestroyOnLoad(obj.gameObject);  // 씬 변경 시 파괴되지 않도록 설정
            obj.gameObject.SetActive(false);  // 비활성화하여 풀에 추가
            pool.Enqueue(obj);  // 큐에 오브젝트 추가
        }
    }

    // 오브젝트를 풀에서 가져오는 메서드
    public T GetObject(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();  // 풀에서 오브젝트 가져오기
            obj.gameObject.SetActive(true);  // 오브젝트 활성화
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }
        else
        {
            // 풀에 오브젝트가 없으면 새로 생성하여 반환
            T obj = Object.Instantiate(prefab, position, rotation, parent);
            return obj;
        }
    }

    // 오브젝트를 풀로 반환하는 메서드
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);  // 오브젝트 비활성화
        pool.Enqueue(obj);  // 큐에 오브젝트 추가
    }

    // 풀에 있는 모든 오브젝트를 반환하는 메서드
    public IEnumerable<T> GetAllObjects()
    {
        foreach (var item in pool)
        {
            yield return item;
        }
    }
}
