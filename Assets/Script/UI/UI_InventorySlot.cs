using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour
{
    public Image icon;
    public Image slot;
    public Text txt;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    public float XMIN
    {
        get
        {
            xMin = transform.position.x - slot.rectTransform.rect.width * 0.5f;
            return xMin;
        }
    }
    public float XMAX
    {
        get
        {
            xMax = transform.position.x + slot.rectTransform.rect.width * 0.5f;
            return xMax;
        }
    }
    public float YMIN
    {
        get
        {
            yMin = transform.position.y - slot.rectTransform.rect.height * 0.5f;
            return yMin;
        }
    }
    public float YMAX
    {
        get
        {
            yMax = transform.position.y + slot.rectTransform.rect.height * 0.5f;
            return yMax;
        }
    }
    void Start()
    {
        xMin = transform.position.x - slot.rectTransform.rect.width * 0.5f;
        xMax = transform.position.x + slot.rectTransform.rect.width * 0.5f;
        yMin = transform.position.y - slot.rectTransform.rect.height * 0.5f;
        yMax = transform.position.y + slot.rectTransform.rect.height * 0.5f;
    }
    public bool IsInRect(Vector2 pos)
    {
        if (pos.x >= XMIN && pos.x <= XMAX &&
                pos.y >= YMIN && pos.y <= YMAX)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        
    }
}
