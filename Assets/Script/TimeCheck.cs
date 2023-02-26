using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    float tmp;
    void Start()
    {
        tmp = 0;
    }

    void Update()
    {
        tmp += Time.deltaTime;
        Debug.Log(tmp + "°æ°úÁß");
    }
}
