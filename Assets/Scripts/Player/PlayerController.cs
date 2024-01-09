using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
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
    public void OnMove(InputValue value)
    {
        Debug.Log("Call" + value.Get());
        //inputValue = value.GetType<Vector3>();
        //object a = value.Get();
       

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



    //private PlayerControls controls;
    //private Vector2 moveInput;

    //private void Awake()
    //{
    //    controls = new PlayerControls();
    //    controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
    //    controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
    //}

    //private void OnEnable()
    //{
    //    controls.Gameplay.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.Gameplay.Disable();
    //}

    //private void Update()
    //{
    //    Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
    //    transform.Translate(movement * Time.deltaTime);
    //}




    //public float speed;

    //void Update()
    //{

    //    float moveHorizontal = Input.GetAxis("JoystickHorizontal");
    //    float moveVertical = Input.GetAxis("JoystickVertical");

    //    float moveHorizontalKeyboard = Input.GetAxis("Horizontal");
    //    float moveVerticalKeyboard = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontalKeyboard, 0.0f, moveVerticalKeyboard);
    //    transform.Translate(movement * speed * Time.deltaTime);
    //}
}

