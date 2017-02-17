using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public MovementType Movement;

	// Use this for initialization
	void Start ()
    {
        Movement = MovementType.THREEDEG;

        for (int i = 0; i < transform.FindChild("IdentifierCubes").childCount; i++)
            transform.FindChild("IdentifierCubes").GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0.4f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
