using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public GameObject deathParticle1,deathParticle2;
    public Score score;
    public GameObject sound1;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
     if(hit.CompareTag("Player"))
     {
        score.addScore(50);
        Destroy(gameObject);
        Instantiate(sound1,transform.position,Quaternion.identity);
        Instantiate(deathParticle1,transform.position,Quaternion.identity);
        Instantiate(deathParticle2,transform.position,Quaternion.identity);
        }   
    }
}
