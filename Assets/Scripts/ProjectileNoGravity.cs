﻿using UnityEngine;
using System.Collections;

public class ProjectileNoGravity : Projectile
{
    new void Awake() { base.Awake(); }

    new void Start() { base.Start(); }

	new void FixedUpdate()
    {
        RegisterHit();
        base.FixedUpdate();
    }

    void RegisterHit()
    {
        ImplementationManagers.CombatManagement.OperateWeaponDischarge( transform.gameObject, RootObject.GetComponent<WeaponDetails>().Stats );
    }
}