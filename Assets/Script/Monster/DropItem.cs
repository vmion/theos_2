using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    //몬스터 죽을때의 파티클
    public ParticleSystem particle;
    public float hp = 10f;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            ParticleSystem instance = Instantiate(particle, transform.position,
                transform.rotation);
            AudioSource deathAudio = instance.GetComponent<AudioSource>();
            deathAudio.Play();

            Destroy(instance.gameObject, instance.main.duration);
            gameObject.SetActive(false);
        }
    }
}
