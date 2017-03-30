using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected void Start()
    {
        Speed = 60f;
    }

    protected void FixedUpdate()
    {

    }
}
