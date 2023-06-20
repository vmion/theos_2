using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectItem : MonoBehaviour, IObjectItem
{
    [Header("Item")]
    public Item item;
    [Header("Item Image")]
    public Image itemImage;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (item != null)
        {
            itemImage.sprite = item.itemImage;
        }        
    }
    public Item ClickItem()
    {
        return this.item;
    } 
}
    
