using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public struct PlayerData
{
    public enum Character { Trump, Kim, Rancho }
    public string playerName;
    public int playerAmmo;
    public Character pick;
    public GameObject fort;

}
public class GameManager : MonoBehaviour {

    //gameObjects
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject camPositionPlayerOne;
    [SerializeField]
    GameObject camPositionPlayerTwo;
    [SerializeField]
    GameObject playerOnePos;
    [SerializeField]
    GameObject playerTwoPos;



    //UI components
    [SerializeField]
    Text PlayerText;
    [SerializeField]
    Text AmmoText;
    [SerializeField]
    Text TurnCounter;

    //general 
    public int turnCount = 1;
    enum Player { p1, p2}
    Vector3 velocity;


    //player Data
    Player currentPlayer = Player.p1;
    PlayerData playerOne;
    PlayerData playerTwo;

    //scene information



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        TurnCounter.text = "Turn: " + turnCount;
        if ((turnCount%2 != 0))
        {
            currentPlayer = Player.p1;
        }
        else
        {
            currentPlayer = Player.p2;
        }




        if (currentPlayer == Player.p1)
        {
            Player1Update();
        }
        else
        {
            Player2Update();
        }

	}

    void Player1Update()
    {
        if (mainCamera.transform.position != camPositionPlayerOne.transform.position)
        {

            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, camPositionPlayerOne.transform.position, ref velocity, 0.5f);
            PlayerText.text = "Player 1";
        }
    }
    void Player2Update()
    {
        if (mainCamera.transform.position != camPositionPlayerTwo.transform.position)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, camPositionPlayerTwo.transform.position,ref velocity, 0.5f);
            PlayerText.text = "Player 2";

        }
    }

    

}
