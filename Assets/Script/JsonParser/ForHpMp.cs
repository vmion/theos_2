using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using UnityEngine.UI;

public class ForHpMp : MonoBehaviour
{
    public Text Hp;
    public Text Mp;
    
    [Serializable]
    public class HpMp
    {
        [SerializeField] public int Hp;
        [SerializeField] public int Mp;        
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
    public HpMp playerHpMp;
    void Start()
    {
        TextAsset txtAsset = Resources.Load<TextAsset>("Json/hpmpJson");

        JSONNode root = JSON.Parse(txtAsset.text);
        JSONNode JHp = root["HP"];
        JSONNode JMp = root["MP"];
        
        //Debug.Log(JHp);
        //Debug.Log(JMp);
        
        //����Ʈ�� ������ ����
        List<HpMp> HpMpList = new List<HpMp>();
        playerHpMp.Hp = JHp;
        playerHpMp.Mp = JMp;
        HpMpList.Add(playerHpMp);

        Hp.text = "Max HP : " + playerHpMp.Hp.ToString();
        Mp.text = "Max MP : " + playerHpMp.Mp.ToString();
        
        //����Ʈ ������ Json�������� ��ȯ
        string jsonDataList = JsonUtility.ToJson(new Serialization<HpMp>(HpMpList));

        //Json������ ����Ʈ�������� ��ȯ
        List<HpMp> statListformJson = JsonUtility.FromJson<Serialization<HpMp>>(jsonDataList).ToList();

    }
    void Update()
    {

    }
}
