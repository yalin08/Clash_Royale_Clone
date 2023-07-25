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

    // Start is called before the first frame update
    void Start()
    {
        //  text.text = ""+Addressables.GetDownloadSizeAsync("Level");
        Addressables.InitializeAsync().Completed += Addressables_Completed;


    }


    // Update is called once per frame
    void Update()
    {
       // slider.value = Addressables.DownloadDependenciesAsync(labelReference).GetDownloadStatus().Percent;

    }



    private void Addressables_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        SceneManager.LoadScene(1);
    }






    public void CreatePawn(int pawnID, Factions faction, Vector3 position)
    {
        AssetReference pawn = Pawns[pawnID];

        pawn.InstantiateAsync().Completed += go =>
        {
            go.Result.GetComponent<UnitStats>().faction = faction;
            go.Result.GetComponent<UnitStats>().enemyFaction = EnemyFaction(faction);
        };
    }
    public Factions EnemyFaction(Factions faction)
    {
        int i = (int)faction;

        if (i == 0)
            i = 1;
        else
            i = 0;

        return (Factions)i;
    }


}
