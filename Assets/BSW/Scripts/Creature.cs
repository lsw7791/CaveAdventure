using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public string creatureName;
    public int health;
    public int attackPower;
    public float movementSpeed;


    // 기본적인 행동들
    public virtual void Attack()
    {
        Debug.Log(creatureName + " attacks with power: " + attackPower);
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
