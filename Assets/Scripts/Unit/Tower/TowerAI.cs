using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class TowerAI : MonoBehaviour
{
    [HideInInspector] public UnitStats stats;
    Factions enemyFaction;
    public UnitShooter shooter;
    public List<PawnAI> EnemyPawns;
    private void Awake()
    {
        stats = GetComponent<UnitStats>();

        enemyFaction = PawnManager.Instance.EnemyFaction(stats.faction);
        shooter = GetComponent<UnitShooter>();

        if (enemyFaction == Factions.Blue)

            EnemyPawns = PawnManager.Instance.bluePawns;

        if (enemyFaction == Factions.Red)

            EnemyPawns = PawnManager.Instance.redPawns;
    }
    void Update()
    {
        if (EnemyPawns.Count == 0)
            return;
        shooter.target = FindClosestPawn().transform;
    }
    public PawnAI FindClosestPawn()
    {

        PawnAI closestEnemy = EnemyPawns[0];
        float closestDistance = Mathf.Infinity;

        foreach (PawnAI towers in EnemyPawns)
        {
            float distance = Vector3.Distance(towers.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = towers;
            }
        }

        return closestEnemy;

    }

    private void OnDestroy()
    {
        if (stats.faction == Factions.Blue)
            TowersManager.Instance.BlueTowers.Remove(this);
        if (stats.faction == Factions.Red)
            TowersManager.Instance.RedTowers.Remove(this);
    }
}
