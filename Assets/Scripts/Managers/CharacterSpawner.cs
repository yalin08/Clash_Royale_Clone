using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using System;

public class CharacterSpawner : NetworkBehaviour
{
    public int SelectedCard;
    Ray ray;
    Vector3 worldPosition;
    public LayerMask layerToIgnore;
    Vector3 mousePosition;
    public GameObject toBeSpawnedPawn;
    GameObject BlockObj;
    public bool cardWillFollow;

    public NetworkVariable<Factions> playerFaction = new NetworkVariable<Factions>();
    public CardsManager cardsManager;
    public ManaManager manaManager;



    public PawnsIdList PawnIDs;



    private void Awake()
    {

    }

    private void Start()
    {



        if (!IsOwner)
            return;


        StartServerRpc();



    }

    [ServerRpc]
    private void StartServerRpc()
    {
        if (OwnerClientId == 0)
        {
            playerFaction.Value = Factions.Blue;
            BlueFactionClientRpc();

        }
        else if (OwnerClientId == 1)
        {
            playerFaction.Value = Factions.Red;

            RedFactionClientRpc();
        }
        else
        {
            playerFaction.Value = Factions.none;

            Debug.Log("am red");
        }


    }

    [ClientRpc]
    private void BlueFactionClientRpc()
    {
        if ( !IsOwner)
            return;
        Debug.Log("am blue");
        BlockObj = NetworkDistribitor.Instance.blockobjBlue.gameObject;
        Camera.main.transform.position = NetworkDistribitor.Instance.CameraBlue.position;
        Camera.main.transform.rotation = NetworkDistribitor.Instance.CameraBlue.rotation;
    }
    [ClientRpc]
    private void RedFactionClientRpc()
    {
        if (!IsOwner)
            return;

        Debug.Log("am red");
        BlockObj = NetworkDistribitor.Instance.blockobjRed.gameObject;
        Camera.main.transform.position = NetworkDistribitor.Instance.CameraRed.position;
        Camera.main.transform.rotation = NetworkDistribitor.Instance.CameraRed.rotation;


    }


    public void ChangeSelectedCard(int cardNumber)
    {
        SelectedCard = cardNumber;
        ChangeSelectedCardOnServerRpc(cardsManager.Cards[cardNumber].RepresentedPawn.CardID);
        cardWillFollow = true;
    }

    [ServerRpc]
    void ChangeSelectedCardOnServerRpc(int ID)
    {
        toBeSpawnedPawn = PawnIDs.PawnObjects[ID];
    }


    public void CardFollowMouse(int i)
    {
        if (cardWillFollow)
        {
            cardsManager.Cards[i].transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 vector = new Vector3(cardsManager.Cards[i].transform.localPosition.x, cardsManager.Cards[i].transform.localPosition.y, 0);
            cardsManager.Cards[i].transform.localPosition = vector;
        }

    }

    void Update()
    {


        if (!IsOwner)
            return;

        if (BlockObj == null)
            return;

        mousePosition = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePosition);



        cardsManager.ResetCardPositions();
        if (SelectedCard >= 0)
        {
            BlockObj.gameObject.SetActive(true); CardFollowMouse(SelectedCard);
        }
        else if (SelectedCard < 0)
        {
            BlockObj.gameObject.SetActive(false);
            return;
        }

        if (cardsManager.Cards[SelectedCard].RepresentedPawn == null) return;


        if (Input.GetMouseButton(0))
        {

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~layerToIgnore))
            {

                if (hit.transform.gameObject.layer == 7)
                {
                    worldPosition = hit.point;

                }





            }
            else
            {
                worldPosition = Vector3.zero;

            }
        }



        if (Input.GetMouseButtonUp(0))

        {



            if (worldPosition != Vector3.zero)
            {
                if (manaManager.currentMana >= cardsManager.Cards[SelectedCard].RepresentedPawn.ManaCost)
                {

                    // cardsManager.Cards[SelectedCard].RepresentedPawn.SpawnPawn(playerFaction.Value, worldPosition);

                    SpawnPawnServerRpc(playerFaction.Value, worldPosition);
                    manaManager.SpendMana(cardsManager.Cards[SelectedCard].RepresentedPawn.ManaCost);


                    cardsManager.UpdateSingleCard(cardsManager.Cards[SelectedCard]);

                    SelectedCard = -1;




                }
                else
                {
                    manaManager.NotEnoughMana();


                }


            }
            cardWillFollow = false;

            worldPosition = Vector3.zero;





            //     Instantiate(Object, worldPosition, Quaternion.identity);
        }




    }


    [ServerRpc]
    void SpawnPawnServerRpc(Factions faction, Vector3 position)
    {


        GameObject go = go = Instantiate(toBeSpawnedPawn, position, Quaternion.identity);
        if (faction == Factions.Blue)
        {

            UnitStats stats = go.GetComponent<UnitStats>();
            stats.faction.Value = Factions.Blue;
            stats.enemyFaction.Value = Factions.Red;
            PawnManager.Instance.bluePawns.Add(go.GetComponent<PawnAI>());


        }
        if (faction == Factions.Red)
        {

            UnitStats stats = go.GetComponent<UnitStats>();
            stats.faction.Value = Factions.Red;
            stats.enemyFaction.Value = Factions.Blue;
            PawnManager.Instance.redPawns.Add(go.GetComponent<PawnAI>());

        }

        NetworkObject networkObject = go.GetComponent<NetworkObject>();
        networkObject.Spawn();
    }



}
