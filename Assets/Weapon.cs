using UnityEngine;
using System.Collections;
using System;

public abstract class Weapon : MonoBehaviour
{
    protected enum FiringType { NONE, SEMIAUTO, AUTO, CHARGE };
    [SerializeField] protected FiringType FireType; 
    [SerializeField] protected bool WeaponInUse, IsReloading;
    [SerializeField] protected float NextFireTime, FireRateModifier;
    [SerializeField] protected WeaponStats Stats;

	// Use this for initialization
	protected void Start ()
    {
        Stats = new WeaponStats();

        if (FireType == FiringType.CHARGE)
            FireRateModifier = 0.5f;
        else
            FireRateModifier = 1;

        NextFireTime = 1;  
	}
	
	// Update is called once per frame
	protected void Update ()
    {
        if (WeaponInUse && NextFireTime <= 0 && !IsReloading)
            Use();
        if ((Stats.CurrentMagazineSize == 0 || Input.GetKeyDown(KeyCode.R)) && Stats.CurrentMagazineSize < Stats.MaxMagazineSize && !IsReloading)
            StartCoroutine(Reload());
    }

    // Called every fixed timestep.
    protected void FixedUpdate ()
    {
        if (FireType != FiringType.CHARGE)
            DecrementNextFire();
        else
            NextFireTime = 0;
    }

    void Use ()
    {
        PerformWeaponOperations();
        RefreshNextFire();
    }

    void DecrementNextFire ()
    {
        if (NextFireTime > 0)
            NextFireTime -= Time.fixedDeltaTime * Stats.FireRate;
    }

    void RefreshNextFire() { NextFireTime = 1; }

    void PerformWeaponOperations ()
    {
        if (Stats.CurrentMagazineSize != 0)
            Stats.CurrentMagazineSize--;

        Debug.Log(string.Format("Current Magazine: {0}", Stats.CurrentMagazineSize));
    }

    private IEnumerator Reload ()
    {
        IsReloading = true;

        yield return new WaitForSeconds(1.0f);     
        Stats.CurrentMagazineSize = Stats.MaxMagazineSize;

        IsReloading = false;
    }
}