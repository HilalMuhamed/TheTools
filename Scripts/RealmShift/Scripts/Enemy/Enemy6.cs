using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour
{

    public Transform player;
    public float AgroRange;
    public float speed;
    private Rigidbody2D rb;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 400f;
    public float dashingTime = 0.2f;
    public float dasingCooldown = 1f;
    public bool isJumping = false;
    public GameObject dashParticle,sound1;
    public bool isFacingRight = true;
    float intialScale;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        intialScale = transform.localScale.x;
    }

    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position,player.position);

        if(distToPlayer < AgroRange)
        {
            ChasePlayer();
            if(canDash && !isJumping){StartCoroutine(Dash());}
        }
        else{StopChasePlayer();}
        if(isDashing){return;}
    }


    void FixedUpdate(){if(isDashing){return;}}
    
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
    void StopChasePlayer()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        Instantiate(dashParticle,transform.position,Quaternion.identity);
        Instantiate(sound1,transform.position,Quaternion.identity);
        rb.AddForce(new Vector2(rb.velocity.x, dashingPower));
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }
        void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
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
