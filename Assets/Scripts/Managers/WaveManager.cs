using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;
[System.Serializable]
public class Waves
{
    [HideInInspector] public string WaveName;
    //  public GameObject[] Enemies;
    //  public int[] EnemySpawnRate;
    //  public float[] SpawnTimer;


    public Wave[] enemies;
}
[System.Serializable]
public class Wave
{
    public GameObject Enemy;
    public int EnemySpawnRate;
    public float SpawnTimer;
}

public class WaveManager : Singleton<WaveManager>
{
    public Waves[] LevelWaves;
    public float seconds;
    public int minutes;
    public Transform[] EnemySpawnLocations;
    bool gameHasStarted = false;


    public TextMeshProUGUI Timer;



    private void OnValidate()
    {
        if (LevelWaves.Length > 0)
            for (int i = 0; i < LevelWaves.Length; i++)
            {
                LevelWaves[i].WaveName = "Wave " + (i + 1);
            }
    }
    public void StartWaves()
    {
        gameHasStarted = true;
        StopAllCoroutines();
        for (int i = 0; i < LevelWaves[minutes].enemies.Length; i++)
        {
            StartCoroutine(WaveEnemy(i));
        }

    }
    public void NextWave()
    {
        StopAllCoroutines();

        for (int i = 0; i < LevelWaves[minutes].enemies.Length; i++)
        {

            StartCoroutine(WaveEnemy(i));
        }
    }

    public IEnumerator WaveEnemy(int enemynumber)
    {



        Waves currentwave = LevelWaves[minutes];
        if (currentwave == null)
        {
            yield break;
        }

        if (currentwave.enemies.Length < enemynumber + 1 || currentwave.enemies.Length < enemynumber + 1)
        {
            yield break;
        }

        yield return new WaitForSeconds(currentwave.enemies[enemynumber].SpawnTimer);

        for (int i = 0; i < currentwave.enemies[enemynumber].EnemySpawnRate; i++)
            SpawnEnemy(currentwave.enemies[enemynumber].Enemy);

        StartCoroutine(WaveEnemy(enemynumber));
    }


    void SpawnEnemy(GameObject enemy)
    {
        int i = Random.Range(0, EnemySpawnLocations.Length - 1);

        float rand1 = Random.Range(-3f, 3f);
        float rand2 = Random.Range(-3f, 3f);

        Vector3 v = new Vector3(rand1, 0, rand2);
        GameObject spawnedEnemy = Instantiate(enemy, EnemySpawnLocations[i].position + v, Quaternion.identity, transform.parent);
        PawnManager.Instance.redPawns.Add(spawnedEnemy.GetComponent<PawnAI>());
    }
    string mins;
    string secs;
    bool AfterHalfMinute;


    private void Update()
    {
        if (!gameHasStarted)
        {
            return;
        }
        seconds += Time.deltaTime;

        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;

            if (minutes >= LevelWaves.Length)
            {
                GameManager.Instance.Win();

                gameHasStarted = false;

            }
            else

                NextWave();


        }

        /*    if (seconds > 30 && !AfterHalfMinute)
             {

                 AfterHalfMinute = true;
                 if (LevelWaves[minutes].EnemySpawnRate.Length < 2)
                     for (int i = 0; i < LevelWaves[minutes].EnemySpawnRate.Length; i++)
                     {
                         LevelWaves[minutes].EnemySpawnRate[i] *= 2;
                     }
                 else
                 {
                     LevelWaves[minutes].EnemySpawnRate[0] *= 2;
                     LevelWaves[minutes].EnemySpawnRate[1] *= 2;
                 }

             }
             else if (AfterHalfMinute && seconds <= 30)
             {
                 AfterHalfMinute = false;
             } */




        if (minutes < 10)
        {
            mins = "0" + minutes;
        }
        else
            mins = "" + minutes;

        if (seconds < 10)
        {
            secs = "0" + Mathf.FloorToInt(seconds);
        }
        else secs = "" + Mathf.FloorToInt(seconds);


        Timer.text = mins + "." + secs;

    }
}
