using UnityEngine;
using System.Collections;
using System;

public abstract class WeaponInterface : MonoBehaviour
{
    [SerializeField] protected bool WeaponInUse, IsReloading, WeaponActive;
    [SerializeField] protected float NextFireTime, FireRateModifier;
    [SerializeField] protected Transform PlayerTransform;
    [SerializeField] protected WeaponDetails Details;

	// Use this for initialization
	protected void Start ()
    {
        Details = GetComponent<WeaponDetails>();

        if (Details.Stats.Trigger == TriggerType.Charge)
            FireRateModifier = 0.5f;
        else
            FireRateModifier = 1;

        NextFireTime = 1;

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	protected void Update ()
    {
        if (WeaponInUse && NextFireTime <= 0 && !IsReloading && WeaponActive)
            Use();
        if ((Details.Stats.CurrentMagazineSize == 0 || Input.GetKeyDown(KeyCode.R)) && Details.Stats.CurrentMagazineSize < Details.Stats.MaxMagazineSize && !IsReloading)
            StartCoroutine(Reload());
    }

    // Called every fixed timestep.
    protected void FixedUpdate ()
    {
        if (Details.Stats.Trigger != TriggerType.Charge)
            DecrementNextFire();
        else
            NextFireTime = 0;

        transform.RotateAround(PlayerTransform.position, transform.up, 10);
    }

    void Use ()
    {
        PerformWeaponOperations();
        RefreshNextFire();
    }

    void DecrementNextFire ()
    {
        if (NextFireTime > 0)
            NextFireTime -= Time.fixedDeltaTime * Details.Stats.FireRate;
    }

    void RefreshNextFire() { NextFireTime = 1; }

    void PerformWeaponOperations ()
    {
        if (Details.Stats.CurrentMagazineSize != 0)
            Details.Stats.CurrentMagazineSize--;

        Debug.Log(string.Format("Current Magazine: {0}", Details.Stats.CurrentMagazineSize));
    }

    private IEnumerator Reload ()
    {
        IsReloading = true;

        yield return new WaitForSeconds(1.0f);
        Details.Stats.CurrentMagazineSize = Details.Stats.MaxMagazineSize;

        IsReloading = false;
    }
}