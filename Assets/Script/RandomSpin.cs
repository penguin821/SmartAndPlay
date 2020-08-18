using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpin : MonoBehaviour
{
    // 감소증가 증가감소

    float timer;
    int waitingTime;

    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
    }

    void Update()
    {
        transform.Rotate(new Vector3(1f, 0, 0) * Random.Range(80f, 180f) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 1f, 0) * Random.Range(-180f, 0f) * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1f) * Random.Range(-180f, 180f) * Time.deltaTime);
    }
}
