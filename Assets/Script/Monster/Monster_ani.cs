using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ani : MonoBehaviour
{
    Animator Mani;    
    Vector3 nextMove;       
    Vector3 Center;
    Collider playerCollider;
    Collider mobCollider;
    Transform Mob;
    public bool COLLISIONCHECK { get; set; }
    void Awake()
    {
        Mani = GetComponent<Animator>();
        Center = transform.position;
        mobCollider = GetComponent<Collider>();
        Mob = GetComponent<Transform>();
        playerCollider = Character_Manager.playerCollider;
    }
    void Start()
    {        
        Debug.Log(Mob.gameObject.name);
        Debug.Log(playerCollider.name);
        Debug.Log(mobCollider.gameObject.name);
        COLLISIONCHECK = true;
        Invoke("AutoMove", 3f);
    }
    void Update()
    {
        Vector3 MPos = transform.position;
        MPos.x = Mathf.Clamp(MPos.x, Center.x - 8f, Center.x + 8f);
        MPos.z = Mathf.Clamp(MPos.z, Center.z - 8f, Center.z + 8f);
        transform.position = new Vector3(MPos.x, 0f, MPos.z);
        if((MPos.x == Center.x - 8f) || MPos.x == Center.x + 8f)
        {
            Mani.SetBool("isMoving", false);
        }
        else
        {
            Mani.SetBool("isMoving", true);
        }
        if ((MPos.z == Center.z - 8f) || MPos.z == Center.z + 8f)
        {
            Mani.SetBool("isMoving", false);
        }
        else
        {
            Mani.SetBool("isMoving", true);
        }
                   
    }    
    public void AutoMove()
    {        
        nextMove.x = (int)Random.Range(-3f, 3f);        
        nextMove.z = (int)Random.Range(-3f, 3f);
        Vector3 dirMove = new Vector3(nextMove.x, 0f, nextMove.z);
        if (dirMove.magnitude != 0)
        {
            Mani.SetBool("isMoving", true);
            transform.position += dirMove * Time.deltaTime * 1f;            
            if (dirMove != Vector3.zero)
            {
                transform.forward = dirMove.normalized;
            }            
        } 
        else
        {
            Mani.SetBool("isMoving", false);
        }        
        float time = Random.Range(2f, 5f);                
        Invoke("AutoMove", time);
    }    
}
