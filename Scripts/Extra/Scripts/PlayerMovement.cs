using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    private Rigidbody2D rb;
    private bool isJumping;
    public Animator animator;
    private bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        float horizontal =Input.GetAxis("Horizontal");
        if(horizontal < 0 && facingRight){Flip();} 
        if(horizontal > 0 && !facingRight){Flip();}
        animator.SetFloat("speed",Mathf.Abs(horizontal));

        rb.velocity = new Vector2(horizontal*speed,rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space)){Jump();}
    }
    void Jump()
    {
        if(!isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            // rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isJumping = true;
            animator.SetBool("isJumping",isJumping);
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping",isJumping);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0,180,0);
    }
}
