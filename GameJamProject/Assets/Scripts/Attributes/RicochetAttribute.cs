using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetAttribute : MonoBehaviour {

    [HideInInspector]
    public string TagToRicochetOff;
    public int numberOfBounces;

    private Rigidbody2D rb;
    private Vector3 movementDirection;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        movementDirection = rb.velocity / 100;
        rb.velocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        transform.position = transform.position + movementDirection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(TagToRicochetOff) && numberOfBounces == -1)
        {

            Vector2 inDirection = movementDirection;
            Debug.Log(inDirection);
            Vector2 inNormal = collision.contacts[0].normal;
            Debug.Log(inNormal);
            movementDirection = Vector2.Reflect(inDirection, inNormal);
            Debug.Log(movementDirection);
        }

        else if (collision.transform.CompareTag(TagToRicochetOff) && numberOfBounces > -1)
        {

            if (numberOfBounces == 0)
                Destroy(gameObject);

            else
                {
                    Vector2 inDirection = movementDirection;
                    Vector2 inNormal = collision.contacts[0].normal;
                    movementDirection = Vector2.Reflect(inDirection, inNormal);
                    numberOfBounces--;
                }

        }
    }
}
