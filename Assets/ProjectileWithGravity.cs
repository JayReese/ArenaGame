using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]

public class ProjectileWithGravity : Projectile
{
	new void Start()
    {
        base.Start();
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, Speed, ForceMode.Impulse);
    }

    new void FixedUpdate()
    {
        
    }
}
