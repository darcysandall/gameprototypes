using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class SwarmMovement : MonoBehaviour
{
    public GameObject _player;
    public float _acceleration = 40;
    public float _deceleration = 9;
    public float _maxSpeed = 10;

    private Movement _movement;

	void Start ()
	{
	    _movement = GetComponent<Movement>();
	}
	
	void Update ()
    {
        _movement.MoveTo(_player.transform.position, _acceleration);
    }

    void FixedUpdate()
    {
        _movement.ManageSpeed(_deceleration, _maxSpeed);
    }
}
