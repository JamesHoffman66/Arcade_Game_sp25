using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public Vector3 lookDirection;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player1");

        
        lookDirection = (Player.transform.position - transform.position).normalized;
    }

    void Update()
    {
        
        transform.Translate(lookDirection * speed * Time.deltaTime);
    }
}
