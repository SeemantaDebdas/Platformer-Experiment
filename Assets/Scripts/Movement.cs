using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float inputX;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }
    private void ProcessMovement()
    {
        rb.AddForce(Vector2.right * inputX);
    }

    private void ProcessInput()
    {
        inputX= Input.GetAxis("Horizontal");
    }

}
