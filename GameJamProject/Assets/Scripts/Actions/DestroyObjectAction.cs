using UnityEngine;
using System.Collections;

public class DestroyObjectAction : Action
{
    //who gets destroyed in the collision?
    public GameObject objectToDestroy;
	// assign an effect (explosion? particles?) or object to be created (instantiated) when the one gets destroyed
	public GameObject deathEffect;


	// Happens when this objects hits another one
	public override bool ExecuteAction(GameObject otherObject)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate<GameObject>(deathEffect);
            //move the effect depending on who needs to be destroyed
            newObject.transform.position = objectToDestroy.transform.position;
		}

		//remove the gameObject from the scene (destroy)
			if(objectToDestroy != null)
			{
				Destroy(objectToDestroy);
				return true;
			}
			else
			{
				return false; //no object is destroyed
			}
	}
}
