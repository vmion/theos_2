using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _01_Parser : MonoBehaviour
{
    void Start()
    {
        _01_MapDataParser.instance.LoadData(Application.dataPath + "/" + "_01_VillageTerrainExport.csv");
        _01_MapDataParser.instance.ClearMapData();
    }

    void Update()
    {
        
    }
}
