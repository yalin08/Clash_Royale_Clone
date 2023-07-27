using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TowerStats : UnitStats
{

    public GameObject DestroyCanBePlaced;
       public override void Die()
    {
        if (DestroyCanBePlaced != null)
            Destroy(DestroyCanBePlaced);
        base.Die();
      
    }
}
