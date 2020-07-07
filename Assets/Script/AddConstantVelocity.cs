using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddConstantVelocity : MonoBehaviour
{
    [SerializeField]
    KeyCode goUp;
    [SerializeField]
    KeyCode goDown;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(goUp))
            GetComponent<Rigidbody>().velocity += new Vector3(0, 0.5f, 0);
        if (Input.GetKeyDown(goDown))
            GetComponent<Rigidbody>().velocity -= new Vector3(0, 0.5f, 0);
    }
}
