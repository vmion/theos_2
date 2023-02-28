using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Inventory : MonoBehaviour
{
    public List<Item> tmpItem;
    public GameObject Inventory;
    public Inventory inventory;
    public List<Item> ItemResoureces;
    
    void Start()
    {
        Item[] tmp = Resources.LoadAll<Item>("Inventroy_Item/");
        for(int i = 0; i < tmp.Length; i++)
        {
            ItemResoureces.Add(tmp[i]);
        }
    }
    public void AddCharItem(Item _item)
    {
        tmpItem.Add(_item);
    }    
    void Update()
    {
        if(Inventory.activeSelf == true)
        {
            foreach(Item one in tmpItem)
            {      
                inventory.AddItem(one);
            }            
            tmpItem.Clear();
        }
    }
}
