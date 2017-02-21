using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    UIManager InterfaceManager;

	// Use this for initialization
	void Start ()
    {
        InterfaceManager = GetComponent<UIManager>();    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void EvaluateShot(float range)
    {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit = RaycastHitTarget(range);

        if (hit.collider != null)
            SendHitInformation(hit, mousePos);
    }
    
    private void SendHitInformation(RaycastHit hit, Vector3 mousePos)
    {
        int reportedDamage = 500;

        switch(hit.collider.tag.ToLower())
        {
            case "wall":
                InterfaceManager.GiveDamageReport(hit, reportedDamage);
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
