using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    public GameObject bulletDestructionParticle,sound1;
    public float destroytime = 6f;
    void Start()
    {
        Invoke("Des",destroytime);
    }
    void Des()
    {
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(bulletDestructionParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
             Instantiate(sound1,transform.position,Quaternion.identity);
            Instantiate(bulletDestructionParticle,transform.position,Quaternion.identity);
            Destroy(gameObject,0.3f);
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Player"))
     {
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(bulletDestructionParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }   
    }
}