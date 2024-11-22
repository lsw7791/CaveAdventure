using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill/SkillData", order = 1)]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public int skillDamage;
    public float skillSpeed;
}
