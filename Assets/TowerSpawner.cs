using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public void SpawnTower(bool isPlayer)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        if (isPlayer)
        {
            AddressableManager.Instance.GeneratePlayerTower(transform);
        }
        else
        {
            AddressableManager.Instance.GenerateEnemyTower(transform);
        }

    }
}
