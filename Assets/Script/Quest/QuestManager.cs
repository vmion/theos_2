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
        questList.Add(10, new QuestData("���ѱ� ���� ��ã�ƶ�", new int[] { 1000, 1000 }));        
        questList.Add(20, new QuestData("�̱��� �����϶�", new int[] { 2000, 2000 }));      
    }
    // Npc Id�� �޾� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ� 
    public int GetQuestTalkIndex(int id) 
    {
        return questId + questActionIndex;
    }

    public string CheckQuest() //�����ε� 
    {
        //return Quest Name
        return questList[questId].questName;
    }
    
    public string CheckQuest(int id) //npc id
    {

        //Next Talk Target
        //�Ű������� ���� id�� 
        if (id == questList[questId].NpdId[questActionIndex])
        {
            questActionIndex++;
        }    
        //Talk complete & Next Quest
        //����Ʈ ����Ʈ�� �ִ� NpcId(����Ʈ�� �����ϴ�)
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
