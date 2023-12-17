using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float totalhealth = 20;
    public float currentHealth ;
    public TimerScript t;
    public GameObject deathParticle;
    public GameObject healthBar;
    public Score score;
    public GameObject BossEntry;
    public GameObject sound1;

    void Start()
    {
        t.SetMaxTimer(totalhealth);
        currentHealth = totalhealth;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    void Update()
    {
        if (currentHealth <=0)
        {
            Instantiate(deathParticle,transform.position,Quaternion.identity);
            Instantiate(sound1,transform.position,Quaternion.identity);
            score.addScore(2000);
            Destroy(BossEntry);
            Destroy(healthBar);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth--;
            t.SetTimer(currentHealth);
        }
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Bullet"))
        {
            currentHealth--;
            t.SetTimer(currentHealth);
        }
    }
}
