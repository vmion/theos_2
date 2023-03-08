using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    //퀘스트 명
    public string questName;
    // 퀘스트에 관련된 NPC id 모음
    public int NpcId;


    //생성자
    //public QuestData(){}

    public QuestData(string name, int npcid)
    {
        questName = name;
        NpcId = npcid;
    }
}
