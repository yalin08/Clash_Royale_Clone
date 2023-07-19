using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using System;
public class TowersManager : Singleton<TowersManager>
{


    public List<TowerAI> RedTowers;
    public List<TowerAI> BlueTowers;

    public Factions EnemyFaction(Factions faction)
    {
        int i = (int)faction;

        if (i == 0)
            i = 1;
        else
            i = 0;

        return (Factions)i;
    }




}




