using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBox : MonoBehaviour
{
    public GameObject panel;
    Inventory inventory;
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
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            panel.SetActive(false);
            gameObject.SetActive(false);
            inventory.AddItem(item);
        }
    }
}
