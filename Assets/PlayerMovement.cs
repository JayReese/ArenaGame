using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float VerticalMovement, HorizontalMovement;
    [SerializeField] float MovementSpeed, SprintModifier;
    [SerializeField] Vector3 MovementDirection;
    [SerializeField] Quaternion HorizontalRotation;
    public bool Sprinting;


	// Use this for initialization
	void Start ()
    {
        MovementSpeed = 0.8f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void FixedUpdate()
    {
        CorrectSprintModifier();
        Move();
    }

    private void CorrectSprintModifier()
    {
        SprintModifier = Sprinting ? 3.0f : 1.0f; // Yay, ternary operators! <3
    }

    void Move()
    {
        transform.position += (Camera.main.transform.forward * VerticalMovement) * Time.fixedDeltaTime * (MovementSpeed * SprintModifier);
    }

    public void Orient(float camHorizontalMove, float camSens)
    {
        transform.Rotate(transform.rotation.x, camHorizontalMove * (Time.fixedDeltaTime * camSens) * 40, transform.rotation.z);
    }
}
