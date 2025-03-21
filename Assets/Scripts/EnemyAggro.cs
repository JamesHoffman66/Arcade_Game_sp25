using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player;
    public GameObject player2;
    
    public Rigidbody rb;
    private Transform currentPoint;
    public float speed = 2.5f;
    public bool patrol;
    public float aggroRange = 10f;
    public float fieldOfViewAngle = 60f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointB.transform;
        patrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Vector2 point = currentPoint.position - transform.position;
        Vector2 directionToPlayer = player.transform.position - transform.position;
        Vector2 directionToPlayer2 = player2.transform.position - transform.position;

        float angleToPlayer = Vector3.Angle(transform.right, directionToPlayer);
        float angleToPlayer2 = Vector3.Angle(transform.right, directionToPlayer2);

        bool playerInSight = angleToPlayer < fieldOfViewAngle / 2f;
        bool player2InSight = angleToPlayer2 < fieldOfViewAngle / 2f;


        if (Vector2.Distance(transform.position, player.transform.position) < aggroRange && playerInSight)
        {
            patrol = false;
        }
        else if (Vector2.Distance(transform.position, player2.transform.position) < aggroRange && player2InSight)
        {
            patrol = false;
        }

        if (patrol)
        {

            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
                
                transform.Rotate(0, 180, 0);
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
                
                transform.Rotate(0, 180, 0);
            }
        }
        else 
        {
            speed = 5f;
            
            transform.Translate(lookDirection * -speed * Time.deltaTime);

            if (transform.position.x >= pointB.transform.position.x || transform.position.x <= pointA.transform.position.x)
            {
                Debug.Log("Past");
                
            }
           
        }
        
    }
}
