using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Class ControllerManager.
/// 
/// Manages all of the contollers for the players in the game.
/// To create a Controller Manager call the static Controller getter.
/// </summary>
public class ControllerManager
{
    private readonly Dictionary<int, ControllerMap> _playerControllers;
    private readonly Dictionary<int, ControllerMap> _allControllers;

    private static ControllerManager _controllerManager;

    /// <summary>
    /// Constructs a ControllerManager.
    /// </summary>
    public ControllerManager()
    {
        _playerControllers = new Dictionary<int, ControllerMap>();
        _allControllers = new Dictionary<int, ControllerMap>();

        for (var i = 0; i < 8; ++i)
        {
            _allControllers[i + 1] = new ControllerMap(i + 1);
        }
    }

    /// <summary>
    /// Adds a controller for the player Id.
    /// </summary>
    /// <param name="playerId">The player Id.</param>
    public void AddController(int playerId)
    {
        _playerControllers[playerId] = new ControllerMap(playerId);
    }

    /// <summary>
    /// Gets the controller for the player Id.
    /// </summary>
    /// <param name="playerId">The player Id.</param>
    /// <returns>The controller.</returns>
    public ControllerMap GetController(int playerId)
    {
        return _playerControllers[playerId];
    }

    /// <summary>
    /// Removes a controller at the playerId.
    /// </summary>
    /// <param name="playerId">The player Id.</param>
    public void RemoveController(int playerId)
    {
        _playerControllers.Remove(playerId);
    }

    /// <summary>
    /// Removed all of the controllers
    /// </summary>
    public void RemoveAllControllers()
    {
        _playerControllers.Clear();
    }

    /// <summary>
    /// Checks if a button has been pressed on ANY controller.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>If a button has been pressed, the controller Id, otherwise -1.</returns>
    public int HasPressed(ControllerMap.Button button)
    {
        foreach (var controllerMap in _allControllers.Where(controllerMap => controllerMap.Value.GetButtonDown(button)))
        {
            return controllerMap.Key;
        }
        return -1;
    }

    /// <summary>
    /// Checks if a button has been pressed on a controller belonging to a player.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>If a button has been pressed, the player Id, otherwise -1.</returns>
    public int HasPlayerPressed(ControllerMap.Button button)
    {
        foreach (var controllerMap in _playerControllers.Where(controllerMap => controllerMap.Value.GetButtonDown(button)))
        {
            return controllerMap.Key;
        }
        return -1;
    }

    /// <summary>
    /// Checks if any button has been pressed on any controller, regardless if it's being used by a player or not.
    /// </summary>
    /// <returns>True is a button has been pressed, false if not.</returns>
    public bool AnyButtonPressed()
    {
        return _allControllers.Values.Any(controller => controller.AnyButtonPressed());
    }

    /// <summary>
    /// Global accessor for the controllor manager. 
    /// If the controller manager doesn't exist it creates a new one.
    /// </summary>
    /// <returns>The controller manager.</returns>
    public static ControllerManager Controllers
    {
        get { return _controllerManager ?? (_controllerManager = new ControllerManager()); }
    }
}
