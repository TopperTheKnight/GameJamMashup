using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAction : Action {
    //When making a new action, make sure it inherits from the Action class.


        // The ExecuteAction method is called from a condition, an action must contain this method.
    public override bool ExecuteAction(GameObject dataObject)
    {
        var exampleBool = true;

        // When executing your action, return a bool. 
        // If true, the condition calling the action continues to the next action.
        // False ends the chain of actions.

        if (exampleBool)
        {
            Debug.Log("The custom action was succesful, and did something");
            return true;
            //Action was successful and the next action will be run. 
        }

        else
        {
            Debug.Log("The custom action failed, and broke the chain of actions.");
            return false;
            //Action was NOT successful the next action will NOT be run. 
        }
    }
}
