using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using TMPro;

public class CardsManager : Singleton<CardsManager>
{
    public List<Pawn> Deck;


    public UICard[] Cards;


    private void Start()
    {
        UpdateCards();
    }

    public void UpdateCards()
    {
        ShuffleList(Deck);



        for (int i = 0; i < Cards.Length; i++)
        {
            Cards[i].RepresentedPawn = Deck[i];
            Cards[i].UpdateCard();
        }
    }


    // Fisher-Yates shuffle algorithm
    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        System.Random rng = new System.Random();

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}
