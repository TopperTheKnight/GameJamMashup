using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public static DataManager instance;

    private Dictionary<string, variableStruct> variableDict = new Dictionary<string, variableStruct>();

    void Awake () {
		
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
        {
            Destroy(instance);
        }
	}

    public void AddVariable(string variableName, int amount)
    {
        if (variableDict.ContainsKey(variableName))
        {
            int newAmount = variableDict[variableName].amount + amount;
            variableDict[variableName].amount = newAmount;
        }

        else
        {
            variableDict.Add(variableName, new variableStruct(amount));
        }
    }

    public void changeAmount(string variableName, int amount)
    {
        if (variableDict.ContainsKey(variableName))
            variableDict[variableName].amount += amount;

        else
            Debug.Log("Could not find a variable called: " + variableName);
    }

    public void setAmount(string variableName, int amount)
    {
        if (variableDict.ContainsKey(variableName))
            variableDict[variableName].amount = amount;

        else
            Debug.Log("Could not find a variable called: " + variableName);
    }

    //NoDebug
    public void setAmount(string variableName, int amount, bool debug)
    {
        if (variableDict.ContainsKey(variableName))
            variableDict[variableName].amount = amount;

        else if (debug)
            Debug.Log("Could not find a variable called: " + variableName);
    }

    public bool CompareAmount(string variableName, int amount)
    {
        if (variableDict.ContainsKey(variableName))
        {
            if (variableDict[variableName].amount == amount)
                return true;

            else return false;
        }

        else
        {
            Debug.Log("Could not find a variable called: " + variableName);
            return false;
        }
    }

    public int GetAmount(string variableName)
    {
        if (variableDict.ContainsKey(variableName))
        {
            return variableDict[variableName].amount;
        }

        else
        {
            return 0;
        }
    }

    public class variableStruct
    {
        public int amount;

        public variableStruct(int a)
        {
            amount = a;
        }
    }
}
