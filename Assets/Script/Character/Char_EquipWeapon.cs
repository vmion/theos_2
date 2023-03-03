using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_EquipWeapon : MonoBehaviour
{
    public GameObject sword;    
    Transform weaponPath;
    GameObject nowWeapon;
    void Start()
    {
        //시작할때 아이템 추가 -> 장착시 추가    
        Transform[] allChilderen = GetComponentsInChildren<Transform>();
        foreach(Transform one in allChilderen)
        {
            if (one.name == "RIGHT_HAND_COMBAT")
            {
                weaponPath = one;
            }
        }                    
    }
    //무기 장착시 prefab 추가
    public void EquipSword()
    {
        nowWeapon = Instantiate(sword, weaponPath);
    }
}
