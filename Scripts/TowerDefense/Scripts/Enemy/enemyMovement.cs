using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [Header("Reference")]
    public Rigidbody2D rb;
    [Header("Attributes")]
    public float movespeed = 2f;
    private Transform target;
    private int pathindex =0;

    private float baseSpeed;

    void Start(){baseSpeed=movespeed; target=levelManger.main.path[pathindex]; rb=GetComponent<Rigidbody2D>();}
    void Update()
    {
        if(Vector2.Distance(target.position,transform.position) <= 0.1f){pathindex++;}
        if(pathindex == levelManger.main.path.Length){EnemySpawner.onEnemyDestroy.Invoke(); Destroy(gameObject); return;}
        else{target=levelManger.main.path[pathindex];}
    }
    void FixedUpdate()
    {
        Vector2 direction = (target.position-transform.position).normalized;
        rb.velocity = direction * movespeed;
    }
    public void UpdateSpeed(float newSpeed)
    {
        movespeed=newSpeed;
    }
    public void ResetSpeed(){movespeed=baseSpeed;}
    
}
