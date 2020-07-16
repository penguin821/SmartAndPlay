﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float mouseSensitivity = 200.0f;
    private float moveSpeed = 10.0f;
    private float rotateSpeed = 160.0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ang = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
            animator.SetTrigger("PlayerJump");


        if (ang != 0 || ver != 0)
        {
            float amtMove = moveSpeed * Time.deltaTime;
            float amtRot = rotateSpeed * Time.deltaTime;

            transform.Translate(Vector3.forward * ver * amtMove);
            transform.Rotate(Vector3.up * ang * amtRot);

            animator.SetBool("PlayerRun", true);
        }
        else
            animator.SetBool("PlayerRun", false);

        //if (Input.GetMouseButtonDown(0))
        //    animator.SetTrigger("PlayerAttack");
    }
}