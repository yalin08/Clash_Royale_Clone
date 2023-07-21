using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    public Factions faction;


    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
            if (Application.isPlaying)
            {
                if (faction == Factions.Blue)
                {
                    GameManager.Instance.Lose();

                }
                else
                {
                    GameManager.Instance.Win();
                }
            }

    }

}
