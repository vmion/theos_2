using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Marker : MonoBehaviour
{
    public GameObject marker;    

    public float hp = 100f;
    public ParticleSystem particle;
    public GameObject victory;
    void Start()
    {        
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
                victory.SetActive(true);
            }
        }
    }
    void Update()
    {        
        marker.transform.position = new Vector3(transform.position.x, marker.transform.position.y,
            transform.position.z);
        marker.transform.SetParent(gameObject.transform);
    }    
}
