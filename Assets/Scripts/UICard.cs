using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UICard : MonoBehaviour
{
    public Pawn RepresentedPawn;
    public TextMeshProUGUI ManaAmount;
    public Image PawnImage;
    public int buttonNumber;

    public void TouchCard()
    {
        CharacterSpawner.Instance.SelectedCard = buttonNumber;

        CharacterSpawner.Instance.cardWillFollow = true;

        //change this later




    }

    public void UpdateCard()
    {
        ManaAmount.text = ""+RepresentedPawn.ManaCost;
        PawnImage.sprite = RepresentedPawn.CharacterImage;
    }
}
