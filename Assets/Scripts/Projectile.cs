using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected void Awake()
    {
        Speed = 50f;
    }

    protected void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Speed, ForceMode.Impulse);
    }   

    protected void FixedUpdate()
    {

    }

    
}
