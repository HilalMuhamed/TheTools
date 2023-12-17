using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNo1 : MonoBehaviour
{
    public GridManager grid;
    public int width,height;
    public Transform player2, player3;
    void Start()
    {
        width =grid.GivePlayerheight();
        height =grid.GivePlayerwidth();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
        if(transform.position.y < height-1 && player2.position.y > 0 && player3.position.x < width-1)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + 1f,-1);}
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){
        if(transform.position.y > 0 && player2.position.y < height -1 && player3.position.x > 0)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y -1f,-1);}
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
        if(transform.position.x < width-1 && player2.position.x > 0 && player3.position.y < height-1)
        {
           transform.position = new Vector3(transform.position.x +1f,transform.position.y ,-1);}}
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
        if(transform.position.x > 0 && player2.position.x < width-1 && player3.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x -1f,transform.position.y,-1);}}
    }
}
