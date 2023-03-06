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
    void Start()
    {        
        //player = Character_Manager.instance.transform.GetChild(0);
        //ani = player.GetComponent<Animator>();
        ani = transform.GetComponent<Animator>();
        GameObject ui = GameObject.Find("UI_default");
        marker = ui.transform.GetChild(6).Find("playerMarker").gameObject;
        minimpaCam = ui.transform.GetChild(6).Find("MiniMapCam").gameObject;
        //gameObject.GetComponent<Char_ani>().enabled = false;
        gameObject.GetComponentInParent<Char_ani>().enabled = false;
        AutoMove();
    }
    void Update()
    {       
        if(target != null)
        {
            //StopCoroutine("AutoMove");            
            float dis = Vector3.Distance(transform.position, target.position);
            if (dis <= 3f)
            {
                transform.LookAt(target);
                Attack();
            }
        }
        else if(target == null)
        {
            UpdateTarget();            
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
        Vector3 half = new Vector3(15f, 0, 15f);
         
        Collider[] cols = Physics.OverlapBox(transform.position, half,
            Quaternion.identity, LayerMask.NameToLayer("Monster"));

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
}
