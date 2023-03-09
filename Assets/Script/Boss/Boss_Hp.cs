using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Hp : MonoBehaviour
{
    public GameObject Boss;       
    
    public Image hp;
    public Text hpText;
    float hpCount;
    void Start()
    {
        hp.fillAmount = 1f;
        hpText.text = "100%";
        hpCount = Boss.GetComponent<Boss_ani>().hp;
    }
    void Update()
    {
        hpCount = Boss.GetComponent<Boss_ani>().hp;
        hp.fillAmount = hpCount / 100f;
        hpText.text = (hp.fillAmount * 100).ToString() + "%";
    }
}
