using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        Equipment,
        Used,
        ETC,
    }
    public string itemName;
    public Sprite itemImage;
    public Sprite itemExplain;
    public ItemType itemType;
}
