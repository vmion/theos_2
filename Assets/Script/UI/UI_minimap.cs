using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_minimap : MonoBehaviour
{
    Transform Char;
    Transform mapSprite1;
    Transform mapSprite2;
    Transform mapSprite3;
    public RectTransform rcContent;
    public ScrollRect scRect;
    Vector2 normalPos = new Vector2(0.5f, 0.5f);
    string sceneName;
    Scene nowScene;
    void Awake()
    {
        mapSprite1 = scRect.content.GetChild(0);
        mapSprite2 = scRect.content.GetChild(1);
        mapSprite3 = scRect.content.GetChild(2);
    }
    void Start()
    {
        Char = Character_Manager.instance.transform.GetChild(0);
        scRect.normalizedPosition = normalPos;
        
    }
    public void UpdatePos(float fRatiox, float fRatioy)
    {
        normalPos.Set(fRatiox, fRatioy);
        scRect.normalizedPosition = normalPos;
    }
    public void UpdateMonsterPos()
    {

    }
    void Update()
    {
        nowScene = SceneManager.GetActiveScene();
        sceneName = nowScene.name;
        if (sceneName == "_01_Village")
        {
            mapSprite1.gameObject.SetActive(true);
            mapSprite2.gameObject.SetActive(false);
            mapSprite3.gameObject.SetActive(false);
        }        
        else if (sceneName == "_02_Forest")
        {
            mapSprite1.gameObject.SetActive(false);
            mapSprite2.gameObject.SetActive(true);
            mapSprite3.gameObject.SetActive(false);
        }
        else if (sceneName == "_03_Labyrinth")
        {
            mapSprite1.gameObject.SetActive(false);
            mapSprite2.gameObject.SetActive(false);
            mapSprite3.gameObject.SetActive(true);
        }        
    }
}
