using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;

    [SerializeField] float _speed;
    [SerializeField] float _movementSmoothing = 0.05f;

    private Vector3 _targetVelocity = Vector3.zero;
    private bool _grounded = true;
    void Update()
    {
    }
    //public void Move(Vector2 direction)
    //{
    //    _targetVelocity = new Vector2(direction * _speed, _rb.velocity.y);

    //}
}
