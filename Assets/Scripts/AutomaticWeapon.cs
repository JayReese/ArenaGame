using UnityEngine;
using System.Collections;

public class AutomaticWeapon : WeaponInterface
{

	// Use this for initialization
	new void Start ()
    {
        base.Start();
    }
	
	// Update is called once per frame
	new void Update ()
    {
        WeaponInUse = Input.GetMouseButton(0);
        base.Update();
    }
}
