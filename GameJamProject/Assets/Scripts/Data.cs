using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour {

    Dictionary<string, Character> characterDictionary = new Dictionary<string, Character>();
    PlayerData player1;
    PlayerData player2;

    [SerializeField]
    GameObject[] forts;

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
                break;
            case "Kim":
                break;
            case "Trump":
                break;
            case "Rancho":
                break;

            default:
                break;
        }
    }

    public void SetPlayerTwoType(string name)
    {
        characterDictionary.TryGetValue(name, out player2.pick);
    }





    public void Play()
    {

        player1.playerName = player1NameField.text;
        player2.playerName = player2NameField.text;
        player1.playerAmmo = 15;
        player2.playerAmmo = 15;


        if(player1.pick != null && player1.playerName != null && player1.fort != null){
            if (player2.pick != null && player2.playerName != null && player2.fort != null) {
                SceneManager.LoadScene("Topper");
            }
        }
        
    }

}
