using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBgm : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip login;
    public AudioClip village;
    public AudioClip forest;
    public AudioClip labyrinth;

    string sceneName;
    Scene nowScene;

    private static ChangeBgm Instance;        

    void Awake()
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
    }
    void Start()
    {
        bgm.loop = true;
    }
    
    void Update()
    {
        nowScene = SceneManager.GetActiveScene();
        sceneName = nowScene.name;
        if (sceneName == "_00_StartScene")
        {
            bgm.clip = login;
            if(bgm.isPlaying)
            {
                return;
            }
            else
            {
                bgm.Play();
            }            
        }
        if (sceneName == "_01_Village")
        {            
            bgm.clip = village;
            if (bgm.isPlaying)
            {
                return;
            }
            else
            {
                bgm.Play();
            }
        }
        else if (sceneName == "_02_Forest")
        {
            bgm.clip = forest;
            if (bgm.isPlaying)
            {
                return;
            }
            else
            {
                bgm.Play();
            }
        }
        else if (sceneName == "_03_Labyrinth")
        {
            bgm.clip = labyrinth;
            if (bgm.isPlaying)
            {
                return;
            }
            else
            {
                bgm.Play();
            }
        }
    }
}
