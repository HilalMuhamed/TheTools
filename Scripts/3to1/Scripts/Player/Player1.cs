using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public GridManager grid;
    public int width,height;
    public bool player1up , player1down, player1right, player1left;
    public Player2 player2;
    public Player3 player3;
    void Start()
    {
        width =grid.GivePlayerheight();
        height =grid.GivePlayerwidth();
        if(transform.position.y < height-1)player1up = true;else {player1up = false;}
        if(transform.position.y > 0 )player1down = true;else {player1down = false;}
        if(transform.position.x < width-1 )player1right= true; else{player1right = false;}
        if(transform.position.x > 0 )player1left = true; else{player1left = false;}
    }
    
    void Update()
    {
        if(transform.position.y < height-1)player1up = true;else {player1up = false;}
        if(transform.position.y > 0 )player1down = true;else {player1down = false;}
        if(transform.position.x < width-1 )player1right= true; else{player1right = false;}
        if(transform.position.x > 0 )player1left = true; else{player1left = false;}
        if(transform.position.y < height-1 && player2.player2down && player3.player3right)
        {
            player1up = true;
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {transform.position = new Vector3(transform.position.x,transform.position.y + 1f,-1);}
        }
        else{player1up = false;}
        if(transform.position.y > 0 && player2.player2up && player3.player3left)
        {
            player1down = true;
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {transform.position = new Vector3(transform.position.x,transform.position.y -1f,-1);}
        }
        else{player1down = false;}
        if(transform.position.x < width-1 && player2.player2left && player3.player3up)
        {
            player1right= true;
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {transform.position = new Vector3(transform.position.x +1f,transform.position.y ,-1);}}
        else{player1right = false;}
        if(transform.position.x > 0 && player2.player2right && player3.player3down)
        {
            player1left = true;
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {transform.position = new Vector3(transform.position.x -1f,transform.position.y,-1);}}
        else{player1left = false;}
    }
}
