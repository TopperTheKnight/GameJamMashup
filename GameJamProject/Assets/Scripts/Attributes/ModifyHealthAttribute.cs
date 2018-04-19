using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class ModifyHealthAttribute : MonoBehaviour
{

	public int healthChange = -1;
    public bool knockback;
    public float knockbackStrength;


	// This function gets called everytime this object collides with another
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		HealthSystemAttribute healthScript = collisionData.gameObject.GetComponent<HealthSystemAttribute>();
		if(healthScript != null)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);

            if (knockback)
            {
                Rigidbody2D rigidbody = collisionData.gameObject.GetComponent<Rigidbody2D>();
                if (rigidbody)
                {
                    rigidbody.AddForce(-collisionData.relativeVelocity.normalized * knockbackStrength, ForceMode2D.Impulse);
                }
            }
		}
	}

	private void OnTriggerEnter2D(Collider2D colliderData)
	{
		HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
		if(healthScript != null)
		{
			// subtract health from the player
			healthScript.ModifyHealth(healthChange);
		}
	}
}
