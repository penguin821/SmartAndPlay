using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpDown : MonoBehaviour
{
    float gravity = -20.0f;
    float jumpSpeed =10.0f;
    Vector3 velocity;
    Animator animator;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.position.y;
        if (y < 0f)
            gameObject.transform.position = new Vector3(0, 0f, 0);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("PlayerJump");
                velocity.y = jumpSpeed;
            }
        }

        velocity.y += (gravity * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
