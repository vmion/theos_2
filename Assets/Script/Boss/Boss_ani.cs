using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ani : MonoBehaviour
{
    public GameObject marker;
    Animator Mani;
    Vector3 nextMove;
    Vector3 Center;

    public float hp = 100f;
    public ParticleSystem particle;
    void Awake()
    {
        Mani = GetComponent<Animator>();
        Center = transform.position;
    }
    void Start()
    {
        //Invoke("AutoMove", 3f);
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {                    
            hp -= 20f;
            if (hp <= 0)
            {                
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
        /*
        Vector3 MPos = transform.position;
        MPos.x = Mathf.Clamp(MPos.x, Center.x - 5f, Center.x + 5f);
        MPos.z = Mathf.Clamp(MPos.z, Center.z - 5f, Center.z + 5f);
        transform.position = new Vector3(MPos.x, 0f, MPos.z);
        if ((MPos.x == Center.x - 5f) || MPos.x == Center.x + 5f)
        {
            Mani.SetBool("isMoving", false);
        }
        else
        {
            Mani.SetBool("isMoving", true);
        }
        if ((MPos.z == Center.z - 5f) || MPos.z == Center.z + 5f)
        {
            Mani.SetBool("isMoving", false);
        }
        else
        {
            Mani.SetBool("isMoving", true);
        }
        */
        marker.transform.position = new Vector3(transform.position.x, marker.transform.position.y,
            transform.position.z);
        marker.transform.SetParent(gameObject.transform);
    }
    /*
    public void AutoMove()
    {
        nextMove.x = (int)Random.Range(-1.5f, 1.5f);
        nextMove.z = (int)Random.Range(-1.5f, 1.5f);
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
    */
}
