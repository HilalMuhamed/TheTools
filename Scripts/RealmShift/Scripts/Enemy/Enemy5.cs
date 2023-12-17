using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour
{
    public float speed;
    public float AgroRange;
    private Rigidbody2D rb;
    public bool isFacingRight = true;
    float intialScale;

    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        intialScale = transform.localScale.x;
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer < AgroRange)
        {
            ChasePlayer();
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            isFacingRight = false;
            Flip();
        }
        else if(transform.position.x == player.position.x)
        {rb.velocity =new Vector2(0,rb.velocity.y);}
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isFacingRight = true;
            Flip();
        }
    }
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        if(!isFacingRight)
        {
            localScale.x = -intialScale;
            transform.localScale = localScale;
        }
        else
        {
            localScale.x = intialScale;
            transform.localScale = localScale;
        }
    }
}
