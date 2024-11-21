//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerManager : MonoBehaviour
//{
//    private static PlayerManager _instance;
//    public static PlayerManager Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                _instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
//            }
//            return _instance;
//            //_instance의 값이 null일 경우 게임 오브젝트로 PlayerManager를 만들어 반환하는 방어 코드
//        }
//    }
//    public Player _player;
//    public Player Player
//    {
//        get { return _player; }
//        set { _player = value; }
//    }
//    public void Awake()
//    {
//        if (_instance == null)
//        {
//            _instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            if (_instance == this)
//            {
//                Destroy(gameObject);
//            }
//        }
//    }
//}
