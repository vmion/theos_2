using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    //����Ʈ ��
    public string questName;
    // ����Ʈ�� ���õ� NPC id ����
    public int NpcId;


    //������
    //public QuestData(){}

    public QuestData(string name, int npcid)
    {
        questName = name;
        NpcId = npcid;
    }
}
