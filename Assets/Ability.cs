﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ability : MonoBehaviour
{

    Vector3 FireDirection;
    [SerializeField] int Strength, Range, Duration, Cooldown;
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
            Destroy(gameObject);
    }

    void Move()
    {
        transform.position += FireDirection * Time.deltaTime * 40f;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Wall")
            Debug.Log("Well then.");

        Destroy(gameObject);
    }
}
