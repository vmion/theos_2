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
        /*
        Debug.Log(txtAsset);
        Debug.Log(title);
        Debug.Log(story);
        Debug.Log(forComplete);
        Debug.Log(rewards);
        */
        //리스트에 데이터 저장

        List<Quest> questList = new List<Quest>();

        //1번째 퀘스트
        //Quest q1 = new Quest();
        q1.title = "빼앗긴 짐을 되찾아라";
        q1.story = "마을주민이 짐을 가지고 숲을 건너오다가 몬스터들에게 짐을 빼앗겼다." +
            "\n\n건네받은 검을 들고 그 짐을 되찾아오자.";
        q1.forComplete = "몬스터를 사냥하고 짐 5개 회수하기";
        q1.rewards = "숲의 반지";
        questList.Add(q1);

        //2번째 퀘스트
        //
        q2.title = "미궁을 돌파하라";
        q2.story = "마을 근처에 생긴 미궁의 보스는 매해 산제물을 요구한다." +
            "\n\n미궁을 돌파하여 보스를 사냥하고 마을사람들에게 안정을 되찾아주자.";
        q2.forComplete = "미노타우루스 사냥";
        q2.rewards = "튜토리얼 종료";
        questList.Add(q2);

        //리스트 형식을 Json형식으로 변환
        string jsonDataList = JsonUtility.ToJson(new Serialization<Quest>(questList));
        //Debug.Log(jsonDataList);

        //Json형식을 리스트형식으로 변환
        List<Quest> questListformJson = JsonUtility.FromJson<Serialization<Quest>>(jsonDataList).ToList();
        /*
        foreach (Quest one in questListformJson)
        {
            Debug.Log(one.title + "\n" + one.story + "\n"
                + one.forComplete + "\n" + one.rewards);
        }    
        */
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