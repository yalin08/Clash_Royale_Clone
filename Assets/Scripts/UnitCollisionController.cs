using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class UnitCollisionController : MonoBehaviour
{

    UnitStats stats;

    SphereCollider collider;

    bool canAttackAir;

    public PawnAI LastSeenPawn;

    private void OnValidate()
    {
        stats = GetComponent<UnitStats>();
        collider = GetComponent<SphereCollider>();
        collider.radius = stats.stat.sightRange;
        canAttackAir = stats.stat.canAttackAir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Pawn"))
        {
            PawnAI enemyAI = other.GetComponent<PawnAI>();
            if (stats.faction == enemyAI.stats.faction)
                return;
            if (canAttackAir)
            {
                LastSeenPawn = enemyAI;
            }
            if (!canAttackAir)
                if (!enemyAI.stats.stat.AirUnit)
                {
                    LastSeenPawn = enemyAI;
                }
        }
    }


}
