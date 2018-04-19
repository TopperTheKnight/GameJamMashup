using UnityEngine;
using System.Collections;

public class Enums
{
	public enum Players
	{
		player1, player2, player3, player4
    }

	public enum Axes
	{
		X,
		Y
	}

    public enum GameState
    {
        playing,
        won,
        lost
    }

    public enum MovementType
	{
		AllDirections,
		OnlyHorizontal,
		OnlyVertical
	}

	public enum Directions
	{
		Up,
		Right,
		Down,
		Left,
	}

	public enum KeyGroups
	{
		ArrowKeys,
		WASD,
        TFGH,
        IJKL,

    }

    public enum Targets
	{
		ThisObject,
		ObjectThatCollided,
	}
}
