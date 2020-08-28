using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(OrbController))]
public class Player : LifeManagement
{
    private float mouseSensitivity = 200.0f;
    private float moveSpeed = 5.0f;
    private float rotateSpeed = 360.0f;

    float gravity = 20.0f;
    float jumpSpeed = 10.0f;

    private Animator animator;
    CharacterController controller;
    Vector3 moveDirection;
    OrbController orbController;

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<CharacterController>();
        orbController = GetComponent<OrbController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BounderyDeath();
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (controller.isGrounded)
        {
            float ang = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            // float amtRot = rotateSpeed * Time.deltaTime;
            // transform.Rotate(Vector3.up * ang * amtRot);

            moveDirection = new Vector3(ang * moveSpeed, 0, ver * moveSpeed);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKey(KeyCode.W))
                animator.SetBool("PlayerRun", true);
            else
                animator.SetBool("PlayerRun", false);

            if (Input.GetKey(KeyCode.A))
                animator.SetBool("PlayerLeftRun", true);
            else
                animator.SetBool("PlayerLeftRun", false);

            if (Input.GetKey(KeyCode.D))
                animator.SetBool("PlayerRightRun", true);
            else
                animator.SetBool("PlayerRightRun", false);

            if (Input.GetKey(KeyCode.S))
                animator.SetBool("PlayerRunBack", true);
            else
                animator.SetBool("PlayerRunBack", false);

            if (Input.GetButtonDown("Jump"))
            {
                if (Input.GetKey(KeyCode.S))
                    animator.SetTrigger("PlayerJumpBack");
                else
                    animator.SetTrigger("PlayerJump");

                moveDirection.y = jumpSpeed;
            }

            if (Input.GetMouseButton(0))
            {
                orbController.OnTriggerHold();
            }
            if (Input.GetMouseButtonUp(0))
            {
                orbController.OnTriggerRelease();
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void BounderyDeath()
    {
        if (transform.position.y < -10f)
            TakeDamage(health);
    }
}