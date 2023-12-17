using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public Transform player;
    private Vector2 target;

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
            Destroy(gameObject);
        }
        Destroy(gameObject,6f);
    }
}
