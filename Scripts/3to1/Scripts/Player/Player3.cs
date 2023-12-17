using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public GridManager grid;
    public int width,height;
    public Player1 player1;
    public Player2 player2;
    public bool player3up , player3down, player3right, player3left;
    void Start()
    {
        width =grid.GivePlayerheight();
        height =grid.GivePlayerwidth();
        if(transform.position.y < height-1)player3up = true;else {player3up = false;}
        if(transform.position.y > 0 )player3down = true;else {player3down = false;}
        if(transform.position.x < width-1 )player3right= true; else{player3right = false;}
        if(transform.position.x > 0 )player3left = true; else{player3left = false;}
    }
    void Update()
    {
        if(transform.position.y < height-1)player3up = true;else {player3up = false;}
        if(transform.position.y > 0 )player3down = true;else {player3down = false;}
        if(transform.position.x < width-1 )player3right= true; else{player3right = false;}
        if(transform.position.x > 0 )player3left = true; else{player3left = false;}

        if(transform.position.y < height-1 && player1.player1right&&player2.player2left)
        {
            player3up= true;
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {transform.position = new Vector3(transform.position.x,transform.position.y + 1f,-1);}
        }
        else{player3up = false;}
        if(transform.position.y > 0 && player1.player1left&&player2.player2right)
        {
            player3down= true;
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {transform.position = new Vector3(transform.position.x,transform.position.y -1f,-1);}
        }
        else{player3down = false;}
        if(transform.position.x < width-1 && player1.player1up&&player2.player2down)
        {
            player3right= true;
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {transform.position = new Vector3(transform.position.x +1f,transform.position.y ,-1);}
        }
        else{player3right = false;}
        if(transform.position.x > 0 && player1.player1down&&player2.player2up)
        {   
            player3left= true;
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {transform.position = new Vector3(transform.position.x -1f,transform.position.y,-1);}
        }
        else{player3left = false;}
    }
}
