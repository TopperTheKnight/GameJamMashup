using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeSpriteAction : Action
{
    public Sprite targetSprite;

    private SpriteRenderer rend;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public override bool ExecuteAction(GameObject dataObject)
    {
        if (targetSprite != null)
        {

            rend.sprite = targetSprite;

            return true;
        }
        else
        {
            return false;
        }
    }
}

