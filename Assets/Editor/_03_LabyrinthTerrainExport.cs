using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class _03_LabyrinthTerrainExport : EditorWindow
{
    [MenuItem("MapData/Export/_03_LabyrinthTerrainExport")]
    public static void ExportData()
    {
        Debug.Log("ExportData");
        string path = Application.dataPath + "/" + "_03_LabyrinthTerrainExport.csv";
        Dictionary<Object, int> TerrainList = new Dictionary<Object, int>();
        using (StreamWriter sr = new StreamWriter(path))
        {
            string lineData = "index,name,parent,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez";
            sr.WriteLine(lineData);
            GameObject[] Terrains = GameObject.FindGameObjectsWithTag("Building");
            for (int i = 0; i < Terrains.Length; i++)
            {
                lineData = string.Empty;
                lineData += (i + 1).ToString();
                lineData += ",";
                lineData += Terrains[i].name;
                lineData += ",";
                if (Terrains[i].transform.parent.name == "MapData")
                    lineData += "-1";
                else
                {
                    lineData += TerrainList[Terrains[i].transform.parent.gameObject].ToString();
                }
                lineData += ",";
                lineData += Terrains[i].transform.localPosition.x;
                lineData += ",";
                lineData += Terrains[i].transform.localPosition.y;
                lineData += ",";
                lineData += Terrains[i].transform.localPosition.z;
                lineData += ",";
                lineData += Terrains[i].transform.eulerAngles.x;
                lineData += ",";
                lineData += Terrains[i].transform.eulerAngles.y;
                lineData += ",";
                lineData += Terrains[i].transform.eulerAngles.z;
                lineData += ",";
                lineData += Terrains[i].transform.localScale.x;
                lineData += ",";
                lineData += Terrains[i].transform.localScale.y;
                lineData += ",";
                lineData += Terrains[i].transform.localScale.z;
                sr.WriteLine(lineData);
                TerrainList.Add(Terrains[i], i + 1);
            }
            sr.Close();
            TerrainList.Clear();
        }
    }
}
