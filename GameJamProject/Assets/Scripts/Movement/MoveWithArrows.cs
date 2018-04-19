using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveWithArrows : Physics2DObject
{
	[Header("Input keys")]
	public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

	[Header("Movement")]
	public float speed = 5f;
	public Enums.MovementType movementType = Enums.MovementType.AllDirections;

	[Header("Orientation")]
	public bool orientToDirection = false;
	// The direction that will face the player
	public Enums.Directions lookAxis = Enums.Directions.Up;

	private Vector2 movement;
    private Vector2 cachedDirection = new Vector2();

    private float moveHorizontal;
	private float moveVertical;


    void Start()
    {
        cachedDirection *= 1;
    }

	// Update gets called every frame
	void Update ()
	{	
		// Moving with the arrow keys
		if(typeOfControl == Enums.KeyGroups.ArrowKeys)
		{
			moveHorizontal = Input.GetAxis("Horizontal");
			moveVertical = Input.GetAxis("Vertical");
		}
		else if (typeOfControl == Enums.KeyGroups.WASD)
		{
			moveHorizontal = Input.GetAxis("Horizontal2");
			moveVertical = Input.GetAxis("Vertical2");
		}
		else if (typeOfControl == Enums.KeyGroups.TFGH)
		{
			moveHorizontal = Input.GetAxis("Horizontal3");
			moveVertical = Input.GetAxis("Vertical3");
		}
		else
		{
			moveHorizontal = Input.GetAxis("Horizontal4");
			moveVertical = Input.GetAxis("Vertical4");
		}

		//zero-out the axes that are not needed, if the movement is constrained
		switch(movementType)
		{
			case Enums.MovementType.OnlyHorizontal:
				moveVertical = 0f;
				break;
			case Enums.MovementType.OnlyVertical:
				moveHorizontal = 0f;
				break;
		}
			
		movement = new Vector2(moveHorizontal, moveVertical);


		//rotate the gameObject towards the direction of movement
		//the axis to look can be decided with the "axis" variable
		if(orientToDirection)
		{
			if(movement.sqrMagnitude >= 0.01f)
			{
                // Vector2.Angle(Vector2.up, movement
                cachedDirection = movement;
                transform.rotation = Quaternion.Euler(0, 0, Utils.AngleSigned(Vector2.up, movement, Vector3.one));
            }
        }
	}

	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate ()
	{
		// Apply the force to the Rigidbody2d
		rigidbody2D.AddForce(movement * speed * 10f);
	}

}