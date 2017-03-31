using UnityEngine;
using System.Collections;

public class ProjectileNoGravity : Projectile
{
    new void Awake() { base.Awake(); }

    new void Start() { base.Start(); }

	new void FixedUpdate()
    {
        RaycastHit h = NexusGlobals.RaycastHitTarget(transform.position, transform.forward, 2f);

        if (h.collider != null)
            RegisterHit(h);
    }

    void RegisterHit(RaycastHit hitinfo)
    {

    }
}
