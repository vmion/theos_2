using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Portal : MonoBehaviour
{    
    public GameObject caution;
    public static bool CamX = false;
    Collider ObjCollider;
    Collider Player;
    public bool COLLISIONCHECK { get; set; }
    void Start()
    {
        ObjCollider = GetComponent<Collider>();
        Player = Character_Manager.playerCollider;
        COLLISIONCHECK = true;        
    }
    void Update()
    {        
        if (COLLISIONCHECK)
        {
            if (ObjCollider.bounds.Intersects(Player.bounds))
            {
                caution.SetActive(true);
                CamX = true;                
            }
            else
            {
                caution.SetActive(false);
                CamX = false;
            }
        }        
    }     
}
