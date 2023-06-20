using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickItem : MonoBehaviour
{
    [Header("Inventory")]
    public Inventory inventory;    

    public Canvas canvas;
    GraphicRaycaster grRay;
    PointerEventData _eventData;
    public Image explain;
    public GameObject Equipment;
    public GameObject equipWeapon;
    public GameObject equipObject;
    Equipment equip;
    public Text textWeapon;
    public Text textObject;
    public Text textPoetion;

    public Char_EquipWeapon equipSword;
    public GameObject portion;
    public GameObject portionBack;
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
        if(Input.GetMouseButtonDown(0))
        {
            _eventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            grRay.Raycast(_eventData, results);
            RaycastResult hit;
            if (results.Count > 0)
            {
                hit = results[0];
                HitEquipWeapon(hit);
                HitEquipObject(hit);
                HitPortion(hit);
            }
        }
    }

    void HitCheckObject(RaycastResult hit) 
    {
        IObjectItem clickInterface = hit.gameObject.GetComponent<IObjectItem>();
        
        if (clickInterface != null) 
        {
            Item item = clickInterface.ClickItem();
                       
            explain.gameObject.SetActive(true);
            explain.transform.position = _eventData.position;
            
            explain.sprite = item.itemExplain;
            explain.color = new Color(1, 1, 1, 0.95f);
        }
    }
    void HitEquipWeapon(RaycastResult hit)
    {
        IObjectItem clickInterface = hit.gameObject.GetComponent<IObjectItem>();
       
        if (clickInterface != null)
        {
            Item item = clickInterface.ClickItem();            
            
            if(item.itemType == Item.ItemType.Weapon)
            {
                Equipment.gameObject.SetActive(true);
                
                Image weaponImage = equipWeapon.GetComponent<Image>();
                weaponImage.sprite = item.itemImage;
                
                textWeapon.text = "E";
                equipSword.EquipSword();
            }
        }
    }
    void HitEquipObject(RaycastResult hit)
    {
        IObjectItem clickInterface = hit.gameObject.GetComponent<IObjectItem>();
        
        if (clickInterface != null)
        {
            Item item = clickInterface.ClickItem();
           
            if (item.itemType == Item.ItemType.Object)
            {
                Equipment.gameObject.SetActive(true);
                
                Image ObjectImage = equipObject.GetComponent<Image>();
                ObjectImage.sprite = item.itemImage;
                
                textObject.text = "E";
            }
        }
    }
    void HitPortion(RaycastResult hit)
    {
        IObjectItem clickInterface = hit.gameObject.GetComponent<IObjectItem>();
        
        if (clickInterface != null)
        {
            Item item = clickInterface.ClickItem();
            
            if (item.itemType == Item.ItemType.Used)
            {
                portion.SetActive(true);
                portionBack.SetActive(true);
                textPoetion.text = "E";
            }
        }
    }
}
