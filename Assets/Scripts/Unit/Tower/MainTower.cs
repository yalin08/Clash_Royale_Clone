using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : UnitStats
{


    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
            if (Application.isPlaying)
            {
                if (faction.Value == Factions.Blue)
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
