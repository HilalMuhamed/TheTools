using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float retreatDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwShots = startTimeBtwShots;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

            if(distToPlayer > retreatDistance){ChasePlayer();}
    if(timeBtwShots <= 0){
        Instantiate(projectile,transform.position,Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
    }
    else{timeBtwShots -= Time.deltaTime;}}
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

}
