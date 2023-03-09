using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FSM : MonoBehaviour
{    
    Animator ani;
    int hashRun = Animator.StringToHash("isMoving");
    int hashAttack1 = Animator.StringToHash("isAttack1");
    int hashAttack2 = Animator.StringToHash("isAttack2");
    int hashHit = Animator.StringToHash("isHit");

    GameObject parent;
    GameObject player;
    void Start()
    {
        ani = GetComponent<Animator>();
        parent = Character_Manager.instance.gameObject;
        player = parent.transform.GetChild(0).gameObject;
        StartCoroutine(FSM());
        Debug.Log(player.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            ani.SetBool(hashHit, true);
        }
        ani.SetBool(hashHit, false);
    }
    IEnumerator FSM()
    {
        if(player == null)
        {
            ani.SetBool(hashRun, true);
            yield return new WaitForSeconds(3.0f);
            ani.SetBool(hashRun, false);
        }
        
        if(player != null)
        {
            transform.forward = player.transform.position;
            float dis = Vector3.Distance(transform.position, player.transform.position);            
            if(dis > 3f)
            {
                transform.Translate(player.transform.position * Time.deltaTime * 0.5f);
            }
            if(dis <= 3f)
            {
                int result = (int)Random.Range(0, 2f);
                switch(result)
                {
                    case 1:
                        ani.SetBool(hashAttack1, true);
                        yield return new WaitForSeconds(3.0f);
                        ani.SetBool(hashAttack1, false);
                        break;
                    case 2:
                        ani.SetBool(hashAttack2, true);
                        yield return new WaitForSeconds(3.0f);
                        ani.SetBool(hashAttack2, false);
                        break;
                }
            }            
        }  
    }
}
