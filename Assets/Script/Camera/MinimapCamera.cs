using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinimapCamera : MonoBehaviour
{
    public Material minimap;
    public Texture village;
    public Texture forest;
    public Texture laby;
    
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "_01_Village")
        {
            minimap.SetTexture("_MainTex", village);
        }
        if (scene.name == "_02_Forest")
        {
            minimap.SetTexture("_MainTex", forest);
        }
        if (scene.name == "_03_Labyrinth")
        {
            minimap.SetTexture("_MainTex", laby);
        }        
    }
}
