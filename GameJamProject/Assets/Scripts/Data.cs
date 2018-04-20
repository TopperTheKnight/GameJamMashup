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
    InputField player1NameField;
    [SerializeField]
    InputField player2NameField;

    private void Awake()
    {
        characterDictionary.Add("Trump",Character.Trump);
        characterDictionary.Add("Kim", Character.Kim);
        characterDictionary.Add("Rancho", Character.Rancho);
    }

    public void SetPlayerOneType(string name)
    {
        characterDictionary.TryGetValue(name, out player1.pick);
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

        SceneManager.LoadScene("Topper");
    }

}
