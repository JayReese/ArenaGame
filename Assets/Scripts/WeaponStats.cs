using UnityEngine;
using System;
using System.Collections;

public class WeaponStats
{
    public string WeaponName;

    public FireType FiringType { get; private set; }
    public TriggerType Trigger { get; private set; }

    public GameObject TetheredProjectile { get; private set; }

    public int CurrentMagazineSize;
    public int MaxMagazineSize { get; private set; }

    public int Damage { get; private set; }

    public float FireRate { get; private set; }
    public float FireRateModifier { get; private set; }

    public float EffectiveRange { get; private set; }

    public float ReloadSpeed { get; private set; }

    public WeaponStats(string name)
    {
        WeaponName = name;

        TetheredProjectile = Resources.Load("Prefabs/" + DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "Projectiles", "Utility").ToString()) as GameObject;

        FiringType = (FireType)Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "FireType", "Utility"));
        Trigger = (TriggerType)Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "TriggerType", "Utility"));

        MaxMagazineSize = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "MagazineSize", "Stats"));
        CurrentMagazineSize = MaxMagazineSize;

        Damage = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "Damage", "Stats"));

        FireRate = Convert.ToSingle(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "FireRate", "Stats"));
        ReloadSpeed = Convert.ToSingle(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "ReloadSpeed", "Stats"));

        EffectiveRange = Convert.ToSingle(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "EffectiveRange", "Stats"));
    }

    float GiveFireRateModifier()
    {
        if(Trigger == TriggerType.Charge)
           return 0.5f;

        return 1.0f;
    }
}