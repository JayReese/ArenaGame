using UnityEngine;
using System.Collections;
using System;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] bool PlayersSpawned;
    [SerializeField] GameObject[] Players;
    AbilityExecution AbilityExecutor;

	// Use this for initialization
	void Start ()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log(DatabaseManager.ReturnQueriedData(DataQueryType.Abilities, "Test Ability", "Strength", "Stats").ToString());
	}

    private void SpawnPlayer()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            for (int a = 0; a < 2; a++)
                CorrectCharacter(Players[i], a);
        }
            
        PlayersSpawned = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!PlayersSpawned)
            SpawnPlayer();
	}

    void CorrectCharacter(GameObject player, int query)
    {
        switch(query)
        {
            case 0:
                AssignCharacterMovement(player);
                break;
            case 1:
                AssignCharacterInput(player);
                break;
        }
    }

    private void AssignCharacterInput(GameObject player)
    {
        player.AddComponent<PlayerInput>();
    }

    private void AssignCharacterMovement(GameObject player)
    {
        if (player.GetComponent<Player>().Movement == MovementType.THREEDEG)
            player.AddComponent<PlayerMovement>();
    }
}
