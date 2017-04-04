using UnityEngine;
using System.Collections;
using System;

public class CombatManager
{
    
    [SerializeField] int testReportedDamage = 500;

    public CombatManager()
    {
        
    }

    public void OperateWeaponDischarge(FireType ft, GameObject g, float range = 0f)
    {
        if (ft == FireType.Hitscan)
        {
            if (range != 0)
                EvaluateShot(range);
            else
                EvaluateShot(2f, g.transform);
        }  
        else
            SpawnProjectile(g);
    }

    private void SpawnProjectile(GameObject g)
    {
        UnityEngine.Object.Instantiate( g.GetComponent<WeaponDetails>().Stats.TetheredProjectile, g.transform.FindChild("Emitter").position, Quaternion.identity );
    }

    public void ReportCollision(Collider c, Transform objectTrans)
    {
        EvaluateCollision(c, objectTrans);
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
            
            if(originTransform.tag == "Projectile")
                MonoBehaviour.Destroy(originTransform.gameObject);
        } 
    }

    private void EvaluateCollision(Collider c, Transform objectTransform)
    {
        SendHitInformation(c);
        MonoBehaviour.Destroy(objectTransform.gameObject);
    }
    
    private void SendHitInformation(RaycastHit hit)
    {
        switch(hit.collider.tag.ToLower())
        {
            case "wall":
                ImplementationManagers.UIManagement.GiveDamageReport(hit, testReportedDamage);
                break;
        }
    }

    private void SendHitInformation(Collider hit)
    {
        switch (hit.tag.ToLower())
        {
            case "wall":
                ImplementationManagers.UIManagement.GiveDamageReport(hit, testReportedDamage);
                break;
        }
    }
}
