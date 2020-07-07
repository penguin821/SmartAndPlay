using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    KeyCode keyPositive;
    [SerializeField]
    KeyCode keyNegative;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(keyPositive))
            GetComponent<Rigidbody>().velocity += v3Force;
        else if (Input.GetKeyDown(keyPositive))
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        if (Input.GetKey(keyNegative))
            GetComponent<Rigidbody>().velocity -= v3Force;
        else if (Input.GetKeyDown(keyNegative))
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
