using UnityEngine;
using System.Collections;

public class CheckVariableAction : Action
{
	public string variableName;
    public int amountToCheck;
    public MathematicalOperators mathOperator = MathematicalOperators.EqualTo;
    private int amount;
    private bool returnBool;

    // Changes the object state from active to inactive, and viceversa
    public override bool ExecuteAction(GameObject dataObject)
	{

        if (DataManager.instance)
        {

            amount = DataManager.instance.GetAmount(variableName);

            switch (mathOperator)
            {
                case MathematicalOperators.HigherThan:
                    if(amountToCheck < amount)
                    {
                        returnBool = true;
                    }
                    else
                    {
                        returnBool = false;
                    }
                    break;

                case MathematicalOperators.HigherOrEqualTo:
                    if (amountToCheck <= amount)
                    {
                        returnBool = true;
                    }
                    else
                    {
                        returnBool = false;
                    }
                    break;

                case MathematicalOperators.EqualTo:
                    if (amountToCheck == amount)
                    {
                        returnBool = true;
                    }
                    else
                    {
                        returnBool = false;
                    }
                    break;

                case MathematicalOperators.LowerOrEqualTo:
                    if (amountToCheck >= amount)
                    {
                        returnBool = true;
                    }
                    else
                    {
                        returnBool = false;
                    }
                    break;

                case MathematicalOperators.LowerThan:
                    if (amountToCheck > amount)
                    {
                        returnBool = true;
                    }
                    else
                    {
                        returnBool = false;
                    }
                    break;
            }

            return returnBool;
		}

		else
		{
            Debug.Log("Found no DataManager in the scene.");
			return false;
		}
	}

    public enum MathematicalOperators
    {
        HigherThan,
        HigherOrEqualTo,
        EqualTo,
        LowerOrEqualTo,
        LowerThan,
    }

}
