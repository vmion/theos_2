using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName;
   
    public int NpcId;



    public QuestData(string name, int npcid)
    {
        questName = name;
        NpcId = npcid;
    }
}
