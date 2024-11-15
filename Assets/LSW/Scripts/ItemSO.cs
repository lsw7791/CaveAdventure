using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public bool isStackable;
}
