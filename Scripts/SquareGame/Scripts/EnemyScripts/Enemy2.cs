using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy2 : MonoBehaviour
{


    public float speed;
    public float AgroRange;
    public float retreatDistance;
    private Rigidbody2D rb2d;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform player;
    public GameObject projectile;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
            if(distToPlayer < AgroRange)
        {
            if(distToPlayer > retreatDistance){
            ChasePlayer();
            }
            else
            {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        

    if(timeBtwShots <= 0){
        Instantiate(projectile,transform.position,Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
    }
    else{
        timeBtwShots -= Time.deltaTime;
    }
    }

    public int health = 6;
    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

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

