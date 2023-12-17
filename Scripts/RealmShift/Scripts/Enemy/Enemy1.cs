using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float StoppingDistance;
    public float RetreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    public GameObject bulletFireParticle,sound1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         timeBtwShots = startTimeBtwShots;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(transform.position.y <= player.position.y + 5f)
        {transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,transform.position.y + 8f),speed*Time.deltaTime);}

        if(distToPlayer > StoppingDistance){transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);}

        else if(distToPlayer > RetreatDistance && distToPlayer < StoppingDistance){transform.position = this.transform.position;}

        else if(distToPlayer < RetreatDistance){transform.position = Vector2.MoveTowards(transform.position,player.position,-speed*Time.deltaTime);}

    if(timeBtwShots <= 0){
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(bulletFireParticle,transform.position,Quaternion.identity);
        Instantiate(projectile,transform.position,Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
    }
    else
    {
        timeBtwShots -= Time.deltaTime;
    }
    }
}