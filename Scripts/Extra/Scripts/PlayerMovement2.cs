using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public int speed;
    private bool isJumping;
    public int jumpForce;
    private Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(horizontal));
        Vector2 mov = new Vector2(horizontal,0f)*speed*Time.deltaTime;
        transform.Translate(mov);
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
}
