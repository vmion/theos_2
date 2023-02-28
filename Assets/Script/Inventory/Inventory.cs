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

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<SlotItem>();
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
        }
        for (; i < slots.Length; i++)
        {
            slots[i].ITEM = null;
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
            Debug.Log("������ ���� �� �ֽ��ϴ�.");
        }
    }
}
