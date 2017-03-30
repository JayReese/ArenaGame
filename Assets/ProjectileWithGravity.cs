using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]

public class ProjectileWithGravity : Projectile
{
	new void Start()
    {
        base.Start();
    }

    new void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }
}
