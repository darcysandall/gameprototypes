using UnityEngine;
using System.Collections;

/// <summary>
/// Class Movement.
/// 
/// Common base call to all object that have movement.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    private Vector3 _currentSpeed;
    private float _distanceToTarget;

    /// <summary>
    /// Called on Awake. Sets the rigidbody
    /// </summary>
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Moves the object to the given destination. If the object is less than the stopDistance away from the destination it doesn't move.
    /// </summary>
    /// <param name="destination">Where the object is heading to.</param>
    /// <param name="acceleration">The objects acceleration.</param>
    /// <param name="stopDistance">How close the object needs to be before it stops.</param>
    public void MoveTo(Vector3 destination, float acceleration, float stopDistance = 0.7f)
    {
        var relativePos = destination - transform.position;

        _distanceToTarget = relativePos.magnitude;
        if (_distanceToTarget > stopDistance)
        {
            Rigidbody.AddForce(relativePos.normalized * acceleration * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    /// <summary>
    /// Controls the objects speed.
    /// </summary>
    /// <param name="deceleration">The objects deceleration.</param>
    /// <param name="maxSpeed">The object's max speed.</param>
    public void ManageSpeed(float deceleration, float maxSpeed)
    {
        _currentSpeed = Rigidbody.velocity;

        if (_currentSpeed.magnitude > 0)
        {
            Rigidbody.AddForce((_currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
            if (Rigidbody.velocity.magnitude > maxSpeed)
            {
                Rigidbody.AddForce((_currentSpeed * -1) * deceleration * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
}
