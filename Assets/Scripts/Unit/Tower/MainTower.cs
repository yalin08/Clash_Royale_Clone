using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MainTower : UnitStats
{
    public FactionEvent GameEnd;

    public override void Die()
    {
        base.Die();
        GameEnd.Raise(faction.Value);
       
    }



    [ClientRpc]
    private void OnDestroyClientRpc()
    {
       
    }



}
