using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
    public Transform RootObject;
    [SerializeField] protected float Speed;

    protected void Awake()
    {
        
        Speed = 50f;
    }

    protected void Start()
    {
        transform.LookAt(new Vector3(0, transform.position.y, transform.position.z));

        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Speed, ForceMode.Impulse);
    }   
        
    protected void FixedUpdate()
    {

    }
}
