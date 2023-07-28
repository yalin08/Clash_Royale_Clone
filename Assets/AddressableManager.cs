using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.AddressableAssets.ResourceProviders;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement;
using Pixelplacement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AddressableManager : Singleton<AddressableManager>

{
    public AssetReference[] Pawns;
    public GameObject ggo;
    public Slider slider;

    public TMPro.TextMeshProUGUI text;

    private AsyncOperationHandle mSceneHandle;
    bool showSlider = false;
    AsyncOperationHandle<SceneInstance> sceneinstance;

    private void Start()
    {
        //  Addressables.ClearDependencyCacheAsync("GameScene");
    }

    public void Clear()
    {


        Addressables.UnloadSceneAsync(sceneinstance);
        Addressables.Release(mSceneHandle);
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

            text.text = $"Download Size {(Size / 1024) / 1024} mb. \nDownload ? ";
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
        sceneinstance = Addressables.LoadSceneAsync("GameScene");
    }




    public void CreatePawn(int pawnID, Factions faction, Vector3 position)
    {
        AssetReference pawn = Pawns[pawnID];

        pawn.InstantiateAsync().Completed += go =>
        {
        };
    }


}


