using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Unity.Netcode;
public class NetworkDistribitor : Singleton<NetworkDistribitor>
{
    public NetworkObject blockobjRed;
    public NetworkObject blockobjBlue;

    public Transform CameraBlue;
    public Transform CameraRed;

}
