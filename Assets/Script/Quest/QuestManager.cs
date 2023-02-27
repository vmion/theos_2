using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager Instance;
    public int questId;
    public int questActionIndex;    
    Dictionary<int, QuestData> questList; 
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }    
    void GenerateData()
    {
        questList.Add(10, new QuestData("빼앗긴 짐을 되찾아라", new int[] { 1000, 1000 }));        
        questList.Add(20, new QuestData("미궁을 돌파하라", new int[] { 2000, 2000 }));      
    }
    // Npc Id를 받아 퀘스트 번호를 반환하는 함수 
    public int GetQuestTalkIndex(int id) 
    {
        return questId + questActionIndex;
    }

    public string CheckQuest() //오버로딩 
    {
        //return Quest Name
        return questList[questId].questName;
    }
    
    public string CheckQuest(int id) //npc id
    {

        //Next Talk Target
        //매개변수로 받은 id가 
        if (id == questList[questId].NpdId[questActionIndex])
        {
            questActionIndex++;
        }    
        //Talk complete & Next Quest
        //퀘스트 리스트에 있는 NpcId(퀘스트에 참여하는)
        if (questActionIndex == questList[questId].NpdId.Length)
        {
            NextQuest();
        }            

        //return Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
   
}
