using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_joyStick : MonoBehaviour
{
    public Image JoyStick;
    public Image JoyStick_Lever;    
    Vector2 dir;
    Vector2 centerPos;
    float radius;    
    void Start()
    {
        centerPos = JoyStick.transform.position;
        radius = JoyStick.rectTransform.rect.width * 0.5f;              
    }    
    public void OnBeginDrag(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        JoyStick_Lever.transform.position = eventData.position;        
    }
    public void OnDrag(BaseEventData _eventData)
    {        
        PointerEventData eventData = (PointerEventData)_eventData;        
        float distance = Vector2.Distance(centerPos, eventData.position);
        if (distance > radius)
        {
            dir = (Vector2)eventData.position - centerPos;
            JoyStick_Lever.transform.position = centerPos + dir.normalized * radius * 0.5f;            
        }
        else
        {
            JoyStick_Lever.transform.position = eventData.position;
        }        
    }
    public void OnEndDrag(BaseEventData _eventData)
    {
        JoyStick_Lever.transform.position = centerPos;        
    }
    void Update()
    {
    }
}
