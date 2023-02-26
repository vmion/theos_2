using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public bool isGameOver;
    public GameObject player;    
    public Image hp;
    public GameObject over;
    public QuestManager questManager;
    public TalkManager talkManager;    
    public int talkIndex;
    public GameObject talkPanel;
    public Text questTitle;
    public GameObject Menu;    
    
    public void Awake()
    {
        isGameOver = false;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }        
    }
    void Start()
    {
        GameLoad();        
        questTitle.text = questManager.CheckQuest();        
    }
    
    IEnumerator FadeOutStart()
    {
        over.SetActive(true);
        for (float f = 1f; f > 0; f -= 0.2f)
        {
            Color c = over.GetComponent<Image>().color;
            c.a = f;
            over.GetComponent<Image>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        over.SetActive(false);
    }
    IEnumerator FadeInStart()
    {
        over.SetActive(true);
        for (float f = 0f; f < 1; f += 0.45f)
        {
            Color c = over.GetComponent<Image>().color;
            c.a = f;
            over.GetComponent<Image>().color = c;
            yield return null;
        }
    }   
    
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.SetInt("QuestID", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();
        Menu.SetActive(false);
    }
    public void GameLoad()
    {
        if(!PlayerPrefs.HasKey("PlayerX"))
        {
            return;
        }
        float x = PlayerPrefs.GetFloat("PlayerX");
        float z = PlayerPrefs.GetFloat("PlayerZ");
        int questId = PlayerPrefs.GetInt("QuestID");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, 0, z);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;        
    }
    void Update()
    {        
        if(hp.fillAmount == 0)
        {            
            StartCoroutine(FadeInStart());
            Debug.Log("Die");
            isGameOver = true;            
        }        
    }
}
