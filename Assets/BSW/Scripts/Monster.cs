using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO monsterData;
    public int health;
    public int attackPower;
    public float movementSpeed;


    // �⺻���� �ൿ��
    public virtual void Attack()
    {

    }

    public virtual void Move(Vector3 direction)
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(creatureName + " took damage! Remaining health: " + health);
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
