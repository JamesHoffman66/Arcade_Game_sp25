using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float VerticalInput;
    public Rigidbody rb2;
    public bool isOnGround;
   
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * VerticalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Alpha4) && isOnGround) 
        {
            rb2.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnGround = true;
            
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
           
        }


    }
}   
