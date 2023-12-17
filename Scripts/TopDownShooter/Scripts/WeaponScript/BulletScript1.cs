using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript1 : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public GameObject deathParticle1,deathParticle2;

    public Transform player;
    private Vector2 target;
    public GameObject sound1;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target  = new Vector2(player.position.x,player.position.y);
         
    }

    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position ,target,force*Time.deltaTime);

        if(transform.position.x == target.x){
          Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        Destroy(gameObject,6f);
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Player"))
     {
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
        Destroy(gameObject);
        
        }   
    }
}
