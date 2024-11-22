using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
            }
            return _instance;
            //_instance�� ���� null�� ��� ���� ������Ʈ�� PlayerManager�� ����� ��ȯ�ϴ� ��� �ڵ�
        }
    }
    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance == this)
            {
                Destroy(gameObject);
            }
        }
    }
}
