using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterManager : MonoBehaviour
{       
    private static MonsterManager Instance;
    public static Dictionary<string, GameObject> mobDic;
    public Transform ParentMonster;
    public static List<Vector3> CenterList;
    public static GameObject mob;
    bool check = true;
    public GameObject[] markers = new GameObject[12];
    public List<GameObject> mobs = new List<GameObject>();
    public static MonsterManager instance
    {
        get
        {
            if (null == Instance)
            {
                return null;
            }
            return Instance;
        }
    }
    void Awake()
    {
        mobDic = new Dictionary<string, GameObject>();
        GameObject[] tmpObjs = Resources.LoadAll<GameObject>("Monsters/");
        mobDic.Add("켄타우로스", tmpObjs[0]);
        mobDic.Add("고르곤", tmpObjs[1]);
        mobDic.Add("사티르", tmpObjs[2]);
        mobDic.Add("아라크네", tmpObjs[3]);
        mobDic.Add("미노타우루스", tmpObjs[4]);
        CenterList = new List<Vector3>();          
    }
    void Start()
    {
        ForestSpawnAll();        
    }
    public Vector3 GetCellCenterPos(int _r, int _c)
    {
        float cellxSize = Spawn_Manager.cellxSize;
        float cellzSize = Spawn_Manager.cellzSize;
        float xStartpos = Spawn_Manager.xStartpos;
        float zStartpos = Spawn_Manager.zStartpos;
        Vector3 pos = Vector3.zero;
        pos.x = xStartpos + (cellxSize * _c) + cellxSize * 0.5f;
        pos.y = 0f;
        pos.z = zStartpos - (cellzSize * _r) - cellzSize * 0.5f;        
        return pos;        
    }
    public void ForestSpawnAll()
    {
        int row = Spawn_Manager.row;
        int column = Spawn_Manager.column;
        int tileIndex = row * column;
        for (int i = 0; i < tileIndex; i++)
        {
            int nR = i / column;
            int nC = i % column;
            Vector3 centerPos = GetCellCenterPos(nR, nC);            
            CenterList.Add(centerPos);
            if (i % 3 == 0)
            {
                mob = Instantiate(mobDic["켄타우로스"], ParentMonster);
                mob.tag = "Monster";
                mob.name = "켄타우로스" + i;
                mob.transform.position = centerPos;                
                mob.AddComponent<Monster_ani>();                
                mobs.Add(mob);
            }
            else if (i % 3 == 1)
            {
                mob = Instantiate(mobDic["고르곤"], ParentMonster);
                mob.tag = "Monster";
                mob.name = "고르곤" + i;
                mob.transform.position = centerPos;                
                mob.AddComponent<Monster_ani>();
                mobs.Add(mob);
            }
            else
            {
                mob = Instantiate(mobDic["사티르"], ParentMonster);
                mob.tag = "Monster";
                mob.name = "사티르" + i;
                mob.transform.position = centerPos;                
                mob.AddComponent<Monster_ani>();
                mobs.Add(mob);
            }            
        }        
    }
    
    void Wait()
    {
        //yield return new WaitForSecondsRealtime(5f);
        check = true;
    }
    void Update()
    {
       if(transform.GetChild(0).gameObject.activeSelf == false)
       {
            Invoke("Wait", 5f);
            transform.GetChild(0).gameObject.SetActive(check);
            check = false;            
       }
       for(int i = 0; i < markers.Length; i++)
       {
            Transform markT = markers[i].gameObject.transform;
            Transform tmpMob = mobs[i].gameObject.transform;            
            markT.position = new Vector3(tmpMob.transform.position.x, markT.position.y,
                tmpMob.transform.position.z);
            markT.SetParent(tmpMob);
        }
    }
}
