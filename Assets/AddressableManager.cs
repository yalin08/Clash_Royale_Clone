using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.AddressableAssets.ResourceProviders;
using UnityEngine.ResourceManagement.AsyncOperations;
using Pixelplacement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AdressableManager : Singleton<AdressableManager>
{


    public AssetReference[] Pawns;
    public GameObject ggo;
    public Slider slider;

    public TMPro.TextMeshProUGUI text;
    public AssetLabelReference labelReference;
    private AsyncOperationHandle mSceneHandle;
    bool showSlider = false;


    private void Start()
    {
      //  Addressables.ClearDependencyCacheAsync("GameScene");
    }

    public void Clear()
    {
        Caching.ClearCache();
    }

    public void AcceptedDownload()
    {
        mSceneHandle = Addressables.DownloadDependenciesAsync("GameScene");

        mSceneHandle.Completed += Download_Completed;

        showSlider = true;
    }

    public void RefusedDownload()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            var Size = Addressables.GetDownloadSizeAsync("GameScene").Result;

            text.text = $"Download Size {(Size/1024)/1024} mb. \nDownload ? ";
        }

        if (showSlider)
            slider.value = mSceneHandle.PercentComplete;


    }



    private void Download_Completed(AsyncOperationHandle obj)
    {

        LoadGameScene(); showSlider = false;

    }

    public void LoadGameScene()
    {
        Addressables.LoadSceneAsync("GameScene");
    }




    public void CreatePawn(int pawnID, Factions faction, Vector3 position)
    {
        AssetReference pawn = Pawns[pawnID];

        pawn.InstantiateAsync().Completed += go =>
        {
        };
    }


}


