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
    }

    void Move()
    {
        transform.position += (Camera.main.transform.forward * VerticalMovement) * Time.fixedDeltaTime * MovementSpeed;
    }

    public void Orient(float camHorizontalMove, float camSens)
    {
        //if(VerticalMovement > 0)
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y + 90, transform.localEulerAngles.z);

        ////if (transform.rotation.y >= 178)
        ////    transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.z);

        //transform.rotation = camRot;

        transform.Rotate(transform.rotation.x, camHorizontalMove * (Time.fixedDeltaTime * camSens) * 10, transform.rotation.z);
    }

    void CreateAxisOrientation()
    {
        VerticalMovement = Input.GetAxisRaw("Vertical");
        GetComponent<Animator>().SetFloat("VerticalMove", VerticalMovement);

        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        GetComponent<Animator>().SetFloat("HorizontalMove", HorizontalMovement);
    }

    
}
