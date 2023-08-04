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
    public AssetReference Arena;
    public AssetReference PlayerTower;
    public AssetReference EnemyTower;


    public TMPro.TextMeshProUGUI text;

    private AsyncOperationHandle mSceneHandle;
    bool showSlider = false;
    public Slider slider;
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

        mSceneHandle = Addressables.DownloadDependenciesAsync("level");

        mSceneHandle.Completed += Download_Completed;

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
            var Size = Addressables.GetDownloadSizeAsync("level").Result;

            text.text = $"Download Size {(Size / 1024) / 1024} mb. \nDownload ? ";
        }

        if (showSlider)
            slider.value = mSceneHandle.PercentComplete;


    }



    private void Download_Completed(AsyncOperationHandle obj)
    {

        LoadGameScene();
        showSlider = false;

    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        showSlider = false;
    }


    public async void GenerateArena(Transform transform)
    {
        GameObject go = Addressables.InstantiateAsync(Arena, transform.position, transform.rotation, transform).Result;
    
    }



    public async void GeneratePlayerTower(Transform transform)
    {
       Addressables.InstantiateAsync(PlayerTower, transform.position, transform.rotation, transform);
     
    }
    public async void GenerateEnemyTower(Transform transform)
    {
        Addressables.InstantiateAsync(EnemyTower, transform.position, transform.rotation, transform);
    }

}


