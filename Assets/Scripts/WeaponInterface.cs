using UnityEngine;
using System.Collections;
using System;

public abstract class WeaponInterface : MonoBehaviour
{
    [SerializeField]
    public bool WeaponInUse { get; protected set; }
    [SerializeField] protected bool IsReloading;
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
        if ((Details.Stats.CurrentMagazineSize == 0 || Input.GetKeyDown(KeyCode.R)) && Details.Stats.CurrentMagazineSize < Details.Stats.MaxMagazineSize && !IsReloading)
            Reload();
    }

    // Called every fixed timestep.
    protected void FixedUpdate ()
    {
        if (Details.Stats.Trigger != TriggerType.Charge)
            DecrementNextFire();
        else
            NextFireTime = 0;
    }

    public void Use ()
    {   
        if (NextFireTime <= 0 && !IsReloading)
        {
            PerformWeaponOperations();
            RefreshNextFire();
        }
    }

    void DecrementNextFire ()
    {
        if (NextFireTime > 0)
            NextFireTime -= Time.fixedDeltaTime * Details.Stats.FireRate;
    }

    void RefreshNextFire() { NextFireTime = 1; }

    void PerformWeaponOperations()
    {
        ImplementationManagers.CombatManagement.OperateWeaponDischarge( gameObject, Details.Stats );

        if (Details.Stats.CurrentMagazineSize != 0)
            Details.Stats.CurrentMagazineSize--;
    }

    public void Reload() { StartCoroutine(PerformReload()); }

    private IEnumerator PerformReload ()
    {
        IsReloading = true;

        yield return new WaitForSeconds(1.0f);
        Details.Stats.CurrentMagazineSize = Details.Stats.MaxMagazineSize;

        IsReloading = false;
    }
}