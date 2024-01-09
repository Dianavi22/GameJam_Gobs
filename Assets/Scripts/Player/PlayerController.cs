using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 inputValue = new Vector3();
    public InputAction move;
    public PlayerControls inputActions;
    public Vector2 moveDirection;
    public Rigidbody rb;
    public float speed = 5;

    private void Awake()
    {
        inputActions = new PlayerControls();
    }
    private void OnEnable()
    {
        move = inputActions.Gameplay.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
  

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        Vector3 rotate = new Vector3 (moveDirection.x, 0, moveDirection.y);
        Quaternion rotation = Quaternion.LookRotation(rotate, Vector3.up);
        transform.rotation = rotation;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * speed, 0, moveDirection.y  * speed);
    }



}

