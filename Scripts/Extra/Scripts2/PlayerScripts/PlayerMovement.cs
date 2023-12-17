using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool canDash = true;
    private bool isDashing;
    public float dashingTime,dasingCooldown,dashingPower;
    public TrailRenderer tr;
    public Rigidbody2D rb;
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash){StartCoroutine(Dash());}
    }
    void FixedUpdate()
    {
        
        transform.position = (Vector2)transform.position + new Vector2(Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime,Input.GetAxisRaw("Vertical")*speed*Time.deltaTime);
        if(isDashing){return;}
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        transform.position  = (Vector2)transform.position + new Vector2(Input.GetAxis("Horizontal")*dashingPower*Time.deltaTime,Input.GetAxis("Vertical")*dashingPower*Time.deltaTime);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dasingCooldown);
        canDash = true;
    }
}
