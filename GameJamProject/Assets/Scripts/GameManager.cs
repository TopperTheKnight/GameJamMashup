using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Character { Trump, Kim, Rancho }
public enum Player { p1, p2 }
public struct PlayerData
{
    
    public string playerName;
    public int playerAmmo;
    public Character pick;
    public GameObject fort;
    public Vector3 position;

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

    Data dataSaver;


    //UI components
    [SerializeField]
    Text PlayerText;
    [SerializeField]
    Text AmmoText;
    [SerializeField]
    Text TurnCounter;

    //general 
    public int turnCount = 1;
   
    Vector3 velocity;

    bool first = true;
    //player Data
    Player currentPlayer = Player.p1;
    PlayerData playerOne;
    PlayerData playerTwo;

    //scene information



	// Use this for initialization
	void Start () {
		
	}
	
    void Setup()
    {
        playerOne = dataSaver.player1;
        playerTwo = dataSaver.player2;

        Instantiate(playerOne.fort,playerOne.position,Quaternion.identity);
        Instantiate(playerTwo.fort, playerTwo.position, Quaternion.identity);


    }

	// Update is called once per frame
	void Update () {
        if (dataSaver == null)
        {
            try
            {
                dataSaver = FindObjectOfType<Data>();
            }
            catch
            {
                dataSaver = null;
            }
        }else if (first)
        {
            Setup();
            first = false;
        }


        TurnCounter.text = "Turn: " + turnCount;
        if ((turnCount % 2 != 0))
        {
            currentPlayer = Player.p1;
        }
        else
        {
            currentPlayer = Player.p2;
        }




        if (currentPlayer == Player.p1)
        {
            if (mainCamera.transform.position != camPositionPlayerOne.transform.position)
            {

                mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, camPositionPlayerOne.transform.position, ref velocity, 0.5f);
                PlayerText.text = playerOne.playerName;
                AmmoText.text = playerOne.playerAmmo.ToString();
                
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                turnCount++;
                currentPlayer = Player.p2;
                playerOne.playerAmmo--;
            }
        }
        else
        {
            if (mainCamera.transform.position != camPositionPlayerTwo.transform.position)
            {
                mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, camPositionPlayerTwo.transform.position, ref velocity, 0.5f);
                PlayerText.text = playerTwo.playerName;
                AmmoText.text = playerTwo.playerAmmo.ToString();
                
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                turnCount++;
                currentPlayer = Player.p1;
                playerTwo.playerAmmo--;
            }
        }

	}



    

}
