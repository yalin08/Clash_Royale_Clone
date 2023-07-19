using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class PawnManager : Singleton<PawnManager>
{
    public List<PawnAI> redPawns;

    public List<PawnAI> bluePawns;

    private void Awake()
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

}


