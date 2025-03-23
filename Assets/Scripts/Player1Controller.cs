using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float horizontalInput;
    public Rigidbody rb;
    public bool isOnGround;
    public float gravityMod;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (gameOver)
        {
            Debug.Log("Game Over");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            isOnGround = true;

        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            LivesCounterp1.instance.DecreaseLives();
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {

            Destroy(other.gameObject);
            LivesCounterp1.instance.DecreaseLives();

        }
    }
}
