using UnityEngine;

/// <summary>
/// Class PlayerMovement.
/// 
/// Controls the movement of the player.
/// </summary>
public class PlayerMovement : Movement
{
    public int PlayerId = 1;
    private ControllerMap _controller;
    
    // Movement
    public float Acceleration = 10f;
    public float Deceleration = 2f;
    public float MaxSpeed = 8f;

    private Transform _mainCamera;
    private Quaternion _screenSpace;
    private Vector3 _direction, _moveDirection, _screenForward, _screenRight;

    /// <summary>
    /// Sets up the players variables.
    /// </summary>
    void Start()
    {
        ControllerManager.Controllers.AddController(PlayerId);
        _controller = ControllerManager.Controllers.GetController(PlayerId);
        _mainCamera = Camera.main.transform;
    }

    /// <summary>
    /// Takes the controller's X-axis input to move the player.
    /// It takes into account the camera's position to ensure that the player always moves correctly in accorance to the camera.
    /// </summary>
    void Update()
    {
        // TODO: This moves the player relative to the main camera's postion. It will need to be checked when there are multiple 
        // camera's in the scene and when/if the player can change view (e.g looking behind)
        _screenSpace = Quaternion.Euler(0, _mainCamera.eulerAngles.y, 0);
        _screenForward = _screenSpace * Vector3.forward;
        _screenRight = _screenSpace * Vector3.right;

        var horizontal = _controller.XAxis;
        var vertical = _controller.YAxis;

        _direction = (_screenForward * vertical) + (_screenRight * horizontal);
        _moveDirection = transform.position + _direction;
    }

    /// <summary>
    /// Moves the player and manages its speed.
    /// </summary>
    void FixedUpdate()
    {
        MoveTo(_moveDirection, Acceleration);
        ManageSpeed(Deceleration, MaxSpeed);
    }
}
