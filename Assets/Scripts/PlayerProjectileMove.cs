using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("EnemyProjectile") || other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
