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
        //�����Ҷ� ������ �߰� -> ������ �߰�    
        Transform[] allChilderen = GetComponentsInChildren<Transform>();
        foreach(Transform one in allChilderen)
        {
            if (one.name == "RIGHT_HAND_COMBAT")
            {
                weaponPath = one;
            }
        }                    
    }
    //���� ������ prefab �߰�
    public void EquipSword()
    {
        nowWeapon = Instantiate(sword, weaponPath);
    }
}
