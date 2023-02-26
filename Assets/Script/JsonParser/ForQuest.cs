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
        //����Ʈ�� ������ ����

        List<Quest> questList = new List<Quest>();

        //1��° ����Ʈ
        //Quest q1 = new Quest();
        q1.title = "���ѱ� ���� ��ã�ƶ�";
        q1.story = "�����ֹ��� ���� ������ ���� �ǳʿ��ٰ� ���͵鿡�� ���� ���Ѱ��." +
            "\n\n�ǳ׹��� ���� ��� �� ���� ��ã�ƿ���.";
        q1.forComplete = "���͸� ����ϰ� �� 5�� ȸ���ϱ�";
        q1.rewards = "���� ����";
        questList.Add(q1);

        //2��° ����Ʈ
        //
        q2.title = "�̱��� �����϶�";
        q2.story = "���� ��ó�� ���� �̱��� ������ ���� �������� �䱸�Ѵ�." +
            "\n\n�̱��� �����Ͽ� ������ ����ϰ� ��������鿡�� ������ ��ã������.";
        q2.forComplete = "�̳�Ÿ��罺 ���";
        q2.rewards = "Ʃ�丮�� ����";
        questList.Add(q2);

        //����Ʈ ������ Json�������� ��ȯ
        string jsonDataList = JsonUtility.ToJson(new Serialization<Quest>(questList));
        //Debug.Log(jsonDataList);

        //Json������ ����Ʈ�������� ��ȯ
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