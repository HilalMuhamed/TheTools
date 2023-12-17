using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    
public int speed;
private Vector2 targetPos;
public int distance; 
public int maxHeight;
public int minHeight;
public int health =3;
private shake s;
public Text healthDispaly;

public GameObject gameOver;
public GameObject deathParticle;
void Start() 
{
//    s= GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
}


void Update()
{
    healthDispaly.text = "HP: " + health.ToString();
    if(health <=0){
        gameOver.SetActive(true);
        Instantiate(deathParticle,transform.position,Quaternion.identity);
        Destroy(gameObject);    }
        transform.position = Vector2.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y<maxHeight && (transform.position.y == 2 || transform.position.y ==0||transform.position.y == -2 || transform.position.y ==0||transform.position.y == 4 || transform.position.y ==-4))
        {
            targetPos = new Vector2(transform.position.x,transform.position.y+distance);
         //   s.camShake();
           // Instantiate(deathParticle,transform.position,Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&& transform.position.y>minHeight&& (transform.position.y == 2 || transform.position.y ==0||transform.position.y == -2 || transform.position.y ==0||transform.position.y == 4 || transform.position.y ==-4))
        {
            targetPos = new Vector2(transform.position.x,transform.position.y-distance);
          //  s.camShake();
           //`Instantiate(deathParticle,transform.position,Quaternion.identity);
        }
}

}
