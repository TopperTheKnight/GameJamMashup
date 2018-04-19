using UnityEngine;
using System.Collections;

public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
    public bool relativePosition = false;
    public bool relativeRotation = false;
	public Vector3 newPosition;

	// Moves the gameObject instantly to a custom position
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(prefabToCreate != null)
		{
			//create the new object by copying the prefab
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);

            //let's place it in the desired position!

            if (relativePosition)
            {
                newObject.transform.position = transform.position + newPosition; 
            }
            else
            {
                newObject.transform.position = newPosition;
            }

            if (relativeRotation)
            {
                newObject.transform.eulerAngles = transform.eulerAngles;
            }

			return true;
		}
		else
		{
			return false;
		}
	}
}
