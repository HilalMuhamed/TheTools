using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

    public float speed = 10f;

    //public Rigidbody2D rb;

    public int damage = 1;

    public float lifeTime;

    public Transform player;

    private Vector2 target;

    public GameObject deathEffect;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target  = new Vector2(player.position.x,player.position.y);
        Invoke("DestroyProjectile", lifeTime);


    }

    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position ,target,speed*Time.deltaTime);

        if(transform.position.x == target.x){
            DestroyProjectile();
        }
        

    }
        void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            DestroyProjectile();
        }
        if (!other.CompareTag("Enemy"))
        {
            if(!other.CompareTag("GroundEnemy"))
            {
            DestroyProjectile();
            }
        }
        }

    void DestroyProjectile()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    }
