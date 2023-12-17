using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDeath : MonoBehaviour
{
    public GameObject deathparticle1,deathparticle2,sound1;
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("Player") || hit.gameObject.CompareTag("Bullet"))
        {
            Instantiate(sound1,transform.position,Quaternion.identity);
            Instantiate(deathparticle1,transform.position,Quaternion.identity);
         Instantiate(deathparticle2,transform.position,Quaternion.identity);  
         Destroy(gameObject);}
        if(hit.gameObject.CompareTag("Astroid"))
        {
            Instantiate(sound1,transform.position,Quaternion.identity);
            Instantiate(deathparticle1,transform.position,Quaternion.identity); 
        Instantiate(deathparticle2,transform.position,Quaternion.identity); 
        Destroy(gameObject);}
    }
}
