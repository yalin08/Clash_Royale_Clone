using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn", menuName = "Characters/PawnList")]
public class PawnsIdList : ScriptableObject
{
    public GameObject[] PawnObjects;
}
