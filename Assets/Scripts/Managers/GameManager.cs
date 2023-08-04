using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class GameManager : Singleton<GameManager>
{
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public LayerMask redPawnLayer;
    public LayerMask bluePawnLayer;


    public int RedPoints;
    public int BluePoints;

    public TextMeshProUGUI TextOnTop;
    public TextMeshProUGUI TextOnDown;


    private void Update()
    {
        RedPoints = 3 - TowersManager.Instance.BlueTowers.Count;
        BluePoints = 3 - TowersManager.Instance.RedTowers.Count;

      
   


    }

    public void Lose()
    {
        PawnManager.Instance.StopAllPawns();
        LoseScreen.SetActive(true);

      
    }

    public void Win()
    {
        PawnManager.Instance.StopAllPawns();
        WinScreen.SetActive(true);

     
    }


    public void RestartLevel()
    {
        Destroy(NetworkManager.Singleton.gameObject);
        SceneManager.LoadScene("GameScene");
       // AddressableManager.Instance.Clear();
    }



}
