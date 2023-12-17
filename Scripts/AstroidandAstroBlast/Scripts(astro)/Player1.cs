using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
    public GameObject deathparticle1,deathparticle2,sound1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(isDashing){return;}
        // mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 rotation = mousePos - transform.position;
        // mousePos.z = 0f;
        // // float roatz = Mathf.Atan2(rotation.y,rotation.x)* Mathf.Rad2Deg;
        // // transform.rotation = Quaternion.Euler(0,0,roatz);
        // if(transform.position == mousePos)
        // {
        //     transform.rotation = Quaternion.identity;
        //     transform.position = Vector2.zero;
        // }
        // else{
        // float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        // Vector3 direction = mousePos - transform.position;
        // direction.Normalize();
        // Vector3 velocity = direction * speed;
        // transform.position += velocity * Time.deltaTime;
        // }
        if(Input.GetMouseButtonDown(1)&& canDash){StartCoroutine(Dash());}
    }
    void FixedUpdate()
    {
        if(isDashing){return;}
        mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector2 direction = mousePos - transform.position;
        direction.Normalize();
        float rot = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity = -rot * rotspeed;
        rb.velocity = transform.up * speed;
    }
        IEnumerator Dash()
    {
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(deathparticle1,transform.position,Quaternion.identity);
        Instantiate(deathparticle2,transform.position,Quaternion.identity);
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
