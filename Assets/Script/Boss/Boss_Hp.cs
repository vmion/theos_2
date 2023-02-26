using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Hp : MonoBehaviour
{
    public GameObject Boss;    
    public GameObject bossHP;    
    private void OnBecameVisible()
    {
        bossHP.SetActive(true);
    } 
}
