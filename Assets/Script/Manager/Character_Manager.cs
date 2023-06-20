using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Character_Manager : MonoBehaviour
{
    public static Collider playerCollider { get; set; }      
    private static Character_Manager Instance;
    public static Dictionary<string, GameObject> charDic;
    public static Transform ParentPlayer;
    public GameObject SceneName;  
    
    public static Character_Manager instance
    {
        get
        {
            if (null == Instance) 
            {
                return null;
            }
            return Instance;
        }
    }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        ParentPlayer = GameObject.Find("Player").transform;
        charDic = new Dictionary<string, GameObject>();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Character/");
        charDic.Add("플레이어", tmpObjs[0]);        
        SceneManager.sceneLoaded += ChangeSceneEvent;        
    }
    void LogIN()
    {
        if(!GameObject.Find("Character"))
        {
            GameObject player = Instantiate(charDic["플레이어"], ParentPlayer);
            player.tag = "Player";
            player.name = "플레이어";
            player.transform.position = ParentPlayer.transform.position;
        }        
    }
    void ChangeSceneEvent(Scene _scene, LoadSceneMode _mode)
    {               
        if (_scene.name == "_01_Village")
        {            
            instance.transform.position = new Vector3(-15, 0, 0);
            SceneName.SetActive(true);
            Text sceneText = SceneName.GetComponentInChildren<Text>();
            sceneText.text = "Village of Creta";
            Invoke("SceneUIActiveFalse", 2f);
        }
        if (_scene.name == "_02_Forest")
        {
            SceneName.SetActive(true);
            Text sceneText = SceneName.GetComponentInChildren<Text>();
            sceneText.text = "Inner Forest";                       
            Invoke("SceneUIActiveFalse", 2f);
        }
        if (_scene.name == "_03_Labyrinth")
        {
            SceneName.SetActive(true);
            Text sceneText = SceneName.GetComponentInChildren<Text>();
            sceneText.text = "The Labyrinth";            
            Invoke("SceneUIActiveFalse", 2f);
        }        
    }
    void SceneUIActiveFalse()
    {
        GameObject _obj = SceneName;
        if (_obj.activeSelf == true)
        {
            _obj.SetActive(false);
        }        
    }   
    void Start()
    {        
        LogIN();
        playerCollider = Instance.GetComponentInChildren<Collider>();
    }   
}
