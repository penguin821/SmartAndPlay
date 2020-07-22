using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public GameObject Enerugi;
    public Transform PunchPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(Enerugi, PunchPosition.transform.position, PunchPosition.transform.rotation);
    }
}
