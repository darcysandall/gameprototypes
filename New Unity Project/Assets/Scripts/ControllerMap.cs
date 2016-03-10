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
    private readonly KeyCode _leftTrigger;
    private readonly KeyCode _rightTrigger;
    private readonly KeyCode _start;
    private readonly KeyCode _options;

    public enum Button
    {
        GamepadLeft,
        GamepadRight,
        GamepadTop,
        GamepadBottom,
        LeftTrigger,
        RightTrigger,
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
                _leftTrigger = KeyCode.Joystick1Button4;
                _rightTrigger = KeyCode.Joystick1Button5;
                _options = KeyCode.Joystick1Button6;
                _start = KeyCode.Joystick1Button7;
                break;
            case 2:
                _gamepadBottom = KeyCode.Joystick2Button0;
                _gamepadRight = KeyCode.Joystick2Button1;
                _gamepadLeft = KeyCode.Joystick2Button2;
                _gamepadTop = KeyCode.Joystick2Button3;
                _leftTrigger = KeyCode.Joystick2Button4;
                _rightTrigger = KeyCode.Joystick2Button5;
                _options = KeyCode.Joystick2Button6;
                _start = KeyCode.Joystick2Button7;
                break;
            case 3:
                _gamepadBottom = KeyCode.Joystick3Button0;
                _gamepadRight = KeyCode.Joystick3Button1;
                _gamepadLeft = KeyCode.Joystick3Button2;
                _gamepadTop = KeyCode.Joystick3Button3;
                _leftTrigger = KeyCode.Joystick3Button4;
                _rightTrigger = KeyCode.Joystick3Button5;
                _options = KeyCode.Joystick3Button6;
                _start = KeyCode.Joystick3Button7;
                break;
            case 4:
                _gamepadBottom = KeyCode.Joystick4Button0;
                _gamepadRight = KeyCode.Joystick4Button1;
                _gamepadLeft = KeyCode.Joystick4Button2;
                _gamepadTop = KeyCode.Joystick4Button3;
                _leftTrigger = KeyCode.Joystick4Button4;
                _rightTrigger = KeyCode.Joystick4Button5;
                _options = KeyCode.Joystick4Button6;
                _start = KeyCode.Joystick4Button7;
                break;
            default:
                Debug.LogError("The player ID can only be from 1 to 4.");
                break;
        }
    }

    public float XAxis
    {
        get { return Input.GetAxisRaw("Horizontal" + _playerId); }
    }

    public float YAxis
    {
        get { return Input.GetAxisRaw("Horizontal" + _playerId); }
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
            case Button.GamepadBottom: return Input.GetButton(_gamepadBottom.ToString());
            case Button.GamepadTop: return Input.GetButton(_gamepadTop.ToString());
            case Button.GamepadLeft: return Input.GetButton(_gamepadLeft.ToString());
            case Button.GamepadRight: return Input.GetButton(_gamepadRight.ToString());
            case Button.LeftTrigger: return Input.GetButton(_leftTrigger.ToString());
            case Button.RightTrigger: return Input.GetButton(_rightTrigger.ToString());
            case Button.Start: return Input.GetButton(_start.ToString());
            case Button.Options: return Input.GetButton(_options.ToString());
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
            case Button.GamepadBottom: return Input.GetButtonDown(_gamepadBottom.ToString());
            case Button.GamepadTop: return Input.GetButtonDown(_gamepadTop.ToString());
            case Button.GamepadLeft: return Input.GetButtonDown(_gamepadLeft.ToString());
            case Button.GamepadRight: return Input.GetButtonDown(_gamepadRight.ToString());
            case Button.LeftTrigger: return Input.GetButtonDown(_leftTrigger.ToString());
            case Button.RightTrigger: return Input.GetButtonDown(_rightTrigger.ToString());
            case Button.Start: return Input.GetButtonDown(_start.ToString());
            case Button.Options: return Input.GetButtonDown(_options.ToString());
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
            case Button.GamepadBottom: return Input.GetButtonUp(_gamepadBottom.ToString());
            case Button.GamepadTop: return Input.GetButtonUp(_gamepadTop.ToString());
            case Button.GamepadLeft: return Input.GetButtonUp(_gamepadLeft.ToString());
            case Button.GamepadRight: return Input.GetButtonUp(_gamepadRight.ToString());
            case Button.LeftTrigger: return Input.GetButtonUp(_leftTrigger.ToString());
            case Button.RightTrigger: return Input.GetButtonUp(_rightTrigger.ToString());
            case Button.Start: return Input.GetButtonUp(_start.ToString());
            case Button.Options: return Input.GetButtonUp(_options.ToString());
            default: return false;
        }
    }
}
