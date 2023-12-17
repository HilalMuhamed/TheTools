using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Score score;
    public GameObject deathparticle1,deathparticle2;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }


    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("Bullet")||hit.CompareTag("EnemyBullet"))
        {
            score.addScore(100);
            Instantiate(deathparticle1,transform.position,Quaternion.identity);
            Instantiate(deathparticle2,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Player")||hit.gameObject.CompareTag("EnemyBullet"))
        {
            Instantiate(deathparticle1,transform.position,Quaternion.identity);
            Instantiate(deathparticle2,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

