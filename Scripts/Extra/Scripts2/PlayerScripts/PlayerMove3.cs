using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3: MonoBehaviour
{
Rigidbody2D body;

float horizontal;
float vertical;
float moveLimiter = 0.8f;

public float runSpeed = 20.0f;

    public bool canDash = true;
    private bool isDashing;
    public float dashingTime,dasingCooldown,dashingPower;
    public TrailRenderer tr;
  
void Start ()
{
   body = GetComponent<Rigidbody2D>();
   tr = GetComponent<TrailRenderer>();
}

void Update()
{
    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){StartCoroutine(Dash());}
                                                 // Gives a value between -1 and 1
   horizontal = Input.GetAxisRaw("Horizontal");  // -1 is left
   vertical   = Input.GetAxisRaw("Vertical");    // -1 is down
}

void FixedUpdate()
{
    if(isDashing){return;}
   if (horizontal != 0 && vertical != 0)  // Check for diagonal movement
   {
          // limit movement speed diagonally, so you move at 70% speed
      horizontal *= moveLimiter;
      vertical   *= moveLimiter;
   } 

   body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
}
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        body.velocity = new Vector2(horizontal * dashingPower, vertical * dashingPower);
        // transform.position  = (Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal")*dashingPower*Time.deltaTime,Input.GetAxis("Vertical")*dashingPower*Time.deltaTime);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }
}
