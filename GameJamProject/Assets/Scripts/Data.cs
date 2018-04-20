using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
struct FortData
{
    public GameObject fort;
    public Vector3 postision;
    public Player player;
}

public class Data : MonoBehaviour {
    
    Dictionary<string, Character> characterDictionary = new Dictionary<string, Character>();
    public PlayerData player1;
    public PlayerData player2;

    [SerializeField]
    FortData[] forts;

    [SerializeField]
    InputField player1NameField;
    [SerializeField]
    InputField player2NameField;

    string player1Choise;
    string player2Choise;

    private void Awake()
    {
        characterDictionary.Add("Trump",Character.Trump);
        characterDictionary.Add("Kim", Character.Kim);
        characterDictionary.Add("Rancho", Character.Rancho);
    }

    public void SetPlayerOneType(string name)
    {
        characterDictionary.TryGetValue(name, out player1.pick);

        switch (name)
        {
            case "Putin":
                player1.fort = forts[2].fort;
                player1.position = forts[2].postision;
                break;
            case "Kim":
                player1.fort = forts[6].fort;
                player1.position = forts[6].postision;
                break;
            case "Trump":
                player1.fort = forts[0].fort;
                player1.position = forts[0].postision;
                break;
            case "Rancho":
                player1.fort = forts[4].fort;
                player1.position = forts[4].postision;
                break;
        }
    }

    public void SetPlayerTwoType(string name)
    {
        characterDictionary.TryGetValue(name, out player2.pick);
        switch (name)
        {
            case "Putin":
                player2.fort = forts[3].fort;
                player2.position = forts[3].postision;
                break;
            case "Kim":
                player2.fort = forts[7].fort;
                player2.position = forts[7].postision;
                break;
            case "Trump":
                player2.fort = forts[1].fort;
                player2.position = forts[1].postision;
                break;
            case "Rancho":
                player2.fort = forts[5].fort;
                player2.position = forts[5].postision;
                break;
        }
    }





    public void Play()
    {

        player1.playerName = player1NameField.text;
        player2.playerName = player2NameField.text;
        player1.playerAmmo = 15;
        player2.playerAmmo = 15;


        if(player1.pick != null && player1.playerName != null && player1.fort != null){
            if (player2.pick != null && player2.playerName != null && player2.fort != null) {
                DontDestroyOnLoad(this.gameObject);
                SceneManager.LoadScene("Topper");
            }
        }
        
    }

}
