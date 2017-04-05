using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]

public class ProjectileWithGravity : Projectile
{
	new void Start() { base.Start(); }

    new void FixedUpdate() { base.FixedUpdate(); }

    new void OnEnable() { base.OnEnable(); }

    new void OnDisable() { base.OnDisable(); }

    void OnTriggerEnter(Collider col)
    {
        if (col)
            ImplementationManagers.CombatManagement.ReportCollision( col, gameObject, RootObject );
    }
}
