using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour
{


    public Transform player;
    public float AgroRange;
    public float speed;
    private Rigidbody2D rb2d;
    //private bool FollowPlayer = true;

    // For dashing
    
    private bool canDash = true;
    private bool facingRight;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashinStrength = 10f;
    public float dashingTime = 0.2f;
    public float dasingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;




    public int health = 6;
    public GameObject deathEffect;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position,player.position);

        if(distToPlayer < AgroRange){
            // code to chase player
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
        FindObjectOfType<AudioManager>().Play("ExplosionSound");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
    void ChasePlayer(){

        //Enemy left of palyer , To move right
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            facingRight = true;
        }
        else
        {
        //Enemy right of player, to move left
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("ExplosionSound");
        //float originalGravity = rb2d.gravityScale;
        //rb2d.gravityScale = 0f;
        if(facingRight){
            if(transform.position.y < player.position.y)
            {
                rb2d.velocity = new Vector2(transform.localScale.x * dashingPower,transform.localScale.y *dashinStrength);
                }
            else  if(transform.position.y > player.position.y)
            {
                rb2d.velocity = new Vector2(transform.localScale.x * dashingPower,transform.localScale.y *-dashinStrength);
            }
            else
            {
                rb2d.velocity = new Vector2(transform.localScale.x * dashingPower,transform.localScale.y);
            }
        }
        if(!facingRight){
            if(transform.position.y < player.position.y)
            {
                rb2d.velocity = new Vector2(transform.localScale.x * -dashingPower,transform.localScale.y *dashinStrength);
                }
            else  if(transform.position.y > player.position.y)
            {
                rb2d.velocity = new Vector2(transform.localScale.x * -dashingPower,transform.localScale.y *-dashinStrength);
            }
            else
            {
                rb2d.velocity = new Vector2(transform.localScale.x * -dashingPower,transform.localScale.y);
            }
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        
        //rb2d.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }
        void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die();
        }

    }
}

