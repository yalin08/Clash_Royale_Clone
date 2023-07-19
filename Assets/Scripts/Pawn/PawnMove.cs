using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PawnMove : MonoBehaviour
{
    UnitStats stats;
    NavMeshAgent agent;

    public Transform target;
    private void Awake()
    {
        stats = GetComponent<UnitStats>();
        agent = GetComponent<NavMeshAgent>();
     
    }

    private void Update()
    {
        agent.speed = stats.stat.speed;
        agent.stoppingDistance = stats.stat.attackRange;
        if(target!=null)
        agent.SetDestination(target.position);

    }


}
