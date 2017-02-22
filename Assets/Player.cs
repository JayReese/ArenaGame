﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public GameObject TestAbility;
    public Vector3 AbilityProjectileEmitterPos;

    public MovementType Movement;

	// Use this for initialization
	void Start ()
    {
        Movement = MovementType.THREEDEG;

        for (int i = 0; i < transform.FindChild("IdentifierCubes").childCount; i++)
            transform.FindChild("IdentifierCubes").GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0.4f, 1f);

        TestAbility = Resources.Load("Abilities/TestAbility") as GameObject;

        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "A_Projectile Emitter")
                AbilityProjectileEmitterPos = transform.GetChild(i).localPosition;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
