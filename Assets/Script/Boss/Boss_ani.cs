using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ani : MonoBehaviour
{
    public GameObject marker;
    void Start()
    {
        
    }

    void Update()
    {
        marker.transform.position = new Vector3(transform.position.x, marker.transform.position.y,
            transform.position.z);
    }
}
