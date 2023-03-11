using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;    
    //0:elf 1:chief
    
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();        
        GenerateData();
    }

    void GenerateData()
    {
        //��� ���� (obj id, ��ȭ )
        talkData.Add(1000, new string[] { "����Բ��� �����ΰ���?:", });
        talkData.Add(1020, new string[] { "����Բ��� �����ΰ���?:", });
        talkData.Add(1021, new string[] { "����Բ��� �����ΰ���?:", });
        talkData.Add(2000, new string[] { "�츮 ������ ã���ּż� �����մϴ�.:", });
        talkData.Add(2010, new string[] { "�츮 ������ ã���ּż� �����մϴ�.:", });
        talkData.Add(2011, new string[] { "�츮 ������ ã���ּż� �����մϴ�.:", });


        //����Ʈ�� ��ȭ(obj id + quest id + questIndex(������ȣ))
        //����Ʈ�� ��ȭ(obj id + quest id)

        //10�� ����Ʈ 

        talkData.Add(1000 + 10, new string[] { "���۽������� ������ �ʿ��մϴ�." +
            " \n������ ���͸� ����ϰ� ���� ã���ֽðھ�� ?:" });                           
        talkData.Add(1000 + 10 + 1, new string[] { "�����մϴ�! \n�� ������ �����Դϴ�. �޾��ּ���." + 
            "\n����Ե� ���� ����� �ִ� �� ������ �����ðھ��?:"});        
        
        //20�� ����Ʈ
        talkData.Add(2000 + 20, new string[] { "���� �������� ���� ������ϴ�. " +
            "\n�̱��� �̳�Ÿ��罺 ������ ��Ź����� ���������?:" });         
        talkData.Add(2000 + 20 + 1, new string[] { "����� ������ �����Դϴ�.:"});          
    }
    
    public string GetTalk(int id, int talkIndex)
    {
        /*
        //1. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        if (!talkData.ContainsKey(id))
        {
            //�ش� ����Ʈ ��ü�� ��簡 ���� �� -> �⺻ ��縦 �ҷ��� (��, ���� �ڸ� �κ� ���� )
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//GET FIRST TALK

            //
            else
                return GetTalk(id - id % 10, talkIndex);//GET FIRST QUEST TALK
        }
        */
        //2. �ش� ����Ʈ id���� ����Ʈindex(����)�� �ش��ϴ� ��簡 ����
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
        
    }    
}
