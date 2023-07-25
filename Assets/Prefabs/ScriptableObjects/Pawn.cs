using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn", menuName = "Characters/Pawn")]
public class Pawn : ScriptableObject
{
    public GameObject PawnObject;

    public Stats stats;
    public int pawnID;
    public int ManaCost;
    public Sprite CharacterImage;

    private void OnValidate()
    {
        stats.maxHealth = stats.health;
        PawnObject.GetComponent<UnitStats>().stat = stats;
    }
    private void Awake()
    {
        stats.maxHealth = stats.health;
        PawnObject.GetComponent<UnitStats>().stat = stats;
    }


    public void SpawnPawn(int pawnID,Factions faction, Vector3 position)
    {
        if (faction == Factions.Blue)
        {
            GameObject go = Instantiate(PawnObject, position, Quaternion.identity);
            UnitStats stats = go.GetComponent<UnitStats>();
            stats.faction = Factions.Blue;
            stats.enemyFaction = Factions.Red;
            PawnManager.Instance.bluePawns.Add(go.GetComponent<PawnAI>());


        }
        if (faction == Factions.Red)
        {
            GameObject go = Instantiate(PawnObject, position, Quaternion.identity);
            UnitStats stats = go.GetComponent<UnitStats>();
            stats.faction = Factions.Red;
            stats.enemyFaction = Factions.Blue;
            PawnManager.Instance.redPawns.Add(go.GetComponent<PawnAI>());

        }

    }
}
