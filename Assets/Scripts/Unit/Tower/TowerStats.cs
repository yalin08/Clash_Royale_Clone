using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class TowerStats : UnitStats
{

    public GameObject DestroyCanBePlaced;


    public override void ChangeColors(Factions factions)
    {
        base.ChangeColors(factions);

        if (factions == faction.Value)
        {
            GetComponentInChildren<TowerSpawner>().SpawnTower(true);
        }
        else
        {
            GetComponentInChildren<TowerSpawner>().SpawnTower(false);
        }
    }

    private void OnDestroy()
    {
        Destroy(DestroyCanBePlaced);

    }



}
