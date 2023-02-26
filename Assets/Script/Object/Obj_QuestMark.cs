using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_QuestMark : MonoBehaviour
{
    Transform myTransform;
    void Start()
    {
        myTransform = GetComponent<Transform>();

    }
    void Update()
    {
        transform.Rotate(0, 80 * Time.deltaTime, 0);
    }
}
