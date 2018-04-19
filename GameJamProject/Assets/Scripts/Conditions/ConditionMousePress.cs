using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ConditionMousePress : ConditionBase
{
    public MouseTypes mouseToPress = MouseTypes.LeftClick;

    private KeyCode keyToPress;

    [Header("Type of Event")]
    public KeyEventTypes eventType = KeyEventTypes.JustPressed;

    public float frequency = 0.5f;

    private float timeLastEventFired;

    private void Start()
    {
        timeLastEventFired = -frequency;

        switch (mouseToPress)
        {
            case MouseTypes.LeftClick:
                keyToPress = KeyCode.Mouse0;
                break;

            case MouseTypes.RightClick:
                keyToPress = KeyCode.Mouse1;
                break;

            case MouseTypes.MiddleClick:
                keyToPress = KeyCode.Mouse2;
                break;
        }
    }


    private void Update()
    {
        switch (eventType)
        {
            case KeyEventTypes.JustPressed:
                if (Input.GetKeyDown(keyToPress))
                {
                    ExecuteAllActions(null);
                }
                break;
            case KeyEventTypes.Released:
                if (Input.GetKeyUp(keyToPress))
                {
                    ExecuteAllActions(null);
                }
                break;
            case KeyEventTypes.KeptPressed:
                if (Time.time >= timeLastEventFired + frequency
                    && Input.GetKey(keyToPress))
                {
                    ExecuteAllActions(null);
                    timeLastEventFired = Time.time;
                }
                break;
        }
    }

    public enum KeyEventTypes
    {
        JustPressed,
        Released,
        KeptPressed
    }

    public enum MouseTypes
    {
        LeftClick,
        RightClick,
        MiddleClick
    }

}