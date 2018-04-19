using UnityEngine;
using System.Collections;

public class SetGamestateAction : Action
{
	public Enums.GameState targetState;

	// Changes the object state from active to inactive, and viceversa
	public override bool ExecuteAction(GameObject dataObject)
	{

        if (StateManager.instance)
        {
            StateManager.instance.setGameState(targetState);

            if (StateManager.instance.currentGameState == targetState)
                return true;

            else
            {
                Debug.Log("Could not change to the gamestate: " + targetState.ToString());
                return false;
            }
		}

		else
		{
            Debug.Log("Found no GameManager in the scene.");
			return false;
		}
	}
}
