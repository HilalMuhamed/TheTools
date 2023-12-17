using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public int speed;
    public bool isFacingRight;
    private Rigidbody2D rb;

    public bool isJumping = false;
    public int jumpStregth;

    private bool canDash =true;
    private bool isDashing =false;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public GameObject jumpParticle;
    public GameObject LandingParticle; 
    public GameObject dashParticle;
    public GameObject deathParticle1,deathParticle2,sound1,sound2,sound3;
    public float totalhealth = 3;
    public float currentHealth ;
    public Transform jumpSpotForParticle;

    public TrailRenderer tr;

    public TimerScript t;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t.SetMaxTimer(totalhealth);
        currentHealth = totalhealth;
    }
    void Update()
    {
        if(isDashing){return;}
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
        if(!isJumping)
        {
            Instantiate(sound1,transform.position,Quaternion.identity);
            rb.AddForce(new Vector2(rb.velocity.x,jumpStregth));
        }
        }
        Flip();
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){StartCoroutine(Dash());}
        if (currentHealth <=0)
        {
            Instantiate(deathParticle1,transform.position,Quaternion.identity);
            Instantiate(deathParticle2,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
            Invoke("Retry",2f);
            // Destroy(gameObject);
        }
    }
    // private void OnDestroy()
    // {
    //     Invoke("Retry", 2f);
    // }
    void Retry(){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);}
    void FixedUpdate()
    {
        if(isDashing){return;}
        rb.velocity = new Vector2(horizontal*speed,rb.velocity.y);
        
    }
    void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(sound3,transform.position,Quaternion.identity);
            currentHealth--;
            t.SetTimer(currentHealth);
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Instantiate(sound3,transform.position,Quaternion.identity);
            currentHealth--;
            t.SetTimer(currentHealth);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Instantiate(LandingParticle,jumpSpotForParticle.position,Quaternion.identity);
        }

    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            Instantiate(sound3,transform.position,Quaternion.identity);
            currentHealth = currentHealth -1;
            t.SetTimer(currentHealth);
        }
        if (hit.CompareTag("EnemyBullet"))
        {
            Instantiate(sound3,transform.position,Quaternion.identity);
            currentHealth = currentHealth -1;
            t.SetTimer(currentHealth);
        }
        if (hit.CompareTag("Ground"))
        {
            isJumping = false;
            Instantiate(LandingParticle,transform.position,Quaternion.identity);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            Instantiate(jumpParticle,jumpSpotForParticle.position,Quaternion.identity);
        }
    }

    IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        Instantiate(dashParticle,transform.position,Quaternion.identity);
        Instantiate(sound2,transform.position,Quaternion.identity);
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
