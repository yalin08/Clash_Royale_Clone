using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;
using TMPro;
public class CharacterSpawner : Singleton<CharacterSpawner>
{
    public GameObject Object;
    public int SelectedCard;
    Ray ray;
    Vector3 worldPosition;




    void Update()
    {
        if (SelectedCard < 0)
            return;
        if (CardsManager.Instance.Cards[SelectedCard].RepresentedPawn == null)
            return;
        

        if (Input.GetMouseButton(0)) // Left mouse button
        {
            // Get the position of the mouse in screen space
            Vector3 mousePosition = Input.mousePosition;

            // Create a ray from the camera to the mouse position
            ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.gameObject.layer==7)
                    worldPosition = hit.point;
            }

        }

        if (Input.GetMouseButtonUp(0))

        {

            if (ManaManager.Instance.currentMana < CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.ManaCost)
            {
                ManaManager.Instance.NotEnoughMana();
                return;
            }

            if (worldPosition != Vector3.zero)
            {
                int cardID = CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.pawnID;
                CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.SpawnPawn(cardID,Factions.Blue, worldPosition);
                ManaManager.Instance.SpendMana(CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.ManaCost);
                CardsManager.Instance.Cards[SelectedCard].RepresentedPawn = CardsManager.Instance.Deck[Random.Range(0, 3)];
                CardsManager.Instance.Cards[SelectedCard].UpdateCard();
                SelectedCard = -1;
            }




            worldPosition = Vector3.zero;
            //     Instantiate(Object, worldPosition, Quaternion.identity);
        }
    }



}
