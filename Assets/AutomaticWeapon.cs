using UnityEngine;
using System.Collections;

public class AutomaticWeapon : Weapon
{

	// Use this for initialization
	new void Start ()
    {
        FireType = FiringType.AUTO;

        base.Start();
    }
	
	// Update is called once per frame
	new void Update ()
    {
        WeaponInUse = Input.GetMouseButton(0);
        base.Update();
    }
}
