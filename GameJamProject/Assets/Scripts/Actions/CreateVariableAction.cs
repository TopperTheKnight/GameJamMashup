using UnityEngine;
using System.Collections;

public class CreateVariableAction : Action
{
	public string variableName;
    public int amount;

	// Changes the object state from active to inactive, and viceversa
	public override bool ExecuteAction(GameObject dataObject)
	{
        if (DataManager.instance)
        {
            DataManager.instance.AddVariable(variableName, amount);

            if (DataManager.instance.CompareAmount(variableName, amount))
                return true;

            else
            {
                Debug.Log("Failed to create variable");
                return false;
            }
		}

		else
		{
            Debug.Log("Found no DataManager in the scene.");
			return false;
		}
	}
}
