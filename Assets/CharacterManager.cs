using UnityEngine;
using System.Collections;
using System;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] GameObject[] Players;

	// Use this for initialization
	void Start ()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");

        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    for(int i = 0; i < Players.Length; i++)
        {
            if (!Players[i].GetComponent<PlayerMovement>())
                CorrectCharacter(Players[i], "movement");
        }
	}

    void CorrectCharacter(GameObject player, string query)
    {
        //Debug.Log("Does not have player movement...");

        switch(query)
        {
            case "movement":
                AssignCharacterMovement(player);
                break;
        }
    }

    private void AssignCharacterMovement(GameObject player)
    {
        if (player.GetComponent<Player>().Movement == MovementType.THREEDEG)
            player.AddComponent<PlayerMovement>();
    }
}
