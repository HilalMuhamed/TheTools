using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject deathEffect1,deathEffect2,sound1;
    void OnCollisionEnter2D(Collision2D hit)
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Instantiate(deathEffect2, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Instantiate(deathEffect2, transform.position, Quaternion.identity);
        Destroy(gameObject);   
    }
}
