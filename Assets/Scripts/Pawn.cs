using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
[CreateAssetMenu(fileName = "Pawn", menuName = "Characters/Pawn")]
public class Pawn : ScriptableObject
{
    public GameObject PawnObject;

    public Stats stats;

    public int ManaCost;
    public Sprite CharacterImage;


    public int CardID;
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


   // public void SpawnPawn(Factions faction, Vector3 position)
   // {

    //    SpawnPawnServerRpc(PawnObject, faction, position);

   // }

    


}
