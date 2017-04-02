using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour
{
    //ImplementationManagerNexus IMNexus;
    PlayerMovement MovementReference;
    Player PlayerReference;
    ControlScheme Controls;

    bool AbilityUse;

	// Use this for initialization
	void Start ()
    {
        //CombatManage = GameObject.FindGameObjectWithTag("Managers").GetComponent<CombatManager>();
        //IMNexus = new ImplementationManagerNexus();
        MovementReference = GetComponent<PlayerMovement>();
        PlayerReference = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Continuously checks and maintains binding and orientations.
        BindMovementBooleans();
        BindCombatBooleans();
        CreateAxisOrientation();

        // Maintains combat parameters.
        Fire();
        UseAbility();
    }

    private void UseAbility()
    {
        if(AbilityUse)
            Instantiate(PlayerReference.TestAbility, PlayerReference.AbilityProjectileEmitter.transform.position, Quaternion.identity);
    }

    private void BindCombatBooleans()
    {
        AbilityUse = Input.GetKeyDown(KeyCode.Q);
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(0))
            ImplementationManagers.CombatManagement.EvaluateShot(25);
    }

    void BindMovementBooleans()
    {
        MovementReference.Sprinting = Input.GetKey(KeyCode.LeftShift);
        if(GetComponent<Animator>()) GetComponent<Animator>().SetBool("Sprinting", MovementReference.Sprinting);
    }

    void CreateAxisOrientation()
    {
        MovementReference.VerticalMovement = Input.GetAxisRaw("Vertical");
        if(GetComponent<Animator>()) GetComponent<Animator>().SetFloat("VerticalMove", MovementReference.VerticalMovement);

        MovementReference.HorizontalMovement = Input.GetAxisRaw("Horizontal");
        if(GetComponent<Animator>()) GetComponent<Animator>().SetFloat("HorizontalMove", MovementReference.HorizontalMovement);
    }
}
