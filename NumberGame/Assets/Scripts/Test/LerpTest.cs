using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public int direction;
    public float speed = 1.0F;
    [SerializeField]float present_Location;
    private float distance_two;
    // Start is called before the first frame update
    void Start()
    {
        distance_two = Vector3.Distance(startMarker.position, endMarker.position);
    }


    // Update is called once per frame
    void Update()
    {
        present_Location += (Time.deltaTime * speed * direction) / distance_two;

        // オブジェクトの移動
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, present_Location);
    }
}
