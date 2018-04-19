using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ConditionCountdown : ConditionBase
{

    public float countdownTime;

    public bool loop;

    public bool randomInterval;
    public int min;
    public int max;


    void Start()
    {

        if (randomInterval)
        {
            countdownTime = Random.Range(min, max + 1);
        }

        Invoke("DestroyMe", countdownTime);
    }

    void DestroyMe()
    {
        ExecuteAllActions(null);

        if (loop)
        {
            if (randomInterval)
            {
                countdownTime = Random.Range(min, max + 1);
            }

            Invoke("DestroyMe", countdownTime);
            Debug.Log(countdownTime);
        }
    }
}