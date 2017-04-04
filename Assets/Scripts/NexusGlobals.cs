using UnityEngine;
using System.Collections;

/*
 * PUBLIC ENUMS, SEPARATED FROM OTHER PIECES OF CODE TO BE USED.
 */
public enum MovementType { THREEDEG = 1, SIXDEG };

public enum DataQueryType { Abilities, Weapons };

public enum AbilityMobility { Projectile = 1, Deployable };
public enum AbilityTarget { Self = 1, Enemy };

public enum TriggerType { SemiAuto = 1, Auto, Charge };
public enum FireType { Hitscan = 1, Projectile };

//public enum EffectOperation { AOE = 1, EnemyStagger };

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
