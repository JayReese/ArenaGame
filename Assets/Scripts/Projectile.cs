using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
    public Transform RootObject;
    [SerializeField] protected float Speed, Lifetime;

    protected void Awake()
    {
        Lifetime = 10f;
        Speed = 50f;
    }

    protected void Start()
    {
        
        transform.position = RootObject.FindChild("Emitter").position;

        // Looks to center of screen.
        transform.LookAt(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100)));

        gameObject.GetComponent<Rigidbody>().AddForce( transform.forward * Speed, ForceMode.Impulse );
    }

    protected void OnEnable()
    {
        transform.parent = null;
    }

    protected void OnDisable()
    {
        transform.parent = RootObject;
    }
        
    protected void FixedUpdate()
    {
        Lifetime -= Time.fixedDeltaTime;

        if (Lifetime <= 0)
            ImplementationManagers.CombatManagement.SetExtantPhysicsObjectInactive(gameObject);
    }
}
