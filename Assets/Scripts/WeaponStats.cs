using UnityEngine;
using System;
using System.Collections;

public class WeaponStats
{
    public string WeaponName;

    public FireType FiringType { get; private set; }
    public TriggerType Trigger { get; private set; }

    public int CurrentMagazineSize;
    public int MaxMagazineSize { get; private set; }

    public int Damage { get; private set; }

    public float FireRate { get; private set; }
    public float ReloadSpeed { get; private set; }

    public WeaponStats(string name)
    {
        WeaponName = name;

        FiringType = (FireType)Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "FireType", "Utility"));
        Trigger = (TriggerType)Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "TriggerType", "Utility"));

        MaxMagazineSize = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "MagazineSize", "Stats"));

        CurrentMagazineSize = MaxMagazineSize;

        FireRate = (float)DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "FireRate", "Stats");
        ReloadSpeed = (float)DatabaseManager.ReturnQueriedData(DataQueryType.Weapons, WeaponName, "ReloadSpeed", "Stats");
    }

    void Report()
    {
        Debug.Log(string.Format("{0}: {1}", WeaponName, FireRate));
    }
}