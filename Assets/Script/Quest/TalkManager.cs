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
        talkData.Add(1000, new string[] { "please go to the mayor.:", });
        talkData.Add(1020, new string[] { "please go to the mayor.:", });
        talkData.Add(1021, new string[] { "please go to the mayor.:", });
        talkData.Add(2000, new string[] { "Welcome to our village.:", });
        talkData.Add(2010, new string[] { "Welcome to our village.:", });
        talkData.Add(2011, new string[] { "Welcome to our village.:", });

        //quest no.10 
        talkData.Add(1000 + 10, new string[] { "We need your help." +
            " \nWill you hunt monsters in the forest and find treasure?:" });                           
        talkData.Add(1000 + 10 + 1, new string[] { "Thanks! \nThis ring is a reward." +
            "\nThe mayor seems to be worried about something. Would you like to go there?:"});        
        
        //quest no.20
        talkData.Add(2000 + 20, new string[] { "I've heard of clearing the forest." +
            "\nIs it okay if I ask you to clear the labyrinth of the Minotaur?:" });         
        talkData.Add(2000 + 20 + 1, new string[] { "You are the town's hero.:" });          
    }
    
    public string GetTalk(int id, int talkIndex)
    {        
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
        
    }    
}
