using UnityEngine;
using System.Collections;

public class CombatManager
{
    
    [SerializeField] int testReportedDamage = 500;

    public CombatManager()
    {
        
    }

    // For raycasted shots, with origin set at the camera.
    public void EvaluateShot(float range)
    {
        RaycastHit hit = NexusGlobals.RaycastHitTarget(Camera.main.transform.position, Camera.main.transform.forward, range);

        if (hit.collider != null)
            SendHitInformation(hit);
    }

    // For raycasted shots, implemeneted from an origin distinct from the camera.
    public void EvaluateShot(float range, Transform originTransform)
    {
        RaycastHit hit = NexusGlobals.RaycastHitTarget(originTransform.position, originTransform.forward, range);

        if (hit.collider != null)
        {
            SendHitInformation(hit);
            
            if(originTransform.tag == "Projectile")
                MonoBehaviour.Destroy(originTransform.gameObject);
        } 
    }

    public void EvaluateCollision(Collider c, Transform objectTransform)
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

    private RaycastHit RaycastHitTarget(float range)
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            return hit;

        return hit;
    }
}
