using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Weapon : MonoBehaviour
{        
    public static GameObject effect;
    void Start()
    {
        effect = transform.GetChild(0).gameObject;        
        effect.SetActive(false);
    }      
}
