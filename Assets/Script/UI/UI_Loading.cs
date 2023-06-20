using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct SceneData
{
    public string _name;
    public float xPos;
    public float yPos;
    public float zPos;
}
public class UI_Loading : MonoBehaviour
{
    public Image uiBar;
    public float duration;
    float elapsed;
    List<SceneData> sceneDataList;
    int loadCount;
    private void Awake()
    {
        sceneDataList = new List<SceneData>();
        for(int i = 0; i < 50; i++)
        {
            SceneData tmp = new SceneData();
            tmp._name = string.Empty;
            sceneDataList.Add(tmp);
        }
    }
    void Start()
    {
        elapsed = 0;
        StartCoroutine(LoadSceneData());
    }
    IEnumerator LoadSceneData()
    {
        // Scene Data Load(Based .csv)
        foreach(SceneData one in sceneDataList)
        {
            yield return new WaitForSeconds(0.3f);
            
            loadCount++;
            
        }        
    }
    void Update()
    {
        elapsed = elapsed + Time.deltaTime;
        
        uiBar.fillAmount = ((float)loadCount / (float)sceneDataList.Count);        
    }
}
