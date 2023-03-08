using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Panel : MonoBehaviour
{    
    public Collider NpcCollider;
    public GameObject panel;    
    Collider Player;
    public Text panelName;
    public Obj_Data objData;
    public QuestManager questManager;
    public TalkManager talkManager;    
    public int talkIndex;
    public Text talkText;
    public GameObject questButton;
    //public Text questTitle;
    void Start()
    {        
        Player = Character_Manager.playerCollider;        
        talkIndex = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            panelName.text = " " + NpcCollider.name;
            Talk(objData.id);
        }        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
    void Talk(int id)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);   
        
        //End Talk
        if (talkData == null)
        {
            talkIndex = 0;            
            //questTitle.text = questManager.CheckQuest(id);
            return;
        }
        
        //Continue Talk
        if (objData.isQuest == true || objData.isComplete == true)
        {            
            talkText.text = talkData.Split(":")[0];
            questButton.SetActive(true);
        }
        else
        {
            talkText.text = talkData.Split(":")[0];
            questButton.SetActive(false);
        }
    }
    void Update()
    {
       
    }    
}
