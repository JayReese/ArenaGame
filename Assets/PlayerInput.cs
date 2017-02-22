using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour
{

    CombatManager CombatManage;
    PlayerMovement MovementReference;
    Player PlayerReference;

    bool AbilityUse;

	// Use this for initialization
	void Start ()
    {
        CombatManage = GameObject.FindGameObjectWithTag("Managers").GetComponent<CombatManager>();
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
            Instantiate(PlayerReference.TestAbility, PlayerReference.AbilityProjectileEmitterPos, Quaternion.identity);
    }

    private void BindCombatBooleans()
    {
        AbilityUse = Input.GetKeyDown(KeyCode.Q);
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(0))
            CombatManage.EvaluateShot(25);
    }

    void BindMovementBooleans()
    {
        MovementReference.Sprinting = Input.GetKey(KeyCode.LeftShift);
        GetComponent<Animator>().SetBool("Sprinting", MovementReference.Sprinting);
    }

    void CreateAxisOrientation()
    {
        MovementReference.VerticalMovement = Input.GetAxisRaw("Vertical");
        GetComponent<Animator>().SetFloat("VerticalMove", MovementReference.VerticalMovement);

        MovementReference.HorizontalMovement = Input.GetAxisRaw("Horizontal");
        GetComponent<Animator>().SetFloat("HorizontalMove", MovementReference.HorizontalMovement);
    }
}
