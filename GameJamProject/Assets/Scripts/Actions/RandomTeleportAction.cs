using UnityEngine;
using System.Collections;

public class RandomTeleportAction : Action
{
    public GameObject objectToTeleport;
    public bool stopMovements = true;

    private int randomX;
    private int randomY;
    private int PPU;

    private Vector3 newPosition;


    // Moves the gameObject instantly to a custom position
    public override bool ExecuteAction(GameObject dataObject)
    {
        Rigidbody2D rb2D;


        PPU = Screen.height / 10;

        randomX = Random.Range(-Screen.width / 2, Screen.width / 2);
        randomY = Random.Range(-Screen.height / 2, Screen.height / 2);
        newPosition = new Vector3(randomX / PPU, randomY / PPU, 0);

        if (objectToTeleport != null)
        {
            //moves the specified object
            objectToTeleport.transform.position = newPosition;
            rb2D = objectToTeleport.GetComponent<Rigidbody2D>();
        }
        else
        {
            //moves this object
            transform.position = newPosition;
            rb2D = transform.GetComponent<Rigidbody2D>();
        }

        //bring the object to an halt
        if (stopMovements
            && rb2D != null)
        {
            rb2D.velocity = Vector3.zero;
            rb2D.angularVelocity = 0f;
        }

        return true;
    }
}
