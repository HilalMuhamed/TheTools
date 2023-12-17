using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossBulletScript : MonoBehaviour
{
    public GameObject deathEffect1,deathEffect2,sound1;
    private Vector2 moveDirection;
    public float moveSpeed =10f;
    private void OnEnable(){Invoke("Destroy",3f);}

    void Update(){transform.Translate(moveDirection*moveSpeed*Time.deltaTime);}
    public void SetMoveDirection(Vector2 dir){moveDirection = dir;}
    private void Destroy(){gameObject.SetActive(false);}
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
