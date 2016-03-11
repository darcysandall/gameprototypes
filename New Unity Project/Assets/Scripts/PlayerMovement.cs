using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class PlayerMovement : MonoBehaviour
{
    public int PlayerId = 1;
    // Movement
    public float Acceleration = 10f;
    public float Deceleration = 2f;
    public float MaxSpeed = 8f;

    // Jumping
    public Vector3 JumpForce = new Vector3(0, 50, 0);
    public Collider JumpCollider;

    private Quaternion _screenSpace;
    private Vector3 _direction, _moveDirection, _screenForward, _screenRight;
    private Movement _movement;
    private Transform _mainCamera;
    private bool _grounded = false;
    private ControllerMap _controller;

    void Start()
    {
        ControllerManager.Controllers.AddController(PlayerId);
        _controller = ControllerManager.Controllers.GetController(PlayerId);
        _mainCamera = Camera.main.transform;
        _movement = GetComponent<Movement>();
    }

    void Update()
    {
        _screenSpace = Quaternion.Euler(0, _mainCamera.eulerAngles.y, 0);
        _screenForward = _screenSpace * Vector3.forward;
        _screenRight = _screenSpace * Vector3.right;

        var horizontal = _controller.XAxis;
        var vertical = _controller.YAxis;

        _direction = (_screenForward * vertical) + (_screenRight * horizontal);
        _moveDirection = transform.position + _direction;

        if (_controller.GetButtonDown(ControllerMap.Button.GamepadBottom) &&
            IsGrounded())
        {
            Jump(JumpForce);
        }
    }

    void FixedUpdate()
    {
        _movement.MoveTo(_moveDirection, Acceleration);
        _movement.ManageSpeed(Deceleration, MaxSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = false;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (_direction.magnitude == 0 && _movement.Rigidbody.velocity.magnitude < 2)
        {
            _movement.Rigidbody.velocity = Vector3.zero;
        }
    }

    private bool IsGrounded()
    {
        return _grounded;
    }

    private void Jump(Vector3 jumpVelocity)
    {
        var velocity = _movement.Rigidbody.velocity;
        _movement.Rigidbody.velocity = new Vector3(velocity.x, 0, velocity.z);
        _movement.Rigidbody.AddRelativeForce(jumpVelocity, ForceMode.Impulse);
    }

    private string ConvertControl(string control)
    {
        return String.Format("{0}{1}", control, PlayerId);
    }
}
