using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
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

    public float speed = 5.0f;

    void Update()
    {

        float moveHorizontal = Input.GetAxis("JoystickHorizontal");
        float moveVertical = Input.GetAxis("JoystickVertical");

        float moveHorizontalKeyboard = Input.GetAxis("Horizontal");
        float moveVerticalKeyboard = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontalKeyboard, 0.0f, moveVerticalKeyboard);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

