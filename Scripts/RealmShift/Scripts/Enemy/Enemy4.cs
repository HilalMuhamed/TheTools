using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public float speed;
    public Transform player;
    
    public float StoppingDistance;
    public float RetreatDistance;
    public bool isFacingRight = true;
    float intialScale;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        intialScale = transform.localScale.x;
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(transform.position.y <= player.position.y + 5f) 
        {transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,transform.position.y + 8f),speed*Time.deltaTime);}
            
        if(distToPlayer > StoppingDistance)
        {transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        isFacingRight = true;
        Flip();
        }
        else if(distToPlayer > RetreatDistance && distToPlayer < StoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if(distToPlayer < RetreatDistance)
        {
        transform.position = Vector2.MoveTowards(transform.position,player.position,-speed*Time.deltaTime);
        isFacingRight = false;
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
