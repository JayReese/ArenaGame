using UnityEngine;
using System.Collections;
using System;

public class CharacterManager
{

    [SerializeField] bool PlayersSpawned;
    [SerializeField] GameObject[] Players;
    AbilityExecution AbilityExecutor;

    public CharacterManager()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");

        if (!PlayersSpawned)
            SpawnPlayer();

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

    public static void AssignWeaponInterface(GameObject wep)
    {
        switch(wep.GetComponent<WeaponDetails>().Stats.Trigger)
        {
            case TriggerType.Auto:
                wep.AddComponent<AutomaticWeapon>();
                break;
            case TriggerType.SemiAuto:
                wep.AddComponent<SemiAutomaticWeapon>();
                break;
            case TriggerType.Charge:
                wep.AddComponent<ChargedWeapon>();
                break;
        }
    }

    private void AssignCharacterMovement(GameObject player)
    {
        if (player.GetComponent<Player>().Movement == MovementType.THREEDEG)
            player.AddComponent<PlayerMovement>();
    }
}
