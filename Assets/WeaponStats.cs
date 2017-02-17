using UnityEngine;
using System.Collections;

public class WeaponStats
{
    public int CurrentMagazineSize, MaxMagazineSize;
    public float FireRate, ReloadSpeed;

    public WeaponStats()
    {
        MaxMagazineSize = 40;
        CurrentMagazineSize = MaxMagazineSize;
        FireRate = 25.0f;
        ReloadSpeed = 0.5f;
    }
}