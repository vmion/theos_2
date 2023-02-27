using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickItem : MonoBehaviour
{
    [Header("인벤토리")]
    public Inventory inventory;

    public Canvas canvas;
    GraphicRaycaster grRay;
    PointerEventData _eventData;
    public Image explain;
    void Start()
    {
        grRay = canvas.GetComponent<GraphicRaycaster>();
        _eventData = new PointerEventData(null);
    }
    void Update() 
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            _eventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            grRay.Raycast(_eventData, results);
            RaycastResult hit;
            if (results.Count > 0) 
            {
                hit = results[0];
                HitCheckObject(hit);
            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            explain.gameObject.SetActive(false);
        }        
    }

    void HitCheckObject(RaycastResult hit) {
        IObjectItem clickInterface = hit.gameObject.GetComponent<IObjectItem>();
        Debug.Log(hit.gameObject.transform.position);
        if (clickInterface != null) 
        {
            Item item = clickInterface.ClickItem();
            Debug.Log(item.itemName);
            //inventory.AddItem(item);
            explain.gameObject.SetActive(true);
            explain.transform.position = _eventData.position;
            //explain.sprite를 아이템에 달려있는 sprite로 변경
            //explain의 pivot을 0,1로 변경
            explain.sprite = item.itemExplain;
            explain.color = new Color(1, 1, 1, 0.8f);
        }
    }
}
