using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType type;
    [SerializeField] [Range(-1, 1)] private int direction;
    [SerializeField] private float speed;
    [SerializeField] private float hight;
    [SerializeField] private float weight;
    public bool isColide = false;
    [SerializeField]private Vector3 startPos, goalPos;
    private float lerpCount = 0;
    private float distance_two;
    private int level;
    private float accel = 0;

    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetLevel(int _level)
    {
        level = _level;
    }

    public void InitStraight(float _speed,int _direction)
    {
        type = EnemyType.Straight;
        speed = _speed;
        direction = _direction;
        if(level == 3)
        {
            accel = Random.Range(1, 5);
        }
    }

    public void InitSin(float _hight, int _direction)
    {
        type = EnemyType.Sin;
        speed = 2;
        hight = _hight;
        weight = 4;
        direction = _direction;
    }

    public void InitGoal(Vector3 _start, Vector3 _goal,float _speed)
    {
        type = EnemyType.Goal;
        speed = _speed;
        startPos = _start;
        goalPos = _goal;
        direction = 1;
        distance_two = Vector3.Distance(startPos, goalPos);
    }

    // Update is called once per frame
    void Update()
    {
        MoveAction();
    }

    private void MoveAction()
    {
        switch (type)
        {
            case EnemyType.Straight:
                speed += accel * Time.deltaTime;
                transform.position += new Vector3(speed * Time.deltaTime * direction,0,0);
                break;
            case EnemyType.Sin:
                transform.position += new Vector3(weight * Time.deltaTime * direction, hight* Mathf.Sin(Time.time * speed) * Time.deltaTime, 0);
                break;
            case EnemyType.Goal:
                if (lerpCount>=0 && lerpCount < 1) lerpCount += (Time.deltaTime * speed * direction) / distance_two;
                transform.position = Vector3.Lerp(startPos, goalPos, lerpCount);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && isColide == false)
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            Destroy(gameObject);
        }

        else if (collision.transform.CompareTag("Player") && isColide == false)
        {
            isColide = true;
            direction = direction * (-1);           
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Collecter") && isColide == false)
        {
            isColide = true;
            var collecter = collision.transform.GetComponent<Player.Collecter>();
            collecter.ScorePlus(level);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
