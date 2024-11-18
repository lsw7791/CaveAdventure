using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class GameManager1 : MonoBehaviour
{
    private MonsterManager monsterManager;
    private void Awake()
    {
        // GameManager���� MonsterManager�� �ν��Ͻ�ȭ
        monsterManager = new MonsterManager();
    }
    void Start()
    {

        // ���͸� Ǯ���� ������
        Monster goblin = monsterManager.GetMonster(new Vector3(0, 0, 0), Quaternion.identity, monsterManager.goblinPool);
        goblin.gameObject.SetActive(true);
    }
}