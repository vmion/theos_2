using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscSetActive : MonoBehaviour
{
    public GameObject ui;
    void Update()
    {
        if(ui.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ui.SetActive(false);
            }
        }
    }
}
