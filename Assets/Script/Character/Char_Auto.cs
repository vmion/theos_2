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
            
            Vector3 move = enemy.transform.position - transform.position;
            transform.position += move * Time.deltaTime * 0.5f;
            ani.SetBool("isMove", true);
            float dis = Vector3.Distance(transform.position, enemy.transform.position);
            transform.forward = move.normalized;
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
            Debug.Log("Not Monster in this area.");
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
}
