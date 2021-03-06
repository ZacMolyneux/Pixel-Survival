﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2d))]
public class PlayerMovement : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;

    float accelerationTimeAirbourne = .2f;
    float accelerationTimeGrounded = .1f;

    public float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    Vector3 velocity;

    float velocityXSmoothing;

    Controller2d controller;

    void Start()
    {
        controller = GetComponent<Controller2d>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        //CheckMousePos();

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirbourne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    
}
