using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] straightSpawnPoints;
    [SerializeField] private SpawnPoint[] sinSpawnPoints;
    private bool gameStart = false;
    [SerializeField] private int totalTime = 60;
    [SerializeField]private float elapsedTime = 0;
    private int waveLevel = 1;
    private float adventCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        int randomNum = Random.Range(0, straightSpawnPoints.Length);
        straightSpawnPoints[randomNum].EnemySpawn(EnemyType.Straight, waveLevel);
    }

    // Update is called once per frame
    void Update()
    {
        TimeVent();

    }

    private void TimeVent()
    {
        if (gameStart)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= 40)
            {
                waveLevel = 3;
            }
            else if(elapsedTime >= 10 && elapsedTime < 40)
            {
                waveLevel = 2;
            }
            else
            {
                waveLevel = 1;
            }

            EnemyAdvent();

            if(elapsedTime >= totalTime)
            {
                elapsedTime = totalTime;
                gameStart = false;
            }
        }
    }

    private void EnemyAdvent()
    {
        adventCount += Time.deltaTime;
        switch (waveLevel)
        {
            case 2:
                if(adventCount >= 2)
                {
                    adventCount = 0;
                    Debug.Log("Advent2");
                }
                break;
            case 3:
                if (adventCount >= 1)
                {
                    adventCount = 0;
                    Debug.Log("Advent3");
                }
                break;
            default:
                if (adventCount >= 4)
                {
                    RandomAdvent();
                }
                break;
        }
    }

    private void RandomAdvent()
    {
        adventCount = 0;
        switch (waveLevel)
        {
            default:
                int type = Random.Range(0, 2);
                if(type == 0)
                {
                    int randomNum = Random.Range(0, straightSpawnPoints.Length);
                    straightSpawnPoints[randomNum].EnemySpawn(EnemyType.Straight, waveLevel);
                }
                else
                {
                    int randomNum = Random.Range(0, sinSpawnPoints.Length);
                    sinSpawnPoints[randomNum].EnemySpawn(EnemyType.Sin, waveLevel);
                }
                break;
        }
        
    }
}
