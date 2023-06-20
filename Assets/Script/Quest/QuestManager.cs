using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager Instance;
    public int questId;
    public int questActionIndex;    
    Dictionary<int, QuestData> questList;

    public Inventory inventory;
    public Char_Inventory charInventory;
    public List<Item> tmpItem;
    public Item item;
    public GameObject isCompleteMark;
    public GameObject elf;
    bool questCheck;
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
        questCheck = true;
        tmpItem = charInventory.tmpItem;
    }    
    void GenerateData()
    {
        questList.Add(10, new QuestData("Recover the stolen treasure", 1000));        
        questList.Add(20, new QuestData("Minotaur Hunt", 2000));      
    }
     
    public int GetQuestTalkIndex(int id) 
    {
        return questId + questActionIndex;
    }

    public string CheckQuest()  
    {
        
        return questList[questId].questName;
    }
   
    public void isComplete()
    {
        if(questCheck == true)
        {
            isCompleteMark.SetActive(true);            
            elf.GetComponent<Obj_Data>().isQuest = false;
            elf.GetComponent<Obj_Data>().isComplete = true;
        }        
    }
    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
        isCompleteMark.SetActive(false);
        elf.GetComponent<Obj_Data>().isComplete = false;
    }
    void Update()
    {        
        if(inventory.items.Contains(item) || tmpItem.Contains(item))
        {
            int itemCount = inventory.items.Count;
            int distinctCount = inventory.items.Distinct().Count();
            if((itemCount - distinctCount) == 4 || tmpItem.Count >= 5)
            {
                isComplete();
                questCheck = false;                
            }
        }        
    }

}
