using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public Rigidbody2D rb;
    public float size =1f;
    public float speed =50f;
    public float maxLife = 10f;
    public float minSize =0.5f;
    public float maxSize = 1.2f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    transform.eulerAngles = new Vector3(0f,0f,Random.value * 360f);
    transform.localScale = Vector3.one * size;
    rb.mass = size;
    
    }
    public void Trajectory(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject,maxLife);
    }
}
