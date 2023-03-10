using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject credit;
    public GameObject ui;
    public void Clear()
    {
        ui.SetActive(false);
        credit.SetActive(true);
    }
    public void End()
    {
        Application.Quit();
    }
}
