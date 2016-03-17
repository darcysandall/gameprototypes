using UnityEngine;

/// <summary>
/// Class KeyboardMap.
/// 
/// Provides backup keyboard input.
/// </summary>
public class KeyboardMap : ControllerMap
{
    private readonly KeyCode _gamepadBottom;
    private readonly KeyCode _gamepadRight;
    private readonly KeyCode _gamepadLeft;
    private readonly KeyCode _gamepadTop;
    private readonly KeyCode _leftBumper;
    private readonly KeyCode _rightBumper;
    private readonly KeyCode _start;
    private readonly KeyCode _options;
    private readonly KeyCode _left;
    private readonly KeyCode _right;
    private readonly KeyCode _up;
    private readonly KeyCode _down;

    /// <summary>
    /// Constructs a ControllerMap
    /// 
    /// Sets all of the KeyCodes accoring to the player ID for the backup keyboard codes.
    /// </summary>
    /// <param name="playerId">The player ID from 1 to 4.</param>
    public KeyboardMap(int playerId) : base(playerId)
    {
        switch (playerId)
        {
            case 1:
                _gamepadBottom = KeyCode.Space;
                _gamepadRight = KeyCode.Q;
                _gamepadLeft = KeyCode.E;
                _gamepadTop = KeyCode.Z;
                _leftBumper = KeyCode.X;
                _rightBumper = KeyCode.C;
                _options = KeyCode.Alpha1;
                _start = KeyCode.Alpha2;
                _left = KeyCode.A;
                _right = KeyCode.D;
                _up = KeyCode.W;
                _down = KeyCode.S;
                break;
            case 2:
                _gamepadBottom = KeyCode.Alpha6;
                _gamepadRight = KeyCode.R;
                _gamepadLeft = KeyCode.Y;
                _gamepadTop = KeyCode.V;
                _leftBumper = KeyCode.B;
                _rightBumper = KeyCode.N;
                _options = KeyCode.Alpha4;
                _start = KeyCode.Alpha5;
                _left = KeyCode.F;
                _right = KeyCode.H;
                _up = KeyCode.T;
                _down = KeyCode.G;
                break;
            case 3:
                _gamepadBottom = KeyCode.C;
                _gamepadRight = KeyCode.Y;
                _gamepadLeft = KeyCode.I;
                _gamepadTop = KeyCode.N;
                _leftBumper = KeyCode.M;
                _rightBumper = KeyCode.Comma;
                _options = KeyCode.Alpha7;
                _start = KeyCode.Alpha8;
                _left = KeyCode.H;
                _right = KeyCode.K;
                _up = KeyCode.U;
                _down = KeyCode.J;
                break;
            case 4:
                _gamepadBottom = KeyCode.Z;
                _gamepadRight = KeyCode.O;
                _gamepadLeft = KeyCode.P;
                _gamepadTop = KeyCode.L;
                _leftBumper = KeyCode.Colon;
                _rightBumper = KeyCode.Question;
                _options = KeyCode.LeftBracket;
                _start = KeyCode.RightBracket;
                _left = KeyCode.LeftArrow;
                _right = KeyCode.RightArrow;
                _up = KeyCode.UpArrow;
                _down = KeyCode.DownArrow;
                break;
            default:
                Debug.LogError("The player ID can only be from 1 to 4.");
                break;
        }
    }

    /// <summary>
    /// Gets the X Axis from the keyboard.
    /// </summary>
    public override float XAxis
    {
        get
        {
            if (Input.GetKey(_left)) return -1;
            if (Input.GetKey(_right)) return 1;
            return base.XAxis;
        }
    }

    /// <summary>
    /// Gets the Y Axis from the keyboard.
    /// </summary>
    public override float YAxis
    {
        get
        {
            if (Input.GetKey(_down)) return -1;
            if (Input.GetKey(_up)) return 1;
            return base.YAxis;
        }
    }

    /// <summary>
    /// Gets the left trigger axis from left key on the keyboard.
    /// </summary>
    public override float LeftTrigger
    {
        get { return Input.GetKey(_left) ? 1 : base.LeftTrigger; }
    }

    /// <summary>
    /// Gets the right trigger axis from the right key on the keyboard.
    /// </summary>
    public override float RightTrigger
    {
        get { return Input.GetKey(_right) ? 1 : base.RightTrigger; }
    }

    /// <summary>
    /// Checks if the given button is held down.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button was pressed, false if not.</returns>
    public override bool GetButton(Button button)
    {
        var isPressed = base.GetButton(button);
        if (isPressed) return true;

        switch (button)
        {
            case Button.GamepadBottom: return Input.GetKey(_gamepadBottom);
            case Button.GamepadTop: return Input.GetKey(_gamepadTop);
            case Button.GamepadLeft: return Input.GetKey(_gamepadLeft);
            case Button.GamepadRight: return Input.GetKey(_gamepadRight);
            case Button.LeftBumper: return Input.GetKey(_leftBumper);
            case Button.RightBumper: return Input.GetKey(_rightBumper);
            case Button.Start: return Input.GetKey(_start);
            case Button.Options: return Input.GetKey(_options);
            default: return false;
        }
    }

    /// <summary>
    /// Checks if the given the button was pressed in this frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True is the button was pressed in this frame, false if not.</returns>
    public override bool GetButtonDown(Button button)
    {
        var isPressed = base.GetButtonDown(button);
        if (isPressed) return true;

        switch (button)
        {
            case Button.GamepadBottom: return Input.GetKeyDown(_gamepadBottom);
            case Button.GamepadTop: return Input.GetKeyDown(_gamepadTop);
            case Button.GamepadLeft: return Input.GetKeyDown(_gamepadLeft);
            case Button.GamepadRight: return Input.GetKeyDown(_gamepadRight);
            case Button.LeftBumper: return Input.GetKeyDown(_leftBumper);
            case Button.RightBumper: return Input.GetKeyDown(_rightBumper);
            case Button.Start: return Input.GetKeyDown(_start);
            case Button.Options: return Input.GetKeyDown(_options);
            default: return false;
        }
    }

    /// <summary>
    /// Checks if the given button was released in this frame.
    /// </summary>
    /// <param name="button">The button to check</param>
    /// <returns>True if the button was released, false if not.</returns>
    public override bool GetButtonUp(Button button)
    {
        var isPressed = base.GetButtonUp(button);
        if (isPressed) return true;

        switch (button)
        {
            case Button.GamepadBottom: return Input.GetKeyUp(_gamepadBottom);
            case Button.GamepadTop: return Input.GetKeyUp(_gamepadTop);
            case Button.GamepadLeft: return Input.GetKeyUp(_gamepadLeft);
            case Button.GamepadRight: return Input.GetKeyUp(_gamepadRight);
            case Button.LeftBumper: return Input.GetKeyUp(_leftBumper);
            case Button.RightBumper: return Input.GetKeyUp(_rightBumper);
            case Button.Start: return Input.GetKeyUp(_start);
            case Button.Options: return Input.GetKeyUp(_options);
            default: return false;
        }
    }

    /// <summary>
    /// Checks if any button has been pressed.
    /// </summary>
    /// <returns>True if a button was pressed. Otherwise false. </returns>
    public override bool AnyButtonPressed()
    {
        return base.AnyButtonPressed() || Input.GetKeyDown(_gamepadBottom)
            || Input.GetKeyDown(_gamepadTop) || Input.GetKeyDown(_gamepadLeft)
            || Input.GetKeyDown(_gamepadRight) || Input.GetKeyDown(_leftBumper)
            || Input.GetKeyDown(_rightBumper) || Input.GetKeyDown(_start)
            || Input.GetKeyDown(_options) || Input.GetKeyDown(_left)
            || Input.GetKeyDown(_right) || Input.GetKeyDown(_down) || Input.GetKeyDown(_up);
    }
}
