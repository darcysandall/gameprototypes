using UnityEngine;

/// <summary>
/// Class ControllerMap.
/// 
/// Receives input from a particular contoller for a specified player.
/// This class hides the unity default names for controller buttons and provides more easily understood names.
/// </summary>
public class ControllerMap
{
    private readonly int _playerId;
    private readonly KeyCode _gamepadBottom;
    private readonly KeyCode _gamepadRight;
    private readonly KeyCode _gamepadLeft;
    private readonly KeyCode _gamepadTop;
    private readonly KeyCode _leftBumper;
    private readonly KeyCode _rightBumper;
    private readonly KeyCode _start;
    private readonly KeyCode _options;

    public enum Button
    {
        GamepadLeft,
        GamepadRight,
        GamepadTop,
        GamepadBottom,
        LeftBumper,
        RightBumper,
        Start,
        Options
    }

    /// <summary>
    /// Constructs a ControllerMap
    /// 
    /// Sets all of the KeyCodes accoring to the player ID that the controller represents.
    /// </summary>
    /// <param name="playerId">The player ID from 1 to 4.</param>
    public ControllerMap(int playerId)
    {
        _playerId = playerId;

        switch (playerId)
        {
            case 1:
                _gamepadBottom = KeyCode.Joystick1Button0;
                _gamepadRight = KeyCode.Joystick1Button1;
                _gamepadLeft = KeyCode.Joystick1Button2;
                _gamepadTop = KeyCode.Joystick1Button3;
                _leftBumper = KeyCode.Joystick1Button4;
                _rightBumper = KeyCode.Joystick1Button5;
                _options = KeyCode.Joystick1Button6;
                _start = KeyCode.Joystick1Button7;
                break;
            case 2:
                _gamepadBottom = KeyCode.Joystick2Button0;
                _gamepadRight = KeyCode.Joystick2Button1;
                _gamepadLeft = KeyCode.Joystick2Button2;
                _gamepadTop = KeyCode.Joystick2Button3;
                _leftBumper = KeyCode.Joystick2Button4;
                _rightBumper = KeyCode.Joystick2Button5;
                _options = KeyCode.Joystick2Button6;
                _start = KeyCode.Joystick2Button7;
                break;
            case 3:
                _gamepadBottom = KeyCode.Joystick3Button0;
                _gamepadRight = KeyCode.Joystick3Button1;
                _gamepadLeft = KeyCode.Joystick3Button2;
                _gamepadTop = KeyCode.Joystick3Button3;
                _leftBumper = KeyCode.Joystick3Button4;
                _rightBumper = KeyCode.Joystick3Button5;
                _options = KeyCode.Joystick3Button6;
                _start = KeyCode.Joystick3Button7;
                break;
            case 4:
                _gamepadBottom = KeyCode.Joystick4Button0;
                _gamepadRight = KeyCode.Joystick4Button1;
                _gamepadLeft = KeyCode.Joystick4Button2;
                _gamepadTop = KeyCode.Joystick4Button3;
                _leftBumper = KeyCode.Joystick4Button4;
                _rightBumper = KeyCode.Joystick4Button5;
                _options = KeyCode.Joystick4Button6;
                _start = KeyCode.Joystick4Button7;
                break;
            default:
                Debug.LogError("The player ID can only be from 1 to 4.");
                break;
        }
    }

    /// <summary>
    /// Gets the X Axis value between -1 and 1.
    /// </summary>
    public float XAxis
    {
        get { return Input.GetAxisRaw("Horizontal" + _playerId); }
    }

    /// <summary>
    /// Gets the X Axis value between -1 and 1.
    /// </summary>
    public float YAxis
    {
        get { return Input.GetAxisRaw("Vertical" + _playerId); }
    }

    /// <summary>
    /// Gets the left trigger axis value between 0 and 1.
    /// </summary>
    public float LeftTrigger
    {
        get { return Input.GetAxisRaw("LeftTrigger" + _playerId); }
    }

    /// <summary>
    /// Gets the right trigger axis value between 0 and 1.
    /// </summary>
    public float RightTrigger
    {
        get { return Input.GetAxisRaw("RightTrigger" + _playerId); }
    }

    /// <summary>
    /// Returns true if the button is held down.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True if the button was pressed, false if not.</returns>
    public bool GetButton(Button button)
    {
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
    /// Returns true if the button was pressed in this frame.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>True is the button was pressed in this frame, false if not.</returns>
    public bool GetButtonDown(Button button)
    {
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
    /// Return true if the button was released in this frame.
    /// </summary>
    /// <param name="button">The button to check</param>
    /// <returns>True if the button was released, false if not.</returns>
    public bool GetButtonUp(Button button)
    {
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
}
