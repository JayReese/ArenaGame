using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour
{

    Vector3 FireDirection;
    float Strength, Range, Duration, Cooldown;

	// Use this for initialization
	void Start ()
    {
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        FireDirection = Camera.main.transform.forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += FireDirection * Time.deltaTime * 30f;
	}
}
