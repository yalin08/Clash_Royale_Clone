using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }


    public void PlayGame()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
    }
}
