using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    public GameObject panel;
    public Char_Inventory CharInventory;
    public Item item;
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(item.name);            
            CharInventory.AddCharItem(item);
            panel.SetActive(false);            
            Destroy(gameObject);
        }
    }
}
