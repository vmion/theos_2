using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Auto : MonoBehaviour
{   
    Animator ani;     
       
    Transform target;
    Transform player;
    Char_ani attack;        

    GameObject marker;
    GameObject minimpaCam;

    public List<GameObject> mobList;
    GameObject enemy;
    string TagName;
    float shortDis;
    
    void Start()
    {      
        ani = transform.GetComponentInChildren<Animator>();
        GameObject ui = GameObject.Find("UI_default");
        marker = ui.transform.GetChild(6).Find("playerMarker").gameObject;
        minimpaCam = ui.transform.GetChild(6).Find("MiniMapCam").gameObject;        
        gameObject.GetComponent<Char_ani>().enabled = false;

        TagName = "Monster";
        mobList = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
        shortDis = Vector3.Distance(gameObject.transform.position, mobList[0].transform.position);
        enemy = mobList[0];
        GetEnemy();        
    }
    void Update()
    {       
        if(enemy.activeSelf == true)
        {
            //transform.Translate(enemy.transform.position * Time.deltaTime * 0.05f);
            Vector3 move = enemy.transform.position - transform.position;
            transform.position += move * Time.deltaTime * 0.5f;
            ani.SetBool("isMove", true);
            float dis = Vector3.Distance(transform.position, enemy.transform.position);
            transform.forward = enemy.transform.position;
            if (dis <= 2f)
            {
                transform.LookAt(enemy.transform);
                Attack();
            }
        }
        
        else if(enemy.activeSelf == false)
        {
            mobList.Remove(enemy);
            enemy = mobList[0];
            GetEnemy();
        }

        if(mobList == null)
        {
            Debug.Log("주위에 몬스터가 없습니다.");
        }

        marker.transform.position = new Vector3(transform.position.x, marker.transform.position.y,
            transform.position.z);
        marker.transform.forward = -(transform.forward);
        minimpaCam.transform.position = new Vector3(transform.position.x, minimpaCam.transform.position.y,
            transform.position.z);
    }
    public void Attack()
    {
        ani.SetTrigger("Attack");        
    }
    public void GetEnemy()
    {        
        foreach (GameObject one in mobList)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, one.transform.position);
            if (Distance < shortDis)
            {
                enemy = one;
                shortDis = Distance;
            }
        }
        Debug.Log(enemy.name);
    }
    /*
    public void AutoMove()
    {
        Vector3 nextMove;
        nextMove.x = (int)Random.Range(-3f, 3f);
        nextMove.z = (int)Random.Range(-3f, 3f);
        Vector3 dirMove = new Vector3(nextMove.x, 0f, nextMove.z);
        if (dirMove.magnitude != 0)
        {
            ani.SetBool("isMove", true);
            //transform.position += dirMove * Time.deltaTime * 1f;
            
            transform.Translate(dirMove * Time.deltaTime);
            
            if (dirMove != Vector3.zero)
            {
                transform.forward = dirMove.normalized;
            }
        }
        else
        {
            ani.SetBool("isMove", false);
        }
        float time = Random.Range(2f, 5f);
        Invoke("AutoMove", time);
        
    }
    public void UpdateTarget()
    {
        Vector3 half = new Vector3(30f, 0, 30f);
         
        Collider[] cols = Physics.OverlapBox(transform.position, half,
            Quaternion.identity, LayerMask.NameToLayer("Monster"));
        foreach(Collider one in cols)
        {
            Debug.Log(one.gameObject.name);
        }
        
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.tag == "Monster")
                {
                    if(Vector3.Distance(cols[i].gameObject.transform.position, transform.position) <= 15f)
                    {                        
                        target = cols[i].gameObject.transform;
                        Debug.Log(target.name);
                        if(target == null)
                        {
                            UpdateTarget();
                        }
                    }                    
                }
            }
        }
        else
        {
            target = null;
        }       
    }
    */
}
