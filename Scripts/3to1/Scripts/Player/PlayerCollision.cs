using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    private int colliderTrigger =0;
    public GameObject Particle,GreenSlime,sound1,sound2,Particle2;
    private bool won = false;
    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("Player1")|| hit.CompareTag("Player2")||hit.CompareTag("Player3"))
        {
            colliderTrigger ++;
            if(colliderTrigger == 2)
            {
                won = true;
                Instantiate(GreenSlime,transform.position,Quaternion.identity);
                Instantiate(Particle,transform.position,Quaternion.identity);
                Instantiate(sound1,transform.position,Quaternion.identity);
                Invoke("YouWon",0.3f);
                gameObject.SetActive(false);}
            else if(colliderTrigger == 1){if(won==false){Invoke("YouLost",0.4f);}}
        }
        if(hit.CompareTag("Enemy"))
        {
            Instantiate(Particle,transform.position,Quaternion.identity);
            Invoke("YouLost",0.2f);
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if(hit.CompareTag("Player1")|| hit.CompareTag("Player2")||hit.CompareTag("Player3"))
        {
        colliderTrigger --;    
        }
    }
    void YouWon(){
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);Debug.Log("We won");
                }
    void YouLost(){
        if(won == false){Debug.Log("We lost");
                Instantiate(Particle2,transform.position,Quaternion.identity);
                Instantiate(sound2,transform.position,Quaternion.identity);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }}
}
