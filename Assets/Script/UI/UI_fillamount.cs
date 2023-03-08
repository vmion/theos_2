using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_fillamount : MonoBehaviour
{
    public Image image;
    public Text text;
    float consume;    
    void Start()
    {
        image.fillAmount = 1;
        consume = 0;
        text.text = "100%";
    }
    
    void Update()
    {
        text.text = (image.fillAmount * 100).ToString() + "%";
        if (consume > 0)
        {
            image.fillAmount -= consume / 10; 
        }
    }
}
