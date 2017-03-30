using UnityEngine;
using System.Collections;

public class ProjectileNoGravity : Projectile
{
	new void FixedUpdate()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * Speed;
    }
}
