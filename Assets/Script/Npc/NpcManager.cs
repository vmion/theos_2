using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NpcManager : MonoBehaviour
{
    private static NpcManager Instance;
    public static NpcManager instance;
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
    void Update()
    {        
        
    }
}
