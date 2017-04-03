using UnityEngine;
using System.Collections;

public class WeaponStats
{
    public FireType FiringType;
    public TriggerType Trigger;
    public int CurrentMagazineSize, MaxMagazineSize, Damage;
    public float FireRate, ReloadSpeed;

    public WeaponStats()
    {
        MaxMagazineSize = 40;
        CurrentMagazineSize = MaxMagazineSize;
        FireRate = 25.0f;
        ReloadSpeed = 0.5f;
    }
}