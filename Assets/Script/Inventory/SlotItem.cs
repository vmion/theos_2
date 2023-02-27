using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotItem : MonoBehaviour
{
    [SerializeField]
    Image image;
    private Item _item;
    public Item ITEM
    {
        get { return _item; }
        set
        {
            _item = value;
            if(_item != null)
            {
                image.sprite = ITEM.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
