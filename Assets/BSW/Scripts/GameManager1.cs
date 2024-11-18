using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class GameManager1 : MonoBehaviour
{
    private MonsterManager monsterManager;
    private void Awake()
    {
        // GameManager에서 MonsterManager를 인스턴스화
        monsterManager = new MonsterManager();
    }
    void Start()
    {

        // 몬스터를 풀에서 꺼내기
        Monster goblin = monsterManager.GetMonster(new Vector3(0, 0, 0), Quaternion.identity, monsterManager.goblinPool);
        goblin.gameObject.SetActive(true);
    }
}