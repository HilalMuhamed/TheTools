using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public GameObject deathparticle1,deathparticle2,sound1;
    void Start()
    {
        Destroy(gameObject,5f);
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Enemy") || hit.gameObject.CompareTag("Astroid"))
        {
            Instantiate(sound1,transform.position,Quaternion.identity);
            Instantiate(deathparticle1,transform.position,Quaternion.identity);
            Instantiate(deathparticle2,transform.position,Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
}
