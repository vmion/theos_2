using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

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
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].ITEM = items[i];
            objectItem[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].ITEM = null;
            objectItem[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }
    void Update()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (items[i] = null)
            {
                slots[i].ITEM = null;
                objectItem[i].item = null;
            }            
        }
    }
}
