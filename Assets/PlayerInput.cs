using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    DisplayDamage ReportDamage;

	// Use this for initialization
	void Start ()
    {
	        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Fire();

        Debug.Log(Input.mousePosition); 
    }

    public void Fire()
    {
        if (Input.GetMouseButtonDown(0))
            EvaluateShot();
    }

    private void EvaluateShot()
    {
        Debug.Log("Shooting");

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit))
            ReportDamage(50);
    }
}
