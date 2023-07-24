using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public LayerMask redPawnLayer;
    public LayerMask bluePawnLayer;


    public int RedPoints;
    public int BluePoints;

    public TextMeshProUGUI redPointsText;
    public TextMeshProUGUI bluePointsText;


    private void Update()
    {
        RedPoints = 3 - TowersManager.Instance.BlueTowers.Count;
        BluePoints = 3 - TowersManager.Instance.RedTowers.Count;

        redPointsText.text = "" + RedPoints;
        bluePointsText.text = "" + BluePoints;
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
        SceneManager.LoadScene(0);
    }



}
