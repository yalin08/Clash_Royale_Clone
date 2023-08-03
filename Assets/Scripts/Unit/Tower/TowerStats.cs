using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class TowerStats : UnitStats
{

    public GameObject DestroyCanBePlaced;


    private void OnDestroy()
    {
        Destroy(DestroyCanBePlaced);

    }



}
