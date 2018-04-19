using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ConditionStart : ConditionBase
{

    void Start()
    {
        ExecuteAllActions(null);
    }
}