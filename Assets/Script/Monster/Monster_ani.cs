using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_ani : MonoBehaviour
{
    Animator Mani;    
    Vector3 nextMove;       
    Vector3 Center;

    //DropItem dropItem;
    public Char_Inventory CharInventory;
    public Item item;
    public ParticleSystem particle;
    public float hp = 100f;
    void Awake()
    {
        Mani = GetComponent<Animator>();
        Center = transform.position;
        //gameObject.AddComponent<DropItem>();
        CharInventory = Character_Manager.instance.GetComponent<Char_Inventory>();
        item = Resources.Load<Item>("Inventroy_Item/Gem");
        particle = Resources.Load<ParticleSystem>("Particle/Hit_05");
    }
    void Start()
    {    
        Invoke("AutoMove", 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            //dropItem.TakeDamage(100);            
            hp = 0;
            if (hp <= 0)
            {
                CharInventory.AddCharItem(item);
                Vector3 particlePos = new Vector3(0, 1, 0);
                ParticleSystem cloneParticle = Instantiate(particle, transform.position + particlePos,
                    transform.rotation);                

                Destroy(cloneParticle.gameObject, cloneParticle.main.duration);
                gameObject.SetActive(false);
            }
        }
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
