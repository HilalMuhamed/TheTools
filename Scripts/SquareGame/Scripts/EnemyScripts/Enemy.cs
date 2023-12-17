using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float speed;
    public float AgroRange;
    private Rigidbody2D rb2d;



    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < AgroRange)
        {
            ChasePlayer();
        }
        else
        {
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }
    }
    public int health = 6;


    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    public GameObject deathEffect;
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
    }
}
