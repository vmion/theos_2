using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using UnityEngine.UI;
public class ForQuest : MonoBehaviour
{
    public Text title;
    public Text story;
    public Text forComplete;
    public Text rewards;
    public Image rewardImage;
    public QuestManager questManager;
    string tmp;
    ForQuest quest;
    [Serializable]
    public class Quest
    {
        [SerializeField] public string title;
        [SerializeField] public string story;
        [SerializeField] public string forComplete;
        [SerializeField] public string rewards;
    }
    public class Serialization<T>
    {
        [SerializeField]
        List<T> _t;
        public List<T> ToList() { return _t; }
        public Serialization(List<T> _tmp)
        {
            _t = _tmp;
        }
    }
    public Quest q1 = new Quest();
    public Quest q2 = new Quest();
    void Start()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Json/questJson");
        
        JSONNode root = JSON.Parse(txtAsset.text); 
        JSONNode title = root["Title"];
        JSONNode story = root["Story"];
        JSONNode forComplete = root["forComplete"];
        JSONNode rewards = root["Rewards"];
       

        List<Quest> questList = new List<Quest>();

                
        q1.title = "Recover the stolen treasure";
        q1.story = "Citizen was carrying his luggage across the forest, but his luggage was stolen by monsters." +
            "\n\nPick up the sword you were given and bring back the luggage.";
        q1.forComplete = "Hunt monsters and retrieve 5 luggage";
        q1.rewards = "Beginner's Ring";
        questList.Add(q1);
                
        
        q2.title = "Minotaur Hunt";
        q2.story = "The boss of the labyrinth near the village demands a sacrifice every year." +
            "\n\nBreak through the labyrinth, hunt the boss, and restore stability to the citizens.";
        q2.forComplete = "Minotaur Hunt";
        q2.rewards = "End of tutorial";
        questList.Add(q2);

        //List to Json
        string jsonDataList = JsonUtility.ToJson(new Serialization<Quest>(questList));


        //Json to List
        List<Quest> questListformJson = JsonUtility.FromJson<Serialization<Quest>>(jsonDataList).ToList();
        
    }
    void Update()
    {
        tmp = questManager.CheckQuest();

        if (tmp == q1.title)
        {
            title.text = q1.title;
            story.text = q1.story;
            forComplete.text = q1.forComplete;
            rewards.text = q1.rewards;
        }
        if (tmp == q2.title)
        {
            title.text = q2.title;
            story.text = q2.story;
            forComplete.text = q2.forComplete;
            rewards.text = q2.rewards;
            rewardImage.sprite = null;
        }
    }
}