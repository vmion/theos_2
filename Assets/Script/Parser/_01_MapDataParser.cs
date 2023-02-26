using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class _01_MapDataParser : ParserBase<_01_MapDataParser, MapData>
{
    Dictionary<int, Transform> createdList = new Dictionary<int, Transform>();
    public override void ReadData(string[] _datas)
    {
        GameObject buildingParent = GameObject.Find("MapData");
        if (buildingParent == null)
        {
            buildingParent = new GameObject("MapData");
            buildingParent.transform.localPosition = Vector3.zero;
        }
        int index = int.Parse(_datas[0]);
        string name = _datas[1];
        int parent = int.Parse(_datas[2]);
        Vector3 pos = Vector3.zero;
        pos.x = float.Parse(_datas[3]);
        pos.y = float.Parse(_datas[4]);
        pos.z = float.Parse(_datas[5]);
        Vector3 rot = Vector3.zero;
        rot.x = float.Parse(_datas[6]);
        rot.y = float.Parse(_datas[7]);
        rot.z = float.Parse(_datas[8]);
        Vector3 scale = Vector3.zero;
        scale.x = float.Parse(_datas[9]);
        scale.y = float.Parse(_datas[10]);
        scale.z = float.Parse(_datas[11]);
        int markPos = name.IndexOf('_');
        string rcName = name.Substring(0, markPos);        
        GameObject tmp = Resources.Load<GameObject>("_01_Village_Resources/" + rcName);
        GameObject createObj = GameObject.Instantiate<GameObject>(tmp);
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
    public void ClearMapData()
    {
        createdList.Clear();
    }
}