using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player2Controller : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float VerticalInput;
    private float spawnTimer = 0f;
    public Rigidbody rb2;
    public bool isOnGround;
    public GameObject Player1;
    public GameObject projectile;
    public GameObject projectileSpawner;
    private float spawnCooldown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        
        spawnTimer = 2f;


    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * VerticalInput * speed * Time.deltaTime);
        spawnTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha4) && isOnGround) 
        {
            rb2.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            
           

            if (spawnTimer >= spawnCooldown)
            {

                SpawnProjectiles();
                spawnTimer = 0f;
            }
        }

    }
    private void SpawnProjectiles()
    {
        Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("EnemyProjectile")) 
        {
            Player1.GetComponent<Player1Controller>();
            Player1Controller player1controller = Player1.GetComponent<Player1Controller>();
            player1controller.gameOver = true;

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnGround = true;
            
        }
       
       


    }
}   
