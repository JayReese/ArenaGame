using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Ability : MonoBehaviour
{

    Vector3 FireDirection,
        EffectReferencePositional;
    public string Name;
    public int Strength, Range, Duration, Cooldown;
    [SerializeField] float Lifetime;
    [SerializeField] List<GameObject> AbilityVisuals;

	// Use this for initialization
	void Start ()
    {
        Lifetime = 5f;
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        FireDirection = Camera.main.transform.forward;
        AbilityVisuals = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        if (Lifetime > 0)
        {
            Lifetime -= Time.deltaTime * 2f;
            Move();
        }
        else
            DestroySelf(false, 0);
    }

    void Move()
    {
        transform.position += FireDirection * Time.deltaTime * 40f;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Wall")
            Debug.Log("hit wall");

        DestroySelf(true, 1);
    }

    void DestroySelf(bool contactMade, byte destroyType = 0)
    {
        switch(destroyType)
        {
            case 1:
                EffectReferencePositional = transform.position;
                break;
        }

        if (contactMade) GenerateEffect();

        Destroy(gameObject);
    }

    private void GenerateEffect()
    {
        Instantiate(Resources.Load("Abilities/Test Ability Explosion") as GameObject, EffectReferencePositional, Quaternion.identity);
    }
}
