using UnityEngine;
using System.Collections;

public class CreateRandomObjectAction : Action
{
    public GameObject[] prefabToCreate;
    public bool relativePosition = false;
    public Vector3 newPosition;

    private int randomInt;

    // Moves the gameObject instantly to a custom position
    public override bool ExecuteAction(GameObject dataObject)
    {
        if (prefabToCreate != null)
        {
            randomInt = Random.Range(0, prefabToCreate.Length);
            Debug.Log(randomInt);

            
            //create the new object by copying the prefab
            GameObject newObject = Instantiate<GameObject>(prefabToCreate[randomInt]);

            //let's place it in the desired position!

            if (relativePosition)
            {
                newObject.transform.position = transform.position + newPosition;
            }
            else
            {
                newObject.transform.position = newPosition;
            }
            

            return true;
        }
        else
        {
            return false;
        }
    }
}
