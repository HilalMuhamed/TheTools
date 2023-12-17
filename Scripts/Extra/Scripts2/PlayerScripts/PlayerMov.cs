using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 mousePos;

    public Rigidbody2D rb;
    public float rotspeed =400f;
    
    private bool canDash =true;
    private bool isDashing =false;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    public TrailRenderer tr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }
    void Update()
    {
        if(isDashing){return;}
        if(Input.GetMouseButtonDown(1)&& canDash){StartCoroutine(Dash());}
    }
    void FixedUpdate()
    {
        if(isDashing){return;}
        mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        if(mousePos != transform.position)
        {
        Vector2 direction = mousePos - transform.position;
        direction.Normalize();
        float rot = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity = -rot * rotspeed;
        rb.velocity = transform.up * speed;
        }
    }
        IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = transform.up * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
