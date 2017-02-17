using UnityEngine;
using System.Collections;

public class SemiAutomaticWeapon : Weapon
{
	// Use this for initialization
	new void Start ()
    {
        FireType = FiringType.SEMIAUTO;

        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        WeaponInUse = Input.GetMouseButtonDown(0);
        base.Update();
    }
}
