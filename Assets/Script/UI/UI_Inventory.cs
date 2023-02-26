using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image moveIcon;
    public List<UI_InventorySlot> list;
    int selectedSlot;
    string iconName;
    int itemCount;
    void Start()
    {
        itemCount = 1;
    }
    public void OnPointerDown(PointerEventData _eventdata)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IsInRect(_eventdata.position))
            {
                if (list[i].icon.gameObject.activeSelf == true)
                {
                    moveIcon.transform.position = _eventdata.position;
                    iconName = list[i].icon.sprite.name;
                    moveIcon.sprite = Resources.Load<Sprite>(iconName);
                    moveIcon.gameObject.SetActive(true);
                    selectedSlot = i;
                    list[selectedSlot].icon.gameObject.SetActive(false);
                }                
            }
        }
    }
    public void OnPointerUp(PointerEventData _eventdata)
    {
        moveIcon.transform.position = _eventdata.position;
        list[selectedSlot].icon.gameObject.SetActive(true);
        list[selectedSlot].icon.sprite = Resources.Load<Sprite>(iconName);
        moveIcon.sprite = null;
        moveIcon.gameObject.SetActive(false);
    }
    public void OnBeginDrag(PointerEventData _eventdata)
    {
        moveIcon.transform.position = _eventdata.position;
    }
    public void OnDrag(PointerEventData _eventdata)
    {
        moveIcon.transform.position = _eventdata.position;
    }
    public void OnEndDrag(PointerEventData _eventdata)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IsInRect(_eventdata.position))
            {
                if (list[i].icon.gameObject.activeSelf == false)
                {
                    string sprName = list[selectedSlot].icon.sprite.name;
                    list[i].icon.gameObject.SetActive(true);
                    list[i].icon.sprite = Resources.Load<Sprite>(sprName);
                    moveIcon.sprite = null;
                    moveIcon.gameObject.SetActive(false);
                }
                else
                {
                    string from = list[selectedSlot].icon.sprite.name;
                    string to = list[i].icon.sprite.name;
                    list[selectedSlot].icon.sprite = Resources.Load<Sprite>(to);
                    list[i].icon.sprite = Resources.Load<Sprite>(from);
                    moveIcon.sprite = null;
                    moveIcon.gameObject.SetActive(false);
                    if(from == to)
                    {
                        from = null;
                        list[selectedSlot].icon.gameObject.SetActive(false);
                        list[selectedSlot].txt.text = "";
                        itemCount++;
                        list[i].txt.text = itemCount.ToString();
                    }
                }
            }
        }
    }    
    void Update()
    {
    }
}
