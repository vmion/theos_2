using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public List<Item> equip;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private SlotItem[] slots;
    [SerializeField]
    private ObjectItem[] objectItem;
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<SlotItem>();
        objectItem = slotParent.GetComponentsInChildren<ObjectItem>();
    }

    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < equip.Count && i < slots.Length; i++)
        {
            slots[i].ITEM = equip[i];
            objectItem[i].item = equip[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].ITEM = null;
            objectItem[i].item = null;
        }
    }

    public void EquipItem(Item _item)
    {
        if (equip.Count < slots.Length)
        {
            equip.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }
    void Update()
    {

    }
}
