using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Auto : MonoBehaviour
{   
    Animator ani;
    Vector3 nextMove;  
       
    Transform target;
    Transform player;
    Char_ani attack;
        
    GameObject marker;
    GameObject minimpaCam;
    void Start()
    {
        player = Character_Manager.instance.transform.GetChild(0);
        ani = player.GetComponent<Animator>();
        GameObject ui = GameObject.Find("UI_default");
        marker = ui.transform.GetChild(6).Find("playerMarker").gameObject;
        minimpaCam = ui.transform.GetChild(6).Find("MiniMapCam").gameObject;        
    }
    void Update()
    {
        gameObject.GetComponent<Char_ani>().enabled = false;
        UpdateTarget();
        Debug.Log(target.name);
        if(target != null)
        {
            StopCoroutine("AutoMove");
            Vector3 dir = target.position - player.position;
            player.Translate(dir.normalized * 3f * Time.deltaTime);
            float dis = Vector3.Distance(player.position, target.position);
            if (dis <= 3f)
            {
                player.transform.LookAt(target);
                Attack();
            }
        }
        else
        {
            //AutoMove();
            StartCoroutine("AutoMove");
        }

        marker.transform.position = new Vector3(player.transform.position.x, marker.transform.position.y,
            player.transform.position.z);
        marker.transform.forward = -(player.transform.forward);
        minimpaCam.transform.position = new Vector3(player.transform.position.x, minimpaCam.transform.position.y,
            player.transform.position.z);
    }
    public void Attack()
    {
        ani.SetTrigger("Attack");
    }
    //수정 필요
    IEnumerator AutoMove()
    {
        nextMove.x = (int)Random.Range(-3f, 3f);
        nextMove.z = (int)Random.Range(-3f, 3f);
        Vector3 dirMove = new Vector3(nextMove.x, 0f, nextMove.z);
        if (dirMove.magnitude != 0)
        {
            ani.SetBool("isMove", true);
            //player.transform.position += dirMove * Time.deltaTime * 1f;
            player.Translate(dirMove * Time.deltaTime);
            if (dirMove != Vector3.zero)
            {
                player.transform.forward = dirMove.normalized;
            }
        }
        else
        {
            ani.SetBool("isMove", false);
        }
        float time = Random.Range(2f, 5f);
        //Invoke("AutoMove", time);
        yield return new WaitForSeconds(time);
    }
    public void UpdateTarget()
    {
        Vector3 half = new Vector3(15f, 0, 15f);
        Collider[] cols = Physics.OverlapBox(player.transform.position, half, 
            Quaternion.identity, LayerMask.NameToLayer("Monster"));

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.tag == "Monster")
                {
                    if(Vector3.Distance(cols[i].gameObject.transform.position, player.position) <= 15f)
                    {
                        //List<Transform> colL = new List<Transform>();
                        //colL.Add(cols[i].gameObject.transform);
                        target = cols[i].gameObject.transform;
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
