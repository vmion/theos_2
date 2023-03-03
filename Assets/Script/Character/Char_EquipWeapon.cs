using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_EquipWeapon : MonoBehaviour
{
    public GameObject sword;
    Transform weaponPath;
    GameObject swordPrefab;
        
    void Start()
    {
        //시작할때 아이템 추가 -> 장착시 추가
        swordPrefab = Resources.Load<GameObject>("Character/Sword");
        weaponPath = transform.Find("RIGHT_HAND_COMBAT");
        GameObject weapon = Instantiate(swordPrefab, weaponPath.transform);
        weapon.transform.position = new Vector3(0, -2f, 0);
        weapon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    //무기 장착시 prefab 추가
    void Update()
    {
        
    }
}
