using UnityEngine;


[CreateAssetMenu(fileName = "NewMonster", menuName = "Monster/MonsterData", order = 1)]
public class MonsterSO : ScriptableObject
{
    public string monsterName;
    public int maxHealth;
    public int attack;
    public float movementSpeed;
    public float attackSpeed;
    public DropTableSO dropTable;

}