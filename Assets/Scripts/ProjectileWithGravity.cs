using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]

public class ProjectileWithGravity : Projectile
{
	new void Start() { base.Start(); }

    new void FixedUpdate() { base.FixedUpdate(); }

    void OnTriggerEnter(Collider col)
    {
        if (col)
            ImplementationManagers.CombatManagement.ReportCollision(col, gameObject, RootObject);
    }
}
