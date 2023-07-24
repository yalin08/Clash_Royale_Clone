using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(SphereCollider))]
public class PawnAI : MonoBehaviour
{
    [HideInInspector] public UnitStats stats;
    PawnMove move;

    public UnitShooter shooter;

    SphereCollider collider;



    List<TowerAI> EnemyTowers;
    public PawnAI LastSeenPawn;
    private void Awake()
    {
        stats = GetComponent<UnitStats>();
        move = GetComponent<PawnMove>();

        shooter = GetComponent<UnitShooter>();
        collider = GetComponent<SphereCollider>();
        collider.radius = stats.stat.sightRange / 2;


    }
    private void Start()
    {
        if (stats.enemyFaction == Factions.Blue)
        {
            EnemyTowers = TowersManager.Instance.BlueTowers;

        }

        if (stats.enemyFaction == Factions.Red)
        {
            EnemyTowers = TowersManager.Instance.RedTowers;
        }


    }

    private void Update()
    {
        if (shooter.target == null)
        {
            if (LastSeenPawn != null &&
             Vector3.Distance(LastSeenPawn.transform.position, transform.position) < stats.stat.sightRange)
            {

                AttackEnemy();
            }

            else MoveTowardTower();
        }


    }

    void AttackEnemy()
    {
        move.target = shooter.target = LastSeenPawn.transform;


    }

    void MoveTowardTower()
    {
        move.target = FindClosestTower().transform;
        if (Vector3.Distance(move.target.position, transform.position) <= stats.stat.attackRange)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Pawn"))
        {
            PawnAI enemyAI = other.GetComponent<PawnAI>();
            if (enemyAI.stats.faction == stats.enemyFaction)
            {

                if (stats.stat.canAttackAir)
                {
                    LastSeenPawn = enemyAI;
                }

              else
                {
                    if (!enemyAI.stats.stat.AirUnit)
                    {
                        LastSeenPawn = enemyAI;
                    }
                }
                   
            }

        }
    }


    public List<Collider> enemiesInRange;


    private void OnDestroy()
    {
        if (stats.faction == Factions.Blue)
        {

            PawnManager.Instance.bluePawns.Remove(this);
        }

        if (stats.faction == Factions.Red)
        {

            PawnManager.Instance.redPawns.Remove(this);
        }

    }

}
