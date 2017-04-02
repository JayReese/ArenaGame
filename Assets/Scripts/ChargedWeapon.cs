﻿using UnityEngine;
using System.Collections;

public class ChargedWeapon : Weapon
{
    [SerializeField] float ChargePercentage;

	// Use this for initialization
	new void Start ()
    {
        FireType = FiringType.CHARGE;

        base.Start();
	}
	
	// Update is called once per frame
	new void Update ()
    {
        WeaponInUse = Input.GetMouseButtonUp(0);

        if (Input.GetMouseButton(0) && ChargePercentage < 1)
            ChargePercentage += Time.deltaTime * Stats.FireRate;

        base.Update();

        if (WeaponInUse)
            ChargePercentage = 0;
	}
}