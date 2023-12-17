using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{

    public Transform player;
    public float AgroRange;
    public float speed;
    private Rigidbody2D rb2d;
    private bool canDash = true;
    private bool facingRight;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dasingCooldown = 1f;
    public float dashingJump = 1500f;

    // Health System
    public HealthBarBoss healthBarBoss;
    public int maxHealth = 100;
    public int health;

    public GameObject deathEffect;
    public int noOfBullets;


    
    // [Header("Projectile Settings")]
    // public int numberOfProjectiles;
    // public float Speed;
    // public GameObject projectile;

    // private Vector2 starPoint;
    // private const float radius =1f;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBarBoss.SetMaxHealth(maxHealth);

    }


    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position,player.position);

        if(distToPlayer < AgroRange){
            ChasePlayer();
            if(canDash){
            StartCoroutine(Dash());
            }
        }
        else
        {
            StopChasePlayer();
        }

            if(isDashing){
            return;
    }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        healthBarBoss.SetHealth(health);
        if(health <= 0)
        {
            Die();
        }
    }

    void FixedUpdate(){
            if(isDashing){
            return;
        }
    }
    
    
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void ChasePlayer(){


        if(transform.position.x < player.position.x)
        {

            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            facingRight = true;
        }
        else
        {

            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            facingRight = false;
        }
    }

    void StopChasePlayer()
    {
        rb2d.velocity = new Vector2(0,rb2d.velocity.y);
    }
    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0.8f;
        //starPoint = transform.position;
        //SpawnProjectile(noOfBullets);
        if(facingRight){
            FindObjectOfType<AudioManager>().Play("EnemyJump");
            rb2d.AddForce(new Vector2((rb2d.velocity.x),dashingJump));
        }
        if(!facingRight){
            FindObjectOfType<AudioManager>().Play("EnemyJump");
            rb2d.AddForce(new Vector2((rb2d.velocity.x),dashingJump));
        }
        yield return new WaitForSeconds(dashingTime);
        rb2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }

    //     public void SpawnProjectile(int numberOfProjectiles)
    // {
    //     float angleStep =360f;
    //     float angle =0f;

    //     for (int i =0;i<=numberOfProjectiles-1;i++){
    //         float projectileDirXPosition = starPoint.x +Mathf.Sin((angle * Mathf.PI)/180)*radius;
    //         float projectileDirYPosition = starPoint.y +Mathf.Cos((angle * Mathf.PI)/180)*radius;

    //         Vector2 projectileVector = new Vector2(projectileDirXPosition,projectileDirYPosition);
    //         Vector2 projectileMoveDirection = (projectileVector - starPoint).normalized * Speed;

    //         GameObject Obj = Instantiate(projectile,starPoint,Quaternion.identity);
    //         Obj.GetComponent<Rigidbody2D>().velocity= new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);
    //         angle +=angleStep;
    //     }
    // }
}
