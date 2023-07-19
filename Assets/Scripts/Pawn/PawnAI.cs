using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAI : MonoBehaviour
{
    [HideInInspector] public UnitStats stats;
    PawnMove move;

    public UnitShooter shooter;
    List<TowerAI> EnemyTowers;
    private void Awake()
    {
        stats = GetComponent<UnitStats>();
        move = GetComponent<PawnMove>();
      
        shooter = GetComponent<UnitShooter>();

      
    }
    private void Start()
    {
        if (stats.enemyFaction == Factions.Blue)

            EnemyTowers = TowersManager.Instance.BlueTowers;

        if (stats.enemyFaction == Factions.Red)

            EnemyTowers = TowersManager.Instance.RedTowers;
    }

    private void Update()
    {
        move.target = FindClosestTower().transform;
        shooter.target = move.target;

    }
    public TowerAI FindClosestTower()
    {
        if (EnemyTowers.Count == 0)
            return null;

        TowerAI closestTower = EnemyTowers[0];
        float closestDistance = Mathf.Infinity;

        foreach (TowerAI towers in EnemyTowers)
        {
            float distance = Vector3.Distance(towers.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTower = towers;
            }
        }

        return closestTower;

    }


    private void OnDestroy()
    {
        if (stats.faction == Factions.Blue)
            PawnManager.Instance.bluePawns.Remove(this);
        if (stats.faction == Factions.Red)
            PawnManager.Instance.redPawns.Remove(this);
    }

}
