using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class PawnManager : Singleton<PawnManager>
{
    public List<PawnAI> redPawns;


    public List<PawnAI> bluePawns;


    private void Start()
    {
        GameObject[] pawnsInStart = GameObject.FindGameObjectsWithTag("Pawn");
        foreach (GameObject go in pawnsInStart)
        {
            PawnAI pawnAI = go.GetComponent<PawnAI>();
            if (pawnAI.stats.faction == Factions.Red)
            {
                redPawns.Add(pawnAI);
            }
            else
            {
                bluePawns.Add(pawnAI);
            }
        }

    }

    public void StopAllPawns()
    {
        foreach (PawnAI red in redPawns)
        {
            Destroy(red);
        }
        foreach (PawnAI blue in bluePawns)
        {
            Destroy(blue);
        }


        bluePawns.Clear();
        redPawns.Clear();
    }


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


