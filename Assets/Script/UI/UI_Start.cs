using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    public GameObject ui;
    Char_ani Instance;
    UI_Manager instance;    
    public void LoadScene()
    {
        LoadingManager.LoadScene("_01_Village");
    }
    public void ExitGame_UI()
    {
        ui.SetActive(true);
    }
    public void Logout()
    {
        ui.SetActive(false);
        LoadingManager.LoadScene("_00_StartScene");
    }
    public void Check_Exit()
    {
        ui.SetActive(false);
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Á¾·á");
    }
    public void Close_Exit()
    {
        ui.SetActive(false);        
    }    
}
