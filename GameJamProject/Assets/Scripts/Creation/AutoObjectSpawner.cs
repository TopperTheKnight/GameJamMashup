using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class AutoObjectSpawner : MonoBehaviour
{
	[Header("Object creation")]

	// The object to spawn
	// WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
	public GameObject prefabToSpawn;

	[Header("Other options")]

	// Configure the spawning pattern
	public float spawnInterval = 1;

    public bool exponentialSpawn;

    public float timeMod = 0.98f;

    private BoxCollider2D boxCollider2D;

	void Start ()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();

		StartCoroutine(SpawnObject());
	}
	
	// This will spawn an object, and then wait some time, then spawn another...
	IEnumerator SpawnObject ()
	{
		while(true)
		{
			// Create some random numbers
			float randomX = Random.Range (-boxCollider2D.size.x, boxCollider2D.size.x) *.5f;
			float randomY = Random.Range (-boxCollider2D.size.y, boxCollider2D.size.y) *.5f;

			// Generate the new object
			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);
            // Generate the object with same rotation
            newObject.transform.eulerAngles = transform.eulerAngles;

            // Wait for some time before spawning another object
            if (exponentialSpawn)
            {
                if (spawnInterval * timeMod > 0.5)
                {
                    spawnInterval = spawnInterval * timeMod;
                }
            }

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
