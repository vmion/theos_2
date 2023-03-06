using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Weapon : MonoBehaviour
{    
    public LayerMask monster;   

    public float maxDamage = 100f;
    public float swordForce = 100f;
    public float swordRange = 3f;

    public static GameObject effect;
    void Start()
    {
        effect = transform.GetChild(0).gameObject;
        effect.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,
            swordRange, monster);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigdbody = colliders[i].GetComponent<Rigidbody>();
            targetRigdbody.AddExplosionForce(swordForce, transform.position,
                swordRange);

            DropItem targetMob = colliders[i].GetComponent<DropItem>();
            float damage = CalculateDamage(colliders[i].transform.position);
            targetMob.TakeDamage(damage);
        }    
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float distance = explosionToTarget.magnitude;
        float edgeToCenterDistance = swordRange - distance;
        float percentage = edgeToCenterDistance / swordRange;
        float damage = percentage * maxDamage;
        //-값을 통해 체력이 회복되는 것을 막기위해
        damage = Mathf.Max(0, damage);
        return damage;
    }
}
