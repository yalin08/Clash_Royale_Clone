using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TowerStats : UnitStats
{

    public GameObject DestroyCanBePlaced;
    public override void Die()
    {
        base.Die();
        if (DestroyCanBePlaced != null)
        {
            if(IsClient)
            Destroy(DestroyCanBePlaced);

        }


    }
}
