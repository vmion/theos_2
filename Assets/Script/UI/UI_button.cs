using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_button : MonoBehaviour
{    
    public GameObject ui;    
    public void CloseButton()
    {        
        Time.timeScale = 1f;
        Obj_Portal.CamX = false;
        ui.SetActive(false);
    }
    public void OpenButton()
    {        
        Time.timeScale = 0f;
        Obj_Portal.CamX = true;
        ui.SetActive(true);
    }
    public void CheckPortal_Village()
    {        
        Obj_Portal.CamX = false;
        Time.timeScale = 1f;
        LoadingManager.LoadScene("_01_Village");
        ui.SetActive(false);
    }
    public void CheckPortal_Forest()
    {        
        Obj_Portal.CamX = false;
        Time.timeScale = 1f;
        LoadingManager.LoadScene("_02_Forest");
        ui.SetActive(false);
    }
    public void CheckPortal_Labyrinth()
    {
        
        Obj_Portal.CamX = false;
        Time.timeScale = 1f;
        LoadingManager.LoadScene("_03_Labyrinth");
        ui.SetActive(false);
    }
    public void AutoCombat()
    {
        ui.SetActive(false);
        Time.timeScale = 1f;
        Obj_Portal.CamX = false;
        gameObject.GetComponentInChildren<Char_Auto>().AutoMove();
    }     
}
