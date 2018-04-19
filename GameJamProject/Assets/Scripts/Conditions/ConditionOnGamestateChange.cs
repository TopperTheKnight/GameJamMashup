using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ConditionOnGamestateChange : ConditionBase
{

    public Enums.GameState stateTocheck;

    void Start()
    {
        if (StateManager.instance)
        {
            StateManager.stateChangeEvent += OnStateChange;
        }

        else
        {
            Debug.Log("Could not find a Gamemanager in the scene");
        }
    }

    void OnStateChange()
    {
        if (StateManager.instance.currentGameState == stateTocheck)
            ExecuteAllActions(null);
    }
}