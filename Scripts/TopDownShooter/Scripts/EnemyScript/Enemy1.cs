using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public Transform t;
    public GameObject deathParticle1,deathParticle2;
    public Score score;

    void Start()
    {
        t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,t.position,speed*Time.deltaTime);
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
