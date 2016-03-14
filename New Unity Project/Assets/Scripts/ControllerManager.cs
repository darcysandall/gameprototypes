﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerManager
{
    private readonly Dictionary<int, KeyboardMap> _controllers;
    private static ControllerManager _controllerManager;

    public ControllerManager()
    {
        _controllers = new Dictionary<int, KeyboardMap>();
    }

    public void AddController(int playerId)
    {
        _controllers[playerId] = new KeyboardMap(playerId);
    }

    public ControllerMap GetController(int playerId)
    {
        return _controllers[playerId];
    }

    // Checks if any button has been pressed

    public int HasPressed(ControllerMap.Button button)
    {
        return 0;
        //Checks which player has pressed the button
    }

    public static ControllerManager Controllers
    {
        get { return _controllerManager ?? (_controllerManager = new ControllerManager()); }
    }
}
