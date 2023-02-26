using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct MapData
{
    public int index;
    public string name;
    public int parent;
    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;
}
public class ParserManager<T,Q> where T : class, new() where Q : struct
{
    protected List<Q> list;
    private static T inst;
    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
    public ParserManager()
    {
    }
    public void LoadData(string _fileName)
    {
        list = new List<Q>();
        using (StreamReader sr = new StreamReader(_fileName))
        {
            string line = string.Empty;
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] datas = line.Split(',');
                ReadData(datas);
            }
            sr.Close();
        }
    }
    public virtual void ReadData(string[] _datas)
    {

    }
    public void AddData(Q _data)
    {
        list.Add(_data);
    }
}
