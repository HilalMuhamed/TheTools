using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;

    public Rigidbody2D rb;

    public int damage = 1;

    public float lifeTime;

    public GameObject deathEffect;
    



    void Start()
    {
       
        Invoke("DestroyProjectile", lifeTime);

    }

    void Update()
    {
        rb.velocity = transform.right * speed;
        //transform.Translate(transform.right * speed * Time.deltaTime);


    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Enemy2 enemy2 = hitInfo.GetComponent<Enemy2>();
        Enemy3 enemy3 = hitInfo.GetComponent<Enemy3>();
        Enemy4 enemy4 = hitInfo.GetComponent<Enemy4>();
        EnemyAi enemy5 = hitInfo.GetComponent<EnemyAi>();
        EnemyPatrol enemy6 = hitInfo.GetComponent<EnemyPatrol>();
        Enemy6 enemy7 = hitInfo.GetComponent<Enemy6>();
        Enemy5 enemy8 = hitInfo.GetComponent<Enemy5>();
        EnemyBoss enemyboss = hitInfo.GetComponent<EnemyBoss>();
        EnemyMiniBoss enemyminiboss = hitInfo.GetComponent<EnemyMiniBoss>();


        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }
        if(enemy3 != null)
        {
            enemy3.TakeDamage(damage);
        }
        if(enemy4 != null)
        {
            enemy4.TakeDamage(damage);
        }
        if(enemy5 != null)
        {
            enemy5.TakeDamage(damage);
        }
        if(enemy6 != null)
        {
            enemy6.TakeDamage(damage);
        }
        if(enemy7 != null)
        {
            enemy7.TakeDamage(damage);
        }
        if(enemy8 != null)
        {
            enemy8.TakeDamage(damage);
        }
        if(enemyboss != null)
        {
            enemyboss.TakeDamage(damage);
        }
        if(enemyminiboss != null)
        {
            enemyminiboss.TakeDamage(damage);
        }

        if (!hitInfo.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        
    }

    void DestroyProjectile()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("BulletDestroyed");
        Destroy(gameObject);
    }
    }

