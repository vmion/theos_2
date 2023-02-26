using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class MapLoad : EditorWindow
{
    [MenuItem("MapData/ImportTerrain")]
    public static void ImportData()
    {
        Debug.Log("ImportData");
        Dictionary<int, Transform> createdList = new Dictionary<int, Transform>();
        string fullPath = EditorUtility.OpenFilePanel("ImportMap", Application.dataPath, "csv");
        string fileName = Path.GetFileName(fullPath);
        if (string.IsNullOrEmpty(fullPath))
        {
            Debug.Log("파일 선택을 하지 않았습니다.");
            return;
        }
        GameObject buildingParent = GameObject.Find("MapData");
        if (buildingParent == null)
        {
            //이름을 갖는 빈 오브젝트 생성
            buildingParent = new GameObject("MapData");
            buildingParent.transform.localPosition = Vector3.zero;
        }
        using (StreamReader sr = new StreamReader(fullPath))
        {
            string lineData;
            sr.ReadLine();
            while ((lineData = sr.ReadLine()) != null)
            {
                string[] datas = lineData.Split(",");
                int index = int.Parse(datas[0]);
                string name = datas[1];
                int parent = int.Parse(datas[2]);
                Vector3 pos = Vector3.zero;
                pos.x = float.Parse(datas[3]);
                pos.y = float.Parse(datas[4]);
                pos.z = float.Parse(datas[5]);
                Vector3 rot = Vector3.zero;
                rot.x = float.Parse(datas[6]);
                rot.y = float.Parse(datas[7]);
                rot.z = float.Parse(datas[8]);
                Vector3 scale = Vector3.zero;
                scale.x = float.Parse(datas[9]);
                scale.y = float.Parse(datas[10]);
                scale.z = float.Parse(datas[11]);
                int markPos = name.IndexOf('_');
                string rcName = name.Substring(0, markPos);
                Debug.Log("resource 이름 = " + rcName);
                GameObject tmp = Resources.Load<GameObject>(fileName + "_Resources/" + rcName);
                GameObject createObj = Instantiate<GameObject>(tmp);
                if (parent != -1)
                {
                    createObj.transform.SetParent(createdList[parent]);
                }
                else
                {
                    createObj.transform.SetParent(buildingParent.transform);
                }
                createObj.name = name;
                createObj.transform.localPosition = pos;
                createObj.transform.localEulerAngles = rot;
                createObj.transform.localScale = scale;
                createdList.Add(index, createObj.transform);
            }
            sr.Close();
            createdList.Clear();
        }
    }
}

