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

    [SerializeField] TextMeshProUGUI isGroundedText;
    [SerializeField] TextMeshProUGUI jumpPressedText;

    float velocityY;
    float inputX;

    CharacterController controller;

    bool jumpPressed;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessMovementHorizontal();
        ProcessMovementVertical();

        isGroundedText.text = IsGrounded().ToString();
        jumpPressedText.text = jumpPressed.ToString();

        Debug.DrawRay(transform.position, Vector3.down * groundDetectionDistance, Color.red);
    }

    private void ProcessMovementHorizontal()
    {
        controller.Move(Vector3.right * inputX * movementForce * Time.deltaTime);
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

    private void ProcessInput()
    {
        inputX= Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            jumpPressed = true;
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundDetectionDistance))
            return true;
        return false;
    }

}
