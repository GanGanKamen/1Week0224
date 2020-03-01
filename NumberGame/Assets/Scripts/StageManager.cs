using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject socreSender;
    [SerializeField] private AudioSource bgm;
    public int RemainingTime { get { return GetRemainTime(); } }
    [SerializeField] private Player.NumberManager numberManager;
    [SerializeField] private GameObject uIManager;
    [SerializeField] private SpawnPoint[] straightSpawnPoints;
    [SerializeField] private SpawnPoint[] sinSpawnPoints;
    [SerializeField] private SpawnPoint[] goalSpawnPoints;
    private bool gameStart = false;
    [SerializeField] private int totalTime = 60;
    [SerializeField]private float elapsedTime = 0;
    public int waveLevel = 1;
    private float adventCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStart());
    }

    // Update is called once per frame
    void Update()
    {
        TimeVent();
    }

    private IEnumerator GameStart()
    {
        while(numberManager.isApp == false)
        {
            yield return null;
        }
        bgm.loop = true;
        bgm.Play();
        uIManager.SetActive(true);
        gameStart = true;
        int randomNum = Random.Range(0, straightSpawnPoints.Length);
        straightSpawnPoints[randomNum].EnemySpawn(EnemyType.Straight, waveLevel);
    }

    private int GetRemainTime()
    {
        return totalTime - (int)elapsedTime;
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
            else if(elapsedTime >= 10 && elapsedTime < 30)
            {
                waveLevel = 2;
            }
            else
            {
                waveLevel = 1;
            }

            EnemyAdvent();

            if(elapsedTime > totalTime && gameStart)
            {
                elapsedTime = totalTime;
                gameStart = false;
                foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Destroy(gameObject);
                }
                bgm.Stop();
                var obj = Instantiate(socreSender,transform.position,Quaternion.identity);
                obj.GetComponent<ScoreSender>().score = numberManager.score;
                Fader.FadeInBlack(1f, "Result");
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
                    RandomAdvent();
                }
                break;
            case 3:
                if (adventCount >= 1)
                {
                    adventCount = 0;
                    AllAdvent();
                }
                break;
            default:
                if (adventCount >= 2)
                {
                    RandomAdvent();
                }
                break;
        }
    }

    private void RandomAdvent()
    {
        adventCount = 0;
        int type = 0;
        switch (waveLevel)
        {
            case 1:
                type = Random.Range(0, 2);
                if(type == 0)
                {
                    int randomNum = Random.Range(0, straightSpawnPoints.Length);
                    straightSpawnPoints[randomNum].EnemySpawn(EnemyType.Straight, waveLevel);
                }
                else
                {
                    int randomNum = Random.Range(0, goalSpawnPoints.Length);
                    goalSpawnPoints[randomNum].EnemySpawn(EnemyType.Goal, waveLevel);
                }
                break;
            case 2:
                type = Random.Range(0, 3);
                if (type == 0)
                {
                    int randomNum = Random.Range(0, straightSpawnPoints.Length);
                    straightSpawnPoints[randomNum].EnemySpawn(EnemyType.Straight, waveLevel);
                }
                else if(type == 1)
                {
                    int randomNum = Random.Range(0, sinSpawnPoints.Length);
                    sinSpawnPoints[randomNum].EnemySpawn(EnemyType.Sin, waveLevel);
                }
                else
                {
                    int randomNum = Random.Range(0, goalSpawnPoints.Length);
                    goalSpawnPoints[randomNum].EnemySpawn(EnemyType.Goal, waveLevel);
                }
                break;
        }
        
    }

    private void AllAdvent()
    {
        int straightRandom = Random.Range(0, straightSpawnPoints.Length);
        int sinRandom = Random.Range(0, sinSpawnPoints.Length);
        int goalRandom = Random.Range(0, goalSpawnPoints.Length);
        straightSpawnPoints[straightRandom].EnemySpawn(EnemyType.Straight, waveLevel);
        sinSpawnPoints[sinRandom].EnemySpawn(EnemyType.Sin, waveLevel);
        goalSpawnPoints[goalRandom].EnemySpawn(EnemyType.Goal, waveLevel);
    }
}
