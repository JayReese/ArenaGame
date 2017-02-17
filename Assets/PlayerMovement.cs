using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float VerticalMovement, HorizontalMovement,
                           MovementSpeed, CurrentHorizontalRotation, NextHorizontalRotation;
    [SerializeField] Vector3 MovementDirection;
    [SerializeField] Quaternion HorizontalRotation;


	// Use this for initialization
	void Start ()
    {
        MovementSpeed = 0.8f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CreateAxisOrientation();

        
    }

    void FixedUpdate()
    {

        Move();
        OrientCharacter();
    }

    void Move()
    {
        transform.position += (Camera.main.transform.forward * VerticalMovement) * Time.fixedDeltaTime * MovementSpeed;
    }

    private void OrientCharacter()
    {
        if(VerticalMovement > 0)
            transform.rotation = new Quaternion(transform.rotation.x, Camera.main.transform.rotation.y, transform.rotation.z, transform.rotation.w);

        //if (transform.rotation.y >= 178)
        //    transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.z);
    }

    void CreateAxisOrientation()
    {
        VerticalMovement = Input.GetAxisRaw("Vertical");
        GetComponent<Animator>().SetFloat("VerticalMove", VerticalMovement);

        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        GetComponent<Animator>().SetFloat("HorizontalMove", HorizontalMovement);
    }

    
}
