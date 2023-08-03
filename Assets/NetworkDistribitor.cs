using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Unity.Netcode;
using Unity.Netcode.Transports;

public class NetworkDistribitor : Singleton<NetworkDistribitor>
{
    public NetworkObject blockobjRed;
    public NetworkObject blockobjBlue;

    public Transform CameraBlue;
    public Transform CameraRed;


    public GameObject Player;
    bool didSpawn = false;



   

    private void Update()
    {



        if (NetworkManager.Singleton.IsServer)
            if (NetworkManager.Singleton.ConnectedClientsList.Count >= 2)
                if (didSpawn == false)
                {
                    didSpawn = true;
                    SpawnPlayerObjServerRpc();
                }
    }

    [ServerRpc]
    void SpawnPlayerObjServerRpc()
    {
        GameObject go = null;
        go = Instantiate(Player);
        go.GetComponent<NetworkObject>().SpawnAsPlayerObject(1);
        go = Instantiate(Player);
        go.GetComponent<NetworkObject>().SpawnAsPlayerObject(2);
    }

}
