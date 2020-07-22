using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public float Time = 2.0f;

    void Start()
    {
        Destroy(gameObject, Time);
    }
}
