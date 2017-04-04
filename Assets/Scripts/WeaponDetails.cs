using UnityEngine;
using System.Collections;

public class WeaponDetails : MonoBehaviour
{
    public WeaponStats Stats;

    void Awake()
    {
        Stats = new WeaponStats(gameObject.name);
        
    }

	// Use this for initialization
	void Start ()
    {
        ImplementationManagers.CharacterManagement.AssignWeaponInterface( gameObject );
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
