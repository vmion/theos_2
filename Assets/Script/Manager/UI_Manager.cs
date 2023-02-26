using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{     
    private static UI_Manager Instance;    
    public static UI_Manager instance
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
    }    
}
