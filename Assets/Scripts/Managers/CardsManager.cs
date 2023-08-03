using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using TMPro;
using Unity.Netcode;
public class CardsManager :NetworkBehaviour
{
    public List<Pawn> Deck;


    public UICard[] Cards;
    public UICard NextCard;



    public int nextCardNumber;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        if (!IsOwner)
            return;

        Cards = UIManager.Instance.Cards;
        NextCard= UIManager.Instance.NextCard;
        UpdateCards(); nextCardNumber = 1;

        UpdateNextCard();
    }



    public void ResetCardPositions()
    {
        foreach (UICard card in Cards)
        {
            card.transform.localPosition = Vector3.zero;
        }
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


    public void UpdateSingleCard(UICard card)
    {




        card.RepresentedPawn = Deck[nextCardNumber];
        card.UpdateCard();

        nextCardNumber++;
        if (nextCardNumber >= Deck.Count)
            nextCardNumber = 0;

        UpdateNextCard();

    }

    public void UpdateNextCard()
    {
        NextCard.RepresentedPawn = Deck[nextCardNumber];
        NextCard.UpdateCard();
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
