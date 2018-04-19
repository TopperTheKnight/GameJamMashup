using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public static StateManager instance;

    public delegate void StateChange();
    public static StateChange stateChangeEvent;

    [HideInInspector]
    public Enums.GameState currentGameState;

	// Use this for initialization
	void Awake () {

        if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(instance);
    }
	
    public void setGameState(Enums.GameState state)
    {
        currentGameState = state;

        if (stateChangeEvent != null)
        {
            foreach (var d in stateChangeEvent.GetInvocationList())
            {
                if (d == null)
                    stateChangeEvent -= (d as StateChange);
            }

            stateChangeEvent();
        }

    }
}
