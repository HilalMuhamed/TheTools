using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class rocket : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public float speed = 3f;
    public float rotspeed =200f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float rot = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity = -rot * rotspeed;
        rb.velocity = transform.up * speed;
    }
}
