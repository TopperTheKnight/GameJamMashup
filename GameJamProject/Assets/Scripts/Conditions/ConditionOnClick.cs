using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ConditionOnClick : ConditionBase
{
    void OnMouseDown()
    {
        ExecuteAllActions(null);
    }
}
