using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlayer : MonoBehaviour
{


    public float speed;
    public float jump;

    private float move;
    private Rigidbody2D rb;
    private bool isJumping ;

    // Dashing
    private bool canDash = true;
    private bool facingRight;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    private float dasingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float JumpBufferTime = 0.2f;
    private float JumpBufferTimeCounter;
    

    public float fallDistance = -50f;
    public int Respawn;
    public Transform player;

    public GameObject dashEffect;
    public ParticleSystem Jumpdust;
    public ParticleSystem Movedust;

    public ParticleSystem deathParticle;

    public int life =1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if(!isJumping)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if(player.position.y <= fallDistance)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        if(Input.GetButtonDown("Jump"))
        {
            JumpBufferTimeCounter = JumpBufferTime;
        }
        else
        {
            JumpBufferTimeCounter -= Time.deltaTime;
        }



        if(isDashing){
            return;
        }
        move = Input.GetAxisRaw("Horizontal");
        if(move < 0 ){
            facingRight = false;
            if(!isJumping)
            {
                CreateDust2();
            }
            
        }
        if(move > 0 ){
            facingRight = true;
            if(!isJumping)
            {
                CreateDust2();
            }
        }

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (JumpBufferTimeCounter > 0f && coyoteTimeCounter > 0f)
        {
            FindObjectOfType<AudioManager>().Play("JumpSound");
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            JumpBufferTimeCounter = 0f;
            isJumping = true;
            CreateDust();
        }
        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            
            rb.velocity = new Vector2( rb.velocity.x , rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
        }

    }
    private void FixedUpdate(){
        if(isDashing){
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if(other.gameObject.CompareTag("GroundEnemy"))
        {
            isJumping = false;
        }
    }

    
    private IEnumerator Dash(){

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if(facingRight){
            FindObjectOfType<AudioManager>().Play("DashSound");
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        if(!facingRight){
            FindObjectOfType<AudioManager>().Play("DashSound");
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);
        }
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }

    void CreateDust(){
        Jumpdust.Play();
    }
    void CreateDust2(){
        Movedust.Play();
    }
    public void DeathParticle()
    {
        if(life >0)
        {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        life--;
    }
    }
}
