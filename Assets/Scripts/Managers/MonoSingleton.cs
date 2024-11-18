using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 싱글턴 인스턴스를 저장할 정적 변수
    private static T _instance;

    // 인스턴스를 가져오는 속성
    public static T Instance
    {
        get
        {
            // 인스턴스가 없으면 찾고, 없다면 새로 생성함
            if (_instance == null)
            {
                // 씬에서 싱글턴 객체를 찾거나, 없으면 새로 생성
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    // 애플리케이션이 종료될 때까지 객체를 유지
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    // 인스턴스를 명시적으로 설정할 수 없도록 private set 사용
    private static void SetInstance(T instance)
    {
        if (_instance != null && _instance != instance)
        {
            Debug.LogError("Another instance of singleton is already assigned!");
            return;
        }
        _instance = instance;
    }

    // 게임 종료 시 인스턴스를 null로 초기화
    private void OnApplicationQuit()
    {
        _instance = null;
    }

    // Awake에서 인스턴스를 설정
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);  // 씬이 변경돼도 객체를 유지
        }
        else if (_instance != this)
        {
            Destroy(gameObject);  // 중복된 인스턴스를 파괴
        }
    }
}
