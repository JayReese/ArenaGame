using UnityEngine;
using System.Collections;

public class WeaponDetails : MonoBehaviour
{
    public WeaponStats Stats;
    public Transform AmmoPool, Emitter;

    void Awake()
    {
        Stats = new WeaponStats(gameObject.name);
        Emitter = transform.FindChild("Emitter");
        GenerateObjectPool();
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

    void GenerateObjectPool()
    {
        AmmoPool = transform.FindChild("Ammo Pool");

        if(Stats.FiringType == FireType.Projectile)
        {
            for(byte i = 0; i < Stats.MaxMagazineSize; i++)
            {
                GameObject o = Instantiate(Stats.TetheredProjectile, AmmoPool) as GameObject;
                o.GetComponent<Projectile>().RootObject = o.transform.parent;
                o.SetActive(false);
            }
        }


    }
}
