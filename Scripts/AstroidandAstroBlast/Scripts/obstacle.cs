using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed  =5;
    public GameObject deathParticle;
    public GameObject sound;
    private void Update()
    {
        transform.Translate(Vector2.left *speed*Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if(hitinfo.CompareTag("Player"))
        {
            hitinfo.GetComponent<player>().health -=damage;
            Instantiate(sound,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Instantiate(deathParticle,transform.position,Quaternion.identity);
        }
        else if(transform.position.x <-50)
        {
            Instantiate(sound,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Instantiate(deathParticle,transform.position,Quaternion.identity);}
    }
}
