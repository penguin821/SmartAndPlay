using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mouseSensitivity = 200.0f;
    public float moveSpeed = 40.0f;
    public float rotateSpeed = 160.0f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ang = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float amtMove = moveSpeed * Time.deltaTime;
        float amtRot = rotateSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * ver * amtMove);
        transform.Rotate(Vector3.up * ang * amtRot);

        animator.SetBool("PlayerRun",true);
    }
}