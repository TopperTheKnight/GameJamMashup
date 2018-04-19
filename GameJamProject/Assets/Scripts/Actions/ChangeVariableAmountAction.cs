using UnityEngine;
using System.Collections;

public class ChangeVariableAmountAction : Action
{
	public string variableName;
    public int amountToChange;

    public bool changeToSpecificAmount;

	public override bool ExecuteAction(GameObject dataObject)
	{
        if (DataManager.instance)
        {
            if (changeToSpecificAmount)
                DataManager.instance.setAmount(variableName, amountToChange);

            else
                DataManager.instance.changeAmount(variableName, amountToChange);

            return true;
		}

		else
		{
            Debug.Log("Found no DataManager in the scene.");
			return false;
		}
	}
}
