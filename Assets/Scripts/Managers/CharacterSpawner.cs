using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;
using TMPro;
public class CharacterSpawner : Singleton<CharacterSpawner>
{
    public int SelectedCard;
    Ray ray;
    Vector3 worldPosition;
    public LayerMask layerToIgnore;
    Vector3 mousePosition;
    public GameObject BlockObj;
    public bool cardWillFollow;
    public void CardFollowMouse(int i)
    {
        if (cardWillFollow)
        {
            CardsManager.Instance.Cards[i].transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 vector = new Vector3(CardsManager.Instance.Cards[i].transform.localPosition.x, CardsManager.Instance.Cards[i].transform.localPosition.y, 0);
            CardsManager.Instance.Cards[i].transform.localPosition = vector;
        }

    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePosition);



        CardsManager.Instance.ResetCardPositions();
        if (SelectedCard >= 0)
        {
            BlockObj.SetActive(true); CardFollowMouse(SelectedCard);
        }
        else if (SelectedCard < 0)
        {
            BlockObj.SetActive(false);
            return;
        }
        if (CardsManager.Instance.Cards[SelectedCard].RepresentedPawn == null)
            return;


        if (Input.GetMouseButton(0))
        {

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~layerToIgnore))
            {

                if (hit.transform.gameObject.layer == 7)
                {
                    worldPosition = hit.point;

                }
              



            }
        }


        if (Input.GetMouseButtonUp(0))

        {



            if (worldPosition != Vector3.zero)
            {
                if (ManaManager.Instance.currentMana >= CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.ManaCost)
                {
                    int cardID = CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.pawnID;
                    CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.SpawnPawn(cardID, Factions.Blue, worldPosition);
                    ManaManager.Instance.SpendMana(CardsManager.Instance.Cards[SelectedCard].RepresentedPawn.ManaCost);


                    CardsManager.Instance.UpdateSingleCard(CardsManager.Instance.Cards[SelectedCard]);

                    SelectedCard = -1;
                }
                else
                {
                    ManaManager.Instance.NotEnoughMana();
                   
                  
                }


            }
            cardWillFollow = false;

            worldPosition = Vector3.zero;





            //     Instantiate(Object, worldPosition, Quaternion.identity);
        }




    }



}
