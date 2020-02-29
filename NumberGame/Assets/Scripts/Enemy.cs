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
    private bool isColide = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void InitStraight(float _speed,int _direction)
    {
        type = EnemyType.Straight;
        speed = _speed;
        direction = _direction;
    }

    public void InitSin(float _hight)
    {
        type = EnemyType.Sin;
        speed = 2;
        hight = _hight;
        weight = 4;
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
                transform.position += new Vector3(speed * Time.deltaTime * direction,0,0);
                break;
            case EnemyType.Sin:
                transform.position += new Vector3(weight * Time.deltaTime * direction, hight* Mathf.Sin(Time.time * speed) * Time.deltaTime, 0);
                break;
            case EnemyType.Goal:
                
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && isColide == false)
        {
            isColide = true;
            direction = direction * (-1);
            Destroy(gameObject, 3f);
        }
    }
}
