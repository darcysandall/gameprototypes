using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class PlayerMovement : MonoBehaviour
{
    public float _acceleration = 10f;
    public float _deceleration = 2f;
    public float _maxSpeed = 8f;

    private Quaternion _screenSpace;
    private Vector3 _direction, _moveDirection, _screenForward, _screenRight;
    private Movement _movement;
    private Transform _mainCamera;

    void Start()
    {
        _movement = GetComponent<Movement>();
        _mainCamera = Camera.main.transform;
    }

    void Update()
    {
        _screenSpace = Quaternion.Euler(0, _mainCamera.eulerAngles.y, 0);
        _screenForward = _screenSpace * Vector3.forward;
        _screenRight = _screenSpace * Vector3.right;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _direction = (_screenForward * vertical) + (_screenRight * horizontal);
        _moveDirection = transform.position + _direction;
    }

    void FixedUpdate()
    {
        _movement.MoveTo(_moveDirection, _acceleration);
        _movement.ManageSpeed(_deceleration, _maxSpeed);
    }

    void OnCollisionStay(Collision other)
    {
        if (_direction.magnitude == 0 && _movement.Rigidbody.velocity.magnitude < 2)
        {
            _movement.Rigidbody.velocity = Vector3.zero;
        }
    }
}
