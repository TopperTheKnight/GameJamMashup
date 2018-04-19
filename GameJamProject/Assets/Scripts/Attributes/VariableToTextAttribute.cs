using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableToTextAttribute : MonoBehaviour {


    public string preText;
    public string variableName;
    public string postText;

    private Text textElement;

	void Start () {

        textElement = GetComponent<Text>();

        if (textElement)
        {
            textElement.text = preText + DataManager.instance.GetAmount(variableName).ToString() + postText;
        }
	}

    void LateUpdate()
    {

        if (textElement)
        {
            textElement.text = preText + DataManager.instance.GetAmount(variableName).ToString() + postText;
        }
    }

}
