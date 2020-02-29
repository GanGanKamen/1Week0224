using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawn(EnemyType enemyType,int level)
    {
        GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        var enemy = enemyObj.GetComponent<Enemy>();
        float speed = 0;
        switch (enemyType)
        {
            case EnemyType.Straight:
                switch (level)
                {
                    default:
                        speed = 2f;
                        break;
                    case 1:
                        speed = 2f;
                        break;
                    case 2:
                        speed = 3f;
                        break;
                    case 3:
                        speed = 4f;
                        break;
                }
                if (transform.position.x > 0) enemy.InitStraight(speed, -1);
                else enemy.InitStraight(speed, 1);
                break;
            case EnemyType.Sin:
                float hight = 0;
                if(transform.position.y > 0)
                {
                    hight = 6;
                }
                else
                {
                    hight = -6;
                }
                enemy.InitSin(hight);
                break;
        }
    }
}
