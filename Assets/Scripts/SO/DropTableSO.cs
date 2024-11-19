using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTable", menuName = "Monster/DropTableSO", order = 2)]
public class DropTableSO : ScriptableObject
{
    public List<DropItem> dropItems;
}