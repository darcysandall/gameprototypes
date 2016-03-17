using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class RollingMovement : MonoBehaviour
{
    public int PlayerId = 1;
    public float Force = 5;

    private Movement _movement;
    private ControllerMap _controller;

    void Start()
    {
        _movement = GetComponent<Movement>();
        ControllerManager.Controllers.AddController(PlayerId);
        _controller = ControllerManager.Controllers.GetController(PlayerId);
    }

    void Update()
    {
        Debug.Log(_controller.XAxis);
        // If the controller is getting horiontal input then move the player
        if (_controller.XAxis != 0)
        {
            var horizontal = _controller.XAxis * Force;
            _movement.Rigidbody.AddRelativeForce(horizontal, 0, 0, ForceMode.Impulse);
        }
    }
}
