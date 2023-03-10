using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FSM : MonoBehaviour
{    
    Animator ani;    
        
    Transform player;
    Vector3 forPlayer;
    public List<GameObject> playerPos;
    int result;    
    float dis;
    void Start()
    {
        ani = GetComponent<Animator>();
        playerPos = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        player = playerPos[1].transform;  
    }
    
    void Update()
    {        
        forPlayer = player.position - transform.position;
        transform.forward = forPlayer.normalized;
        dis = Vector3.Distance(transform.position, player.position);
        result = Random.Range(0, 2);
        if (dis > 4f)
        {
            ani.SetBool("isMoving", true);
            transform.position += new Vector3(forPlayer.normalized.x * Time.deltaTime * 1.5f, 0f,
                forPlayer.normalized.z * Time.deltaTime * 1.5f);
            
        }
        if (dis <= 4f)
        {
            ani.SetBool("isMoving", false);

            if(ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                if (result == 0)
                {
                    ani.SetTrigger("isAttack1_");

                }
                else if (result == 1)
                {
                    ani.SetTrigger("isAttack2_");

                }
            }            
        }
    }    
    IEnumerator RandomInt(int a, int b)
    {
        int randomResult = Random.Range(a, b);
        result = randomResult;
        yield return new WaitForSeconds(5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            ani.SetBool("isMoving", false);
            ani.ResetTrigger("isAttack1_");
            ani.ResetTrigger("isAttack2_");
            ani.SetTrigger("isHit_");         
        }        
    }    
    IEnumerator Move()
    {    
        if(dis > 4f)
        {
            ani.SetBool("isMoving", true);
            transform.position += new Vector3(forPlayer.normalized.x * Time.deltaTime * 1.5f, 0f,
                forPlayer.normalized.z * Time.deltaTime * 1.5f);

            yield return null;
        }        
    }    
    IEnumerator Attack()
    {      
        if(dis <= 4f)
        {
            ani.SetBool("isMoving", false);          
            
            Debug.Log(result);
            
            if (result == 0)
            {
                ani.SetTrigger("isAttack1_");
                yield return new WaitForSecondsRealtime(3f);               
            }
            else if (result == 1)
            {
                ani.SetTrigger("isAttack2_");
                yield return new WaitForSecondsRealtime(3f);                
            }
        }        
    }
}
