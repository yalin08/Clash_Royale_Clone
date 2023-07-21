using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public LayerMask redPawnLayer;
    public LayerMask bluePawnLayer;

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
