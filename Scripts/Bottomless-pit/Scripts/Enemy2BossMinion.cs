using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2BossMinion: MonoBehaviour
{
    public GameObject deathEffect1,deathEffect2,sound1;
    private Vector2 moveDirection;
    public Transform target;
    public Rigidbody2D rb;
    public float speed = 3f;
    public float rotspeed =200f;
    private void OnEnable(){Invoke("Destroy",3f);}
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float rot = Vector3.Cross(direction,transform.up).z;
        rb.angularVelocity = -rot * rotspeed;
        rb.velocity = transform.up * speed;
    }
    public void SetMoveDirection(Vector2 dir)
    {
    moveDirection = dir;
    transform.Translate(moveDirection*speed*Time.deltaTime);}

    private void OnDisable(){CancelInvoke();}
        void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            DestroyProjectile();
        }
        if (!other.CompareTag("Enemy"))
        {
                if(!other.CompareTag("Bullet"))
                {
                    DestroyProjectile();
                }
        }
        }

    void DestroyProjectile()
    {
        Instantiate(sound1, transform.position, Quaternion.identity);
        Instantiate(deathEffect1, transform.position, Quaternion.identity);
        Instantiate(deathEffect2, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
