using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour
{
    //ImplementationManagerNexus IMNexus;
    PlayerMovement MovementReference;
    Player PlayerReference;

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
        ExecuteCombatActions();
        
        //UseAbility();
    }

    // DEFUNCT FOR AT LEAST A BIT.
    private void UseAbility()
    {
        if(AbilityUse)
            Instantiate(PlayerReference.TestAbility, PlayerReference.AbilityProjectileEmitter.transform.position, Quaternion.identity);
    }

    // DEFUNCT FOR AT LEAST A BIT. MAY BE USED WHEN I NEED EQUIPMENT TO WORK.
    private void BindCombatBooleans()
    {
        //AbilityUse = Input.GetKeyDown(KeyCode.Q);
    }

    void ExecuteCombatActions()
    {
        PrimaryFire();
        ManualReload();
    }

    // The primary fire method.
    void PrimaryFire()
    {
        if(PlayerReference.ActiveWeapon.GetComponent<WeaponInterface>().WeaponInUse)
            PlayerReference.ActiveWeapon.GetComponent<WeaponInterface>().Use();
    }

    void ManualReload()
    {
        if (Input.GetKeyDown((KeyCode)ControlScheme.Reload))
            PlayerReference.ActiveWeapon.GetComponent<WeaponInterface>().Reload();
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
