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
        WeaponInUse = Input.GetMouseButtonDown(0);
        base.Update();
    }
}
