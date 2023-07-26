using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMove : PawnMove
{
    private void Update()
    {
        if(target!=null)
        if (Vector3.Distance(transform.position, target.position) > stats.stat.attackRange * 0.9f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, stats.stat.speed * Time.deltaTime);

            transform.LookAt(target.position);

        }



    }
}
