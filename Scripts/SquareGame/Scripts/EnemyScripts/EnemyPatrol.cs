using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private float distance = 2f;
    
    private bool movingRight = true;

    public Transform GroundDetection;

    public int health = 6;

    public GameObject deathEffect;


    void Update(){

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Enemy")){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0,-180,0);
                movingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0,0,0);
                movingRight = true;
                }
        }
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
