using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public int speed;
    // void Update()
    // {

    //     if(Input.GetKey(KeyCode.RightArrow)){
    //         transform.Translate(Vector2.right*speed*Time.deltaTime);}
    //     if(Input.GetKey(KeyCode.LeftArrow)){
    //         transform.Translate(-Vector2.right*speed*Time.deltaTime);}
    //     if(Input.GetKey(KeyCode.UpArrow)){
    //         transform.Translate(Vector2.up*speed*Time.deltaTime);}
    //     if(Input.GetKey(KeyCode.DownArrow)){
    //         transform.Translate(-Vector2.up*speed*Time.deltaTime);}
    // }
    // public int speed;
    // private Rigidbody2D rb;
    // private Vector2 moveVelocity;
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }
    // void Update()
    // {
    //     Vector2 input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    //     moveVelocity = input.normalized * speed;
    // }
    // void FixedUpdate()
    // {
    //     rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);   
    // }}


    public float speed;
    void FixedUpdate()
    {
        
        transform.position = (Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal")*speed*Time.deltaTime,Input.GetAxis("Vertical")*speed*Time.deltaTime);
        // if( transform.position.y < -10  || transform.position.y > 10 )
        // {
        //     transform.position =    new Vector2( (transform.position.x),-(transform.position.y));
        // }
        // if(transform.position.x < -19.5 ||transform.position.x > 19.5 )
        // {
        //     transform.position =    new Vector2( -(transform.position.x),(transform.position.y));
        // }
}}
