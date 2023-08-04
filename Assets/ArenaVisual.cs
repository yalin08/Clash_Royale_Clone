using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.AddressableAssets.ResourceProviders;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ArenaVisual : MonoBehaviour
{
    private void Start()
    {
        AddressableManager.Instance.GenerateArena(transform);
    }
}
