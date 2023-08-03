using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MainTower : UnitStats
{
    public FactionEvent GameEnd;

    private void OnDestroy()
    {
        if (IsOwner)
        {
            GameEnd.Raise(faction.Value);

        }
  
    }
  


}
