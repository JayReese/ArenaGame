using UnityEngine;
using System.Collections;
using System;

public class CombatManager
{
    
    [SerializeField] int testReportedDamage = 500;
    [SerializeField] WeaponStats StatsToReference;


    public CombatManager()
    {
        
    }

    public void OperateWeaponDischarge(GameObject g, WeaponStats wepStats)
    {
        float range = wepStats.FiringType == FireType.Hitscan ? wepStats.EffectiveRange : 0f;
        StatsToReference = wepStats;

        if (wepStats.FiringType == FireType.Hitscan)
        {
            if (range != 0)
                EvaluateShot(range);
            else
                EvaluateShot(2f, g.transform);
        }  
        else
            SpawnProjectile(g);
    }

    public void SetExtantPhysicsObjectInactive(GameObject g)
    {
        Debug.Log("Visual effect goes here.");
        g.SetActive(false);
    }

    private void SpawnProjectile(GameObject g)
    {
        g.GetComponent<WeaponDetails>().AmmoPool.GetChild(StatsToReference.CurrentMagazineSize - 1).gameObject.SetActive(true);
    }

    // Gets the collider, the current object that checked for the collision, and the root object that the projectile came from.
    public void ReportCollision(Collider c, GameObject currentObj, Transform rootTransOrigin)
    {
        //EvaluateCollision(c, objectTrans, currentObj);

        EvaluateCollision(c, currentObj, rootTransOrigin.gameObject);
    }

    // For raycasted shots, with origin set at the camera.
    private void EvaluateShot(float range)
    {
        RaycastHit hit = NexusGlobals.RaycastHitTarget(Camera.main.transform.position, Camera.main.transform.forward, range);

        if (hit.collider != null)
            SendHitInformation(hit);
    }

    
    // For raycasted shots, implemeneted from an origin distinct from the camera.
    private void EvaluateShot(float range, Transform originTransform)
    {
        RaycastHit hit = NexusGlobals.RaycastHitTarget(originTransform.position, originTransform.forward, range);

        if (hit.collider != null)
        {
            SendHitInformation(hit);

            if (originTransform.tag == "Projectile")
                SetExtantPhysicsObjectInactive(originTransform.gameObject);
        } 
    }

    private void EvaluateCollision(Collider c, GameObject evaluatedProjectile, GameObject rootObj)
    {
        SendHitInformation(c);
        SetExtantPhysicsObjectInactive(evaluatedProjectile);
    }
    
    private void SendHitInformation(RaycastHit hit)
    {
        switch(hit.collider.tag.ToLower())
        {
            case "wall":
                ImplementationManagers.UIManagement.GiveDamageReport(hit, StatsToReference.Damage);
                break;
        }
    }

    private void SendHitInformation(Collider hit)
    {
        switch (hit.tag.ToLower())
        {
            case "wall":
                ImplementationManagers.UIManagement.GiveDamageReport(hit, StatsToReference.Damage);
                break;
        }
    }
}
