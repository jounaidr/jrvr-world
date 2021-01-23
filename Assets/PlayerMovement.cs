﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float SPEED = 12f;
    private const float GRAVITY = -9.81f;
    private const float GROUND_DISTANCE = 0.4f;

    private Vector3 fallVelocity;

    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckSphere(groundCheck.position, GROUND_DISTANCE, groundMask) && fallVelocity.y < 0) // Check if player object is on terrain and still falling
        {
            fallVelocity.y = -2f; // Reset fall velocity
        }

        float playerX = Input.GetAxis("Horizontal"); // X direction movment input from WASD
        float playerZ = Input.GetAxis("Vertical"); // Z direction movement input from WASD

        Vector3 movement = transform.right * playerX + transform.forward * playerZ; // Calc new player pos based on inputs and players current pos
        fallVelocity.y += GRAVITY * Time.deltaTime; // Clac current fall velocity based on gravity acceleration

        characterController.Move(movement * Time.deltaTime * SPEED); // Move player object in X and Z by calculated amount
        characterController.Move(fallVelocity * Time.deltaTime); // Move player object in Y by calculated amount, 0.5g*t^2
        
    }
}
