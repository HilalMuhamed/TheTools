using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jump;
    public ScoreManager s;
    public bool PlayerAlive = true;
    public int minHeight = -6;
    public int maxHeight = 6;
    public GameObject d1;
    public GameObject d2;
    public GameObject d3;
    public GameObject d4;
    public GameObject hit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        s = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }
    void FixedUpdate()
    {
        if((Input.GetKeyDown(KeyCode.Space)||Input.touchCount > 0)&&PlayerAlive)
        {
            rb.velocity = new Vector2(rb.velocity.x,jump);
            
        }
        if(transform.position.y < minHeight || transform.position.y > maxHeight)
        {
            PlayerAlive = false;
            s.gameOver();
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerAlive = false;
        Instantiate(hit,transform.position,Quaternion.identity);
        Instantiate(d1,transform.position,Quaternion.identity);
        Instantiate(d2,transform.position,Quaternion.identity);
        Instantiate(d3,transform.position,Quaternion.identity);
        Instantiate(d4,transform.position,Quaternion.identity);
        Invoke("GameOver",1f);
         
    }
    void GameOver(){s.gameOver();}
}
