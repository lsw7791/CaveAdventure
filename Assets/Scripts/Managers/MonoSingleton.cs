using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // �̱��� �ν��Ͻ��� ������ ���� ����
    private static T _instance;

    // �ν��Ͻ��� �������� �Ӽ�
    public static T Instance
    {
        get
        {
            // �ν��Ͻ��� ������ ã��, ���ٸ� ���� ������
            if (_instance == null)
            {
                // ������ �̱��� ��ü�� ã�ų�, ������ ���� ����
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    // ���ø����̼��� ����� ������ ��ü�� ����
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    // �ν��Ͻ��� ���������� ������ �� ������ private set ���
    private static void SetInstance(T instance)
    {
        if (_instance != null && _instance != instance)
        {
            Debug.LogError("Another instance of singleton is already assigned!");
            return;
        }
        _instance = instance;
    }

    // ���� ���� �� �ν��Ͻ��� null�� �ʱ�ȭ
    private void OnApplicationQuit()
    {
        _instance = null;
    }

    // Awake���� �ν��Ͻ��� ����
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);  // ���� ����ŵ� ��ü�� ����
        }
        else if (_instance != this)
        {
            Destroy(gameObject);  // �ߺ��� �ν��Ͻ��� �ı�
        }
    }
}
