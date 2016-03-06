using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class SwarmMovement : MonoBehaviour
{
    public GameObject Player;
    public float Acceleration = 40;
    public float Deceleration = 9;
    public float MaxSpeed = 10;
    public WatchPlayer WatchPlayer;

    private Movement _movement;

	void Start ()
	{
	    _movement = GetComponent<Movement>();
	}
	
	void Update ()
    {
	    if (WatchPlayer && WatchPlayer.PlayerTransform())
	    {
            _movement.MoveTo(WatchPlayer.PlayerTransform().position, Acceleration, 1);
        }
	    else if (Player)
	    {
            _movement.MoveTo(Player.transform.position, Acceleration, 1);
        }
    }

    void FixedUpdate()
    {
        _movement.ManageSpeed(Deceleration, MaxSpeed);
    }
}
