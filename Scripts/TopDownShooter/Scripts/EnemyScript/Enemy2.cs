using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    public Transform player;
    public GameObject deathParticle1,deathParticle2;
    public Score score;
    public GameObject sound1;
    public float retreatDistance;
    

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
         timeBtwShots = startTimeBtwShots;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

            if(distToPlayer > retreatDistance){
            ChasePlayer();
            }
            
        
 
        

    if(timeBtwShots <= 0){
        Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(projectile,transform.position,Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
    }
    else{
        timeBtwShots -= Time.deltaTime;
    }
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
            
        }
        else if (transform.position.x > player.position.x)
        {
           transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Bullet"))
     {
        score.addScore(10);
        Destroy(gameObject);
        Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
        }   
    }
}
