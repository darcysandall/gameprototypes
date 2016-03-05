using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Vector3 _currentSpeed;
    private float _distanceToTarget;

    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 destination, float acceleration, float stopDistance = 0.7f)
    {
        var relativePos = destination - transform.position;

        _distanceToTarget = relativePos.magnitude;
        if (_distanceToTarget > stopDistance)
        {
            _rigidbody.AddForce(relativePos.normalized * acceleration * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    public void ManageSpeed(float deceleration, float maxSpeed)
    {
        _currentSpeed = _rigidbody.velocity;

        if (_currentSpeed.magnitude > 0)
        {
            _rigidbody.AddForce((_currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.AddForce((_currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }

    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
    }
}
