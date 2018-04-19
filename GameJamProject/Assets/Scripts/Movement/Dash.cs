using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : Physics2DObject
{
    [Header("Dash setup")]
    // the key used to activate the push
    public KeyCode key = KeyCode.Space;

    // strength of the push
    public float dashStrength = 10f;

    public float cooldown = 2;

    private bool canDash = true;

    // Read the input from the player
    void Update()
    {

        if (canDash && Input.GetKeyDown(key))
        {
            // Apply an instantaneous upwards force
            rigidbody2D.AddRelativeForce(Vector2.up * dashStrength, ForceMode2D.Impulse);
            canDash = false;
            StartCoroutine(DashCooldown());
        }

    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }



}