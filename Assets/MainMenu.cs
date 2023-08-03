using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Netcode.Transports.UTP;


public class MainMenu : MonoBehaviour
{

    public TMP_InputField inputfield;
    public string joinCode;

    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);


        };
        AuthenticationService.Instance.SignInAnonymouslyAsync();

        

    }

    public void StartGame()
    {
        joinCode = inputfield.text;
        JoinRelay();
    }

    private async void CreateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(2);
            joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);


            NetworkManager.Singleton.GetComponent<UnityTransport>().SetHostRelayData(
                allocation.RelayServer.IpV4,
                (ushort)allocation.RelayServer.Port,
                allocation.AllocationIdBytes,
                allocation.Key,
                allocation.ConnectionData
                );
            inputfield.text = joinCode;
            NetworkManager.Singleton.StartServer();
        }

        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

    private async void JoinRelay()
    {
        try
        {
            if (joinCode != "")
            {
                Debug.Log("Joining relay with" + joinCode);
                JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);



                NetworkManager.Singleton.GetComponent<UnityTransport>().SetClientRelayData(
                    joinAllocation.RelayServer.IpV4,
                    (ushort)joinAllocation.RelayServer.Port,
                    joinAllocation.AllocationIdBytes,
                    joinAllocation.Key,
                    joinAllocation.ConnectionData,
                    joinAllocation.HostConnectionData);

                NetworkManager.Singleton.StartClient();
                Destroy(gameObject);
            }
            else inputfield.text = "Invalid Join Code!";

        }



        catch (RelayServiceException e)
        {
            inputfield.text = "Invalid Join Code!";
            Debug.Log(e);
        }
    }
    bool didSpawn = false;
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.A)) CreateRelay();


        if (NetworkManager.Singleton.IsServer)
            if (NetworkManager.Singleton.ConnectedClientsList.Count >= 2)
                if (didSpawn == false)
                {
                    didSpawn = true;
                    transform.gameObject.SetActive(false);
                  
                }



    }

    [ClientRpc]
    private void DeactivateMainMenuClientRpc()
    {
        Debug.Log("diddelete");
  
    }

        /*  public void PlayGame()
          {
              NetworkManager.Singleton.StartClient();
          }
          public void StartServer()
          {
              NetworkManager.Singleton.StartServer();
          } */
    }
