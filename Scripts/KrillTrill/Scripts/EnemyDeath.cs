using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float time = 5f;
    void Start(){Destroy(gameObject,time);}
    public GameObject deathEffect1,sound1;
    void OnCollisionEnter2D(Collision2D hit)
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Destroy(gameObject);    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Destroy(gameObject);   
    }
}
