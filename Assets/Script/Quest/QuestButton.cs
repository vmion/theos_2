using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestButton : MonoBehaviour
{
    public GameObject isQuest1;
    public GameObject isQuest2;
    public GameObject isComplete1;
    public GameObject isComplete2;
    public GameObject ui;
    Renderer[] renQuest1;
    Renderer[] renQuest2;
    public GameObject itemBox;

    public QuestManager questManager;
    public Inventory inventory;
    public Char_Inventory charInventory;
    public Item item1;
    public Item item2;
    void Start()
    {
        renQuest1 = isQuest1.GetComponentsInChildren<Renderer>();
        renQuest2 = isQuest2.GetComponentsInChildren<Renderer>();
    }
    public void QuestOkey()
    {
        
        if(isQuest1.activeSelf == true)
        {
            ui.SetActive(true);
            for (int i = 0; i < renQuest1.Length; i++)
            {
                renQuest1[i].material.color = Color.gray;
            }
            itemBox.SetActive(true);
        }
        if(isComplete1.activeSelf == true)
        {            
            questManager.NextQuest();
            inventory.items.Remove(item1);
            inventory.items.Remove(item1);
            inventory.items.Remove(item1);
            inventory.items.Remove(item1);
            inventory.items.Remove(item1);
            charInventory.AddCharItem(item2);
            isComplete1.SetActive(false);
        }
        if(isQuest2.activeSelf == true)
        {
            ui.SetActive(true);
            for (int i = 0; i < renQuest2.Length; i++)
            {
                renQuest2[i].material.color = Color.gray;
            }
        }  
    }
    void Update()
    {
        
    }
}
