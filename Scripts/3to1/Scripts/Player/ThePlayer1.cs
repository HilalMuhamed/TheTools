using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePlayer1 : MonoBehaviour
{
    public GridManager grid;
    public int width,height;
    public GameObject Particle,sound;
    void Start()
    {
        height =grid.GivePlayerheight();
        width =grid.GivePlayerwidth();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){Instantiate(sound,transform.position,Quaternion.identity);
        if(transform.position.y < height-1)
        {
            Instantiate(Particle,transform.position,Quaternion.identity);
            transform.position = new Vector3(transform.position.x,transform.position.y + 1f,-1);
            Instantiate(Particle,transform.position,Quaternion.identity);}
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){Instantiate(sound,transform.position,Quaternion.identity);
        if(transform.position.y > 0)
        {
            Instantiate(Particle,transform.position,Quaternion.identity);
            transform.position = new Vector3(transform.position.x,transform.position.y -1f,-1);
            Instantiate(Particle,transform.position,Quaternion.identity);}
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){Instantiate(sound,transform.position,Quaternion.identity);
        if(transform.position.x < width-1)
        {
            Instantiate(Particle,transform.position,Quaternion.identity);
           transform.position = new Vector3(transform.position.x +1f,transform.position.y ,-1);
           Instantiate(Particle,transform.position,Quaternion.identity);}}
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){Instantiate(sound,transform.position,Quaternion.identity);
        if(transform.position.x > 0 )
        {
            Instantiate(Particle,transform.position,Quaternion.identity);
            transform.position = new Vector3(transform.position.x -1f,transform.position.y,-1);
            Instantiate(Particle,transform.position,Quaternion.identity);}}
    }
}
