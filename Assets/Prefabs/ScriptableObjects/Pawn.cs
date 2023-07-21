using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn", menuName = "Characters/Pawn")]
public class Pawn : ScriptableObject
{
    public GameObject PawnObject;

    public Stats stats;

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


    public void SpawnPawn(Factions faction, Vector3 position)
    {
        if (faction == Factions.Blue)
        {
            GameObject go = Instantiate(PawnObject, position, Quaternion.identity);
            PawnManager.Instance.bluePawns.Add(go.GetComponent<PawnAI>());
        }

    }
}
