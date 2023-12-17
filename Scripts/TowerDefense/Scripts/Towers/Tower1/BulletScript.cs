using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform target;
    [Header("Attributes")]
    public float bulletspeed = 5f;
    [Header("Refrence")]
    public Rigidbody2D rb;
    public float bulleDamage =1;

    public void SetTarget(Transform _target){target=_target;}

    void Start(){rb=GetComponent<Rigidbody2D>();Destroy(gameObject,0.5f);}
    void FixedUpdate()
    {
        if(!target){return;}
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletspeed;
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulleDamage);
        Destroy(gameObject);
    }
}
