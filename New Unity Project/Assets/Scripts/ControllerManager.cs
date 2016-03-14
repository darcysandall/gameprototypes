using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Class ControllerManager.
/// 
/// Manages all of the controllers.
/// </summary>
public class ControllerManager
{
    private readonly Dictionary<int, KeyboardMap> _controllers;
    private static ControllerManager _controllerManager;

    /// <summary>
    /// Constructs a ControllerManager.
    /// </summary>
    public ControllerManager()
    {
        _controllers = new Dictionary<int, KeyboardMap>();
    }

    /// <summary>
    /// Adds a controller for the player Id.
    /// </summary>
    /// <param name="playerId">The player Id.</param>
    public void AddController(int playerId)
    {
        _controllers[playerId] = new KeyboardMap(playerId);
    }

    /// <summary>
    /// Gets the controller for the player Id.
    /// </summary>
    /// <param name="playerId">The player Id.</param>
    /// <returns>The controller.</returns>
    public ControllerMap GetController(int playerId)
    {
        return _controllers[playerId];
    }

    /// <summary>
    /// Checks if a player has pressed a button.
    /// </summary>
    /// <param name="button">The button to check.</param>
    /// <returns>If a button has been pressed, the player Id, otherwise -1.</returns>
    public int HasPressed(ControllerMap.Button button)
    {
        foreach (var controllerMap in _controllers.Where(controllerMap => controllerMap.Value.GetButtonDown(button)))
        {
            return controllerMap.Key;
        }
        return -1;
    }

    public bool AnyButtonPressed()
    {
        return _controllers.Values.Any(controller => controller.AnyButtonPressed());
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
