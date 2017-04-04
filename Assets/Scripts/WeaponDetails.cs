using UnityEngine;
using System.Collections;

public class WeaponDetails : MonoBehaviour
{
    public WeaponStats Stats;

    void Awake()
    {
        Stats = new WeaponStats(gameObject.name);
        //ImplementationManagers.CharacterManagement
    }

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
