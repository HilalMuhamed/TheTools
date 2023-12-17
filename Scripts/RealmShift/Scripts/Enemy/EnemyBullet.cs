using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public Transform player;
    private Vector2 target;
    public GameObject bulletDestructionParticle1,bulletDestructionParticle2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target  = new Vector2(player.position.x,player.position.y);
    }

    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position ,target,force*Time.deltaTime);

        if(transform.position.x == target.x)
        {Destroy(gameObject,0.1f); Instantiate(bulletDestructionParticle1,transform.position,Quaternion.identity);  Instantiate(bulletDestructionParticle2,transform.position,Quaternion.identity);}
        Destroy(gameObject,6f);
        // Instantiate(bulletDestructionParticle,transform.position,Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Player")||hit.gameObject.CompareTag("Ground"))
        {
            Instantiate(bulletDestructionParticle1,transform.position,Quaternion.identity);
            Instantiate(bulletDestructionParticle2,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Player")||hit.CompareTag("Ground")){Destroy(gameObject); Instantiate(bulletDestructionParticle1,transform.position,Quaternion.identity);
      Instantiate(bulletDestructionParticle2,transform.position,Quaternion.identity);}   
    }
}