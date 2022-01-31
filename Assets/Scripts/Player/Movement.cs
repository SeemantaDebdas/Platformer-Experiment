using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementForce;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float groundDetectionDistance;

    float velocityY;
    float inputX;

    CharacterController controller;
    Animator anim;

    int HorizontalFloatParameter = Animator.StringToHash("HorizontalSpeed");
    int VerticalFloatParameter = Animator.StringToHash("VerticalSpeed");
    int IsJumpParameter = Animator.StringToHash("IsJump");
    Vector3 direction;
    bool jumpPressed;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessMovementHorizontal();
        ProcessRotation();
        ProcessMovementVertical();
        ProcessAnimations();


        Debug.DrawRay(transform.position, Vector3.down * groundDetectionDistance, Color.red);
    }

    private void ProcessInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            jumpPressed = true;
    }

    private void ProcessMovementHorizontal()
    {
        direction = Vector3.right * inputX;
        controller.Move(direction * movementForce * Time.deltaTime);
    }

    void ProcessMovementVertical()
    {
        velocityY += gravity * Time.deltaTime;

        if (velocityY < 0 && IsGrounded())
            velocityY = -2f;

        if (jumpPressed)
        {
            jumpPressed = false;
            velocityY = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        controller.Move(Vector3.up * velocityY * Time.deltaTime);
    }

    void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, direction.normalized);
        if(direction.magnitude>0)
            transform.rotation = targetRotation;
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundDetectionDistance))
            return true;
        return false;
    }

    void ProcessAnimations()
    {
        if (inputX != 0)
            anim.SetFloat(HorizontalFloatParameter, movementForce);
        else
            anim.SetFloat(HorizontalFloatParameter, 0);

        anim.SetBool(IsJumpParameter, !IsGrounded());
    }
}
