using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ConditionDestory : ConditionBase
{
    void OnDestroy()
    {
        ExecuteAllActions(null);
    }
}