using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcState : MonoBehaviour
{
    public Obj_Data questState;
    public GameObject objQuest;
    public GameObject objComplete;
    public QuestManager questLevel;    
   
    void Update()
    {        
        if(questState.isQuest == true)
        {
            objQuest.SetActive(true);
        }
        else if(questState.isQuest == false)
        {
            objQuest.SetActive(false);
        }
        if(questState.isComplete == true)
        {
            objComplete.SetActive(true);
            questLevel.questActionIndex = 1;
        }
        else if(questState.isComplete == false)
        {
            objComplete.SetActive(false);
        }       
            
    }
}
