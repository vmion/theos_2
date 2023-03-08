using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_QuestElf : MonoBehaviour
{
    Obj_Data objData;
    public QuestManager questManager;
    void Start()
    {
        objData = GetComponent<Obj_Data>();
        if (questManager.questId == 10)
        {
            objData.isQuest = true;
        }
    }
    void Update()
    {
        
    }
}
