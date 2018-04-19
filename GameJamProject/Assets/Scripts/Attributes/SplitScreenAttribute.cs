using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SplitScreenAttribute : MonoBehaviour {

    [HideInInspector]
    public int numberOfPlayers;

    private List<CameraFollow> camFollows = new List<CameraFollow>();
    private List<Camera> cameras = new List<Camera>();

    void Awake () {

        if (numberOfPlayers < 1 || numberOfPlayers > 4)
        {
            Debug.Log("number of players must be between 1, 2, 3, or 4");
            numberOfPlayers = 1;
        }

        // Create a camera for each player
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (i > 0)
            {
                GameObject newObject = new GameObject("cam");
                //Instantiate(newObject, new Vector2(), new Quaternion());
                newObject.transform.position = new Vector3(0, 0, -10);
                
                Camera newObjectCam = newObject.AddComponent<Camera>();
                newObjectCam.orthographic = true;

                camFollows.Add(newObject.AddComponent<CameraFollow>());
                cameras.Add(newObjectCam);
            }
            else
            {
                cameras.Add(transform.GetComponent<Camera>());
                camFollows.Add(gameObject.AddComponent<CameraFollow>());
            }
        }

        if (cameras.Count == 1)
        {
        }

        else if (cameras.Count == 2)
        {
            cameras[0].rect = new Rect(0, 0, 0.498f, 1);
            cameras[1].rect = new Rect(0.502f, 0, 0.498f, 1);
        }

        else if (cameras.Count == 3)
        {
            cameras[0].rect = new Rect(0.25f, 0.502f, 0.5f, 0.498f);
            cameras[1].rect = new Rect(0, 0, 0.499f, 0.498f);
            cameras[2].rect = new Rect(0.501f, 0, 0.499f, 0.498f);

        }

        else if (cameras.Count == 4)
        {
            cameras[0].rect = new Rect(0,       0.498f, 0.499f, 1);
            cameras[1].rect = new Rect(0.501f,  0.498f, 0.499f, 1);
            cameras[2].rect = new Rect(0,       0,      0.499f, 0.492f);
            cameras[3].rect = new Rect(0.501f,  0,      0.499f, 0.492f);

        }

        // Make the cameras follow the players
        for (int i = 1; i < camFollows.Count + 1; i++)
        {
            string player = "Player" + i.ToString();

            if (player == "Player1")
            {
                player = "Player";
                camFollows[0].target = GameObject.FindGameObjectWithTag(player).transform;

            }
            else 
                camFollows[i - 1].target = GameObject.FindGameObjectWithTag(player).transform;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
