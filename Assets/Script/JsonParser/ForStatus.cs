using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using UnityEngine.UI;

public class ForStatus : MonoBehaviour
{    
    public Text Str;
    public Text Agi;
    public Text Int;
    public Text Con;    
    
    [Serializable]
    public class Status
    {        
        [SerializeField] public int Str;
        [SerializeField] public int Agi;
        [SerializeField] public int Int;
        [SerializeField] public int Con;        
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
    public Status playerStatus;
    void Start()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Json/statJson");

        JSONNode root = JSON.Parse(txtAsset.text);
        JSONNode JStr = root["STR"];
        JSONNode JAgi = root["AGI"];
        JSONNode JInt = root["INT"];
        JSONNode JCon = root["CON"];

        //Debug.Log(JStr);
        //Debug.Log(JAgi);
        //Debug.Log(JInt);
        //Debug.Log(JCon);

        //리스트에 데이터 저장
        List<Status> statList = new List<Status>();
        playerStatus.Str = JStr;
        playerStatus.Agi = JAgi;
        playerStatus.Int = JInt;
        playerStatus.Con = JCon;
        statList.Add(playerStatus);
        Str.text = "STR : " + playerStatus.Str.ToString();
        Agi.text = "AGI : " + playerStatus.Agi.ToString();
        Int.text = "INT : " + playerStatus.Int.ToString();
        Con.text = "CON : " + playerStatus.Con.ToString();
        //리스트 형식을 Json형식으로 변환
        string jsonDataList = JsonUtility.ToJson(new Serialization<Status>(statList));        

        //Json형식을 리스트형식으로 변환
        List<Status> statListformJson = JsonUtility.FromJson<Serialization<Status>>(jsonDataList).ToList();
        
    }
    void Update()
    {
        
    }
}
