using UnityEngine;
using System.Collections;

public class ProjectileNoGravity : Projectile
{
    new void Awake() { base.Awake(); }

    new void Start() { base.Start(); }

	new void FixedUpdate()
    {
        RegisterHit();
    }

    void RegisterHit()
    {
        ImplementationManagers.CombatManagement.EvaluateShot(2, transform);
    }
}