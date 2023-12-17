using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MiniBossBulletScript : MonoBehaviour
{
    public GameObject deathEffect;

    // [Header("Projectile Settings")]
    // public int numberOfProjectiles;
    // public float Speed;
    // public GameObject projectile;

    // private Vector2 starPoint;
    // private const float radius =1f;


    // public void SpawnProjectile(int numberOfProjectiles)
    // {
    //     float angleStep =360f;
    //     float angle =0f;

    //     for(int i =0;i<=numberOfProjectiles-1;i++){
    //         float projectileDirXPosition = starPoint.x +Mathf.Sin((angle * Mathf.PI)/180)*radius;
    //         float projectileDirYPosition = starPoint.x +Mathf.Cos((angle * Mathf.PI)/180)*radius;

    //         Vector2 projectileVector = new Vector2(projectileDirXPosition,projectileDirYPosition);
    //         Vector2 projectileMoveDirection = (projectileVector - starPoint).normalized * Speed;

    //         GameObject Obj = Instantiate(projectile,starPoint,Quaternion.identity);
    //         Obj.GetComponent<Rigidbody2D>().velocity= new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);
    //         angle +=angleStep;
    //     }
    // }
    //public Transform transfrom;
    private Vector2 moveDirection;
    private float moveSpeed;
    private void OnEnable(){Invoke("Destroy",8f);}
    void Start(){moveSpeed = 20f;}
    void Update()
    {transform.Translate(moveDirection*moveSpeed*Time.deltaTime);}
    public void SetMoveDirection(Vector2 dir){moveDirection = dir;}
    private void Destroy(){gameObject.SetActive(false);}
    private void OnDisable(){CancelInvoke();}
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            DestroyProjectile();
        }
        if (!other.CompareTag("Enemy"))
        {
            if(!other.CompareTag("GroundEnemy"))
            {
                if(!other.CompareTag("Bullet"))
                {
                    DestroyProjectile();
                }
            }
        }
        }

    void DestroyProjectile()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

}
