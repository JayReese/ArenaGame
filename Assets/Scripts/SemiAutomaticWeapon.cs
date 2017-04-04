using UnityEngine;
using System.Collections;

public class SemiAutomaticWeapon : WeaponInterface
{
	// Use this for initialization
	new void Start ()
    {
        WeaponInUse = true;

        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        WeaponInUse = Input.GetMouseButtonDown((int)ControlScheme.PrimaryFire);
        base.Update();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
