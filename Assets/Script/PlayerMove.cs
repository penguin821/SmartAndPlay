using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float mouseSensitivity = 200.0f;
    private float moveSpeed = 5.0f;
    private float rotateSpeed = 160.0f;

    float gravity = 20.0f;
    float jumpSpeed = 10.0f;

    private Animator animator;
    CharacterController controller;
    Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            float ang = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            float amtRot = rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * ang * amtRot);

            moveDirection = new Vector3(0, 0, ver * moveSpeed);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKey(KeyCode.W))
                animator.SetBool("PlayerRun",true);
            else
                animator.SetBool("PlayerRun", false);

            if (Input.GetKey(KeyCode.S))
                animator.SetBool("PlayerRunBack", true);
            else
                animator.SetBool("PlayerRunBack", false);

            if (Input.GetButton("Jump"))
            {
                if (Input.GetKey(KeyCode.W))
                    animator.SetTrigger("PlayerJump");
                else if (Input.GetKey(KeyCode.S))
                    animator.SetTrigger("PlayerJumpBack");

                moveDirection.y = jumpSpeed;
            }

            if (Input.GetMouseButtonDown(0))
                animator.SetTrigger("PlayerPunch");
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}