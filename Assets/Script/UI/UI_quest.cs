using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_quest : MonoBehaviour
{
    public GameObject isQuest1;
    public GameObject isQuest2;
    public GameObject ui;
    Renderer[] renQuest1;
    Renderer[] renQuest2;

    void Start()
    {
        renQuest1 = isQuest1.GetComponentsInChildren<Renderer>();
        renQuest2 = isQuest2.GetComponentsInChildren<Renderer>();
    }
    public void QuestOkey()
    {
        ui.SetActive(true);
        if(isQuest1.activeSelf == true)
        {
            for(int i = 0; i < renQuest1.Length; i++)
            {
                renQuest1[i].material.color = Color.gray;
                
            }            
        }
        if(isQuest2.activeSelf == true)
        {
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
