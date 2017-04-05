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
                EvaluateShot(range, g.GetComponent<WeaponDetails>().);
            else
                EvaluateShot(2f, g.transform);
        }  
        else
            SpawnProjectile(g);
    }

    public void DestroyExtantPhysicsObject(GameObject g)
    {
        Debug.Log("Visual effect goes here.");
        MonoBehaviour.Destroy(g);
    }

    private void SpawnProjectile(GameObject g)
    {
        GameObject proj = g.GetComponent<WeaponDetails>().Stats.TetheredProjectile;
        proj.GetComponent<Projectile>().RootObject = g.transform;

        UnityEngine.Object.Instantiate( proj, g.transform.FindChild("Emitter").position, Quaternion.identity );
    }

    public void ReportCollision(Collider c, GameObject currentObj, Transform objectTrans)
    {
        EvaluateCollision(c, objectTrans, currentObj);
    }

    // For raycasted shots, with origin set at the camera.
    private void EvaluateShot(float range, WeaponStats g)
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
                DestroyExtantPhysicsObject(originTransform.gameObject);
        } 
    }

    private void EvaluateCollision(Collider c, Transform objectTransform, GameObject rootObj)
    {
        Debug.Log("Collision happens");
        SendHitInformation(c);
        DestroyExtantPhysicsObject(objectTransform.gameObject);
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
