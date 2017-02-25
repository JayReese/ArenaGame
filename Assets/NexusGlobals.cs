using UnityEngine;
using System.Collections;

public enum MovementType { THREEDEG = 1, SIXDEG };
public enum DataQueryType { Abilities, Weapons };

public static class NexusGlobals
{
    // Multipurpose raycasting code.
    public static RaycastHit RaycastHitTarget(Vector3 origin, Vector3 direction, float range)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, range))
            return hit;

        return hit;
    }
}
