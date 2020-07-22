using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enerugi : MonoBehaviour
{
    public float Speed = 0.2f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed);
    }
}
