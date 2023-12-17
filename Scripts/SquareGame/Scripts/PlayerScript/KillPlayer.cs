using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int Respawn;
    private GameObject Player ;
    private GameObject PlayerItem;
    private GameObject PlayerTrail;
    SpriteRenderer spriteRenderer1;
    //SpriteRenderer spriteRenderer2;
    TrailRenderer trailRenderer;
    
    
    void Start()
    {
         Player = GameObject.FindGameObjectWithTag("Player");
         PlayerItem = GameObject.FindGameObjectWithTag("PlayerItem");
         PlayerTrail = GameObject.FindGameObjectWithTag("PlayerTrail");
         spriteRenderer1 = Player.GetComponent<SpriteRenderer>();
         //spriteRenderer2 = PlayerItem.GetComponent<SpriteRenderer>();
         trailRenderer = PlayerTrail.GetComponent<TrailRenderer>();
         }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        MovingPlayer movingPlayer = other.GetComponent<MovingPlayer>();
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //FindObjectOfType<AudioManager>().Play("BulletDestroyed");
        //Destroy(Player);
        spriteRenderer1.enabled = false;
        Destroy(PlayerItem);
        //spriteRenderer2.enabled = false;
        trailRenderer.enabled = false;
        movingPlayer.DeathParticle();
        Invoke("Restart",1f);}
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
