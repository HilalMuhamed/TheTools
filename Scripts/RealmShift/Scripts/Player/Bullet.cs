using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public GameObject bulletDestructionParticle1,bulletDestructionParticle2,sound1;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction =mousePos - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized *force;
    }
    void Update()
    {
        Destroy(gameObject,5f);
        //Instantiate(bulletDestructionParticle,transform.position,Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Enemy")||hit.CompareTag("Ground"))
     {
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(bulletDestructionParticle1,transform.position,Quaternion.identity);
         Instantiate(bulletDestructionParticle2,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }   
    }
}
