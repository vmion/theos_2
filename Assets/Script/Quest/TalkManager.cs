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
        //대사 생성 (obj id, 대화 )
        talkData.Add(1000, new string[] { "촌장님께는 아직인가요?:", });
        talkData.Add(1020, new string[] { "촌장님께는 아직인가요?:", });
        talkData.Add(1021, new string[] { "촌장님께는 아직인가요?:", });
        talkData.Add(2000, new string[] { "우리 마을을 찾아주셔서 감사합니다.:", });
        talkData.Add(2010, new string[] { "우리 마을을 찾아주셔서 감사합니다.:", });
        talkData.Add(2011, new string[] { "우리 마을을 찾아주셔서 감사합니다.:", });


        //퀘스트용 대화(obj id + quest id + questIndex(순서번호))
        //퀘스트용 대화(obj id + quest id)

        //10번 퀘스트 

        talkData.Add(1000 + 10, new string[] { "갑작스럽지만 도움이 필요합니다." +
            " \n숲에서 몬스터를 사냥하고 짐을 찾아주시겠어요 ?:" });                           
        talkData.Add(1000 + 10 + 1, new string[] { "감사합니다! \n이 반지는 보답입니다. 받아주세요." + 
            "\n촌장님도 뭔가 고민이 있는 것 같은데 가보시겠어요?:"});        
        
        //20번 퀘스트
        talkData.Add(2000 + 20, new string[] { "숲을 소탕해준 얘기는 들었습니다. " +
            "\n미궁의 미노타우루스 소탕을 부탁드려도 괜찮을까요?:" });         
        talkData.Add(2000 + 20 + 1, new string[] { "당신은 마을의 영웅입니다.:"});          
    }
    
    public string GetTalk(int id, int talkIndex)
    {
        /*
        //1. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 없음
        if (!talkData.ContainsKey(id))
        {
            //해당 퀘스트 자체에 대사가 없을 때 -> 기본 대사를 불러옴 (십, 일의 자리 부분 제거 )
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//GET FIRST TALK

            //
            else
                return GetTalk(id - id % 10, talkIndex);//GET FIRST QUEST TALK
        }
        */
        //2. 해당 퀘스트 id에서 퀘스트index(순서)에 해당하는 대사가 있음
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
        
    }    
}
