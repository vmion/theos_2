using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Auto : MonoBehaviour
{   
    Animator ani;
    Vector3 nextMove;    
    Vector3 Center;
    GameObject[] mobs;    
    Transform target;
    Transform player;
    Char_ani attack;
    void Start()
    {
        player = Character_Manager.instance.transform.GetChild(0);
        ani = player.GetComponent<Animator>();
    }
    void Update()
    {
        UpdateTarget();
        if(target != null)
        {            
            Vector3 dir = target.position - player.position;
            player.Translate(dir.normalized * 3f * Time.deltaTime);
            float dis = Vector3.Distance(player.position, target.position);
            if (dis <= 3f)
            {
                attack.Attack();
            }
        }
        else
        {
            gameObject.GetComponent<Char_ani>().enabled = false;
            //AutoMove();
        }
        
    }
    //코드 수정 필요
    public void AutoMove()
    {
        nextMove.x = (int)Random.Range(-3f, 3f);
        nextMove.z = (int)Random.Range(-3f, 3f);
        Vector3 dirMove = new Vector3(nextMove.x, 0f, nextMove.z);
        if (dirMove.magnitude != 0)
        {
            ani.SetBool("isMove", true);
            transform.position += dirMove * Time.deltaTime * 1f;
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
        Vector3 half = new Vector3(3f, 0, 3f);
        Collider[] cols = Physics.OverlapBox(transform.position, half);

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.tag == "Monster")
                {
                    if(Vector3.Distance(cols[i].gameObject.transform.position, player.position) <= 5f)
                    {
                        target = cols[i].gameObject.transform;
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
