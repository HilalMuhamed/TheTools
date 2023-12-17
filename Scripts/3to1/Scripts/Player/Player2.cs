using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GridManager grid;
    public int width,height;
    public Player1 player1;
    public Player3 player3;
    public bool player2up , player2down, player2right, player2left;
    void Start()
    {
        width =grid.GivePlayerheight();
        height =grid.GivePlayerwidth();
        if(transform.position.y < height-1)player2up = true;else {player2up = false;}
        if(transform.position.y > 0 )player2down = true;else {player2down = false;}
        if(transform.position.x < width-1 )player2right= true; else{player2right = false;}
        if(transform.position.x > 0 )player2left = true; else{player2left = false;}
    }
    void Update()
    {
        if(transform.position.y < height-1)player2up = true;else {player2up = false;}
        if(transform.position.y > 0 )player2down = true;else {player2down = false;}
        if(transform.position.x < width-1 )player2right= true; else{player2right = false;}
        if(transform.position.x > 0 )player2left = true; else{player2left = false;}
        if(transform.position.y < height-1 && player1.player1down && player3.player3left)
        {
            player2up= true;
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {transform.position = new Vector3(transform.position.x,transform.position.y + 1f,-1); }
        }
        else{player2up = false;}
        if(transform.position.y > 0 && player1.player1up && player3.player3right)
        {
            player2down = true;
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {transform.position = new Vector3(transform.position.x,transform.position.y -1f,-1);} 
        }
        else{player2down = false;}
        if(transform.position.x < width-1 && player1.player1left && player3.player3down)
        {
            player2right = true;
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {transform.position = new Vector3(transform.position.x +1f,transform.position.y ,-1);} 
        }
        else{player2right = false;}
        if(transform.position.x > 0 && player1.player1right && player3.player3up)
        {
            player2left = true;
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {transform.position = new Vector3(transform.position.x -1f,transform.position.y,-1);} 
        }
        else{player2left = false;}
    }
}
